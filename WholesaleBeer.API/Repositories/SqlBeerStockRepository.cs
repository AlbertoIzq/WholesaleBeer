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

        public async Task<BeerStock?> UpdateAsync(Guid id, BeerStock beerStock)
        {
            // Check if BeerStock exists
            var existingBeerStock = await _wholesaleBeerDbContext.BeerStocks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBeerStock is null)
            {
                return null;
            }

            // Assign updated values
            existingBeerStock.BeerId = beerStock.BeerId;
            existingBeerStock.WholesalerId = beerStock.WholesalerId;
            existingBeerStock.StockLeft = beerStock.StockLeft;

            await _wholesaleBeerDbContext.SaveChangesAsync();

            // Populate Beer and Wholesaler navigation properties
            BeerStock beerStockReturn = await _wholesaleBeerDbContext.BeerStocks
                .Include(x => x.Beer)
                .Include(x => x.Wholesaler)
                .FirstOrDefaultAsync(x => x.Id == id);

            return existingBeerStock;
        }
    }
}