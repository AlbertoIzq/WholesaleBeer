using Microsoft.EntityFrameworkCore;
using WholesaleBeer.API.Data;
using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Repositories
{
    public class SqlBeerRepository : IBeerRepository
    {
        private readonly WholesaleBeerDbContext _wholesaleBeerDbContext;

        public SqlBeerRepository(WholesaleBeerDbContext wholesaleBeerDbContext)
        {
            _wholesaleBeerDbContext = wholesaleBeerDbContext;
        }

        public async Task<Beer> CreateAsync(Beer beer)
        {
            await _wholesaleBeerDbContext.Beers.AddAsync(beer);
            await _wholesaleBeerDbContext.SaveChangesAsync();

            // Used to populate Brewery navigation property
            Beer beerReturn = await _wholesaleBeerDbContext.Beers
                .Include(x => x.Brewery)
                .FirstOrDefaultAsync(x => x.Id == beer.Id);

            return beerReturn;
        }
    }
}
