using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Repositories
{
    public interface IBeerRepository
    {
        Task<Beer> CreateAsync(Beer beer);
    }
}
