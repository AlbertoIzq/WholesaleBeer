using Microsoft.EntityFrameworkCore;
using WholesaleBeer.API.Data;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Repositories.Interfaces;

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

            // Populate Brewery navigation property
            Beer beerReturn = await _wholesaleBeerDbContext.Beers
                .Include(x => x.Brewery)
                .FirstOrDefaultAsync(x => x.Id == beer.Id);

            return beerReturn;
        }

        public async Task<Beer?> DeleteAsync(Guid id)
        {
            // Check if it exists
            var existingBeer = await _wholesaleBeerDbContext.Beers
                .Include(x => x.Brewery)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingBeer == null)
            {
                return null;
            }

            // Delete beer
            _wholesaleBeerDbContext.Beers.Remove(existingBeer);
            await _wholesaleBeerDbContext.SaveChangesAsync();

            return existingBeer;
        }

        public async Task<List<Beer>> GetAllAsync(string? sortBy = null, bool isAscending = true)
        {
            var beers = _wholesaleBeerDbContext.Beers
                .Include(x => x.Brewery)
                .AsQueryable();

            // Sorting by Brewery
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.Equals("Brewery", StringComparison.OrdinalIgnoreCase))
                {
                    beers = isAscending ? beers.OrderBy(x => x.Brewery.Name) : beers.OrderByDescending(x => x.Brewery.Name);
                }
            }

            return await beers.ToListAsync();
        }

        public async Task<Beer?> GetByIdAsync(Guid id)
        {
            return await _wholesaleBeerDbContext.Beers
                .Include(x => x.Brewery)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
