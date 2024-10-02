using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Repositories
{
    public interface IBeerRepository
    {
        Task<Beer> CreateAsync(Beer beer);
        Task<Beer?> DeleteAsync(Guid id);
        Task<List<Beer>> GetAllAsync(string? sortBy = null, bool isAscending = true);
    }
}