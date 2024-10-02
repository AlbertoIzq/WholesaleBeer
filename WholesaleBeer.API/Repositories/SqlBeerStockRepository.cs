using Microsoft.EntityFrameworkCore;
using WholesaleBeer.API.Data;
using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Repositories
{
    public class SqlBeerStockRepository : IBeerStockRepository
    {
        private readonly WholesaleBeerDbContext _wholesaleBeerDbContext;

        public SqlBeerStockRepository(WholesaleBeerDbContext wholesaleBeerDbContext)
        {
            _wholesaleBeerDbContext = wholesaleBeerDbContext;
        }

        public async Task<BeerStock> CreateAsync(BeerStock beerStock)
        {
            await _wholesaleBeerDbContext.BeerStocks.AddAsync(beerStock);
            await _wholesaleBeerDbContext.SaveChangesAsync();

            // Populate Beer and Wholesaler navigation properties
            BeerStock beerStockReturn = await _wholesaleBeerDbContext.BeerStocks
                .Include(x => x.Beer)
                .Include(x => x.Wholesaler)
                .FirstOrDefaultAsync(x => x.Id == beerStock.Id);

            return beerStockReturn;
        }
    }
}