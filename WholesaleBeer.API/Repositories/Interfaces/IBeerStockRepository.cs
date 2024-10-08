using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Repositories.Interfaces
{
    public interface IBeerStockRepository
    {
        Task<BeerStock> CreateAsync(BeerStock beerStock);
        Task<BeerStock?> UpdateAsync(Guid id, BeerStock beerStock);
        Task<List<BeerStock>> GetAllAsync();
    }
}