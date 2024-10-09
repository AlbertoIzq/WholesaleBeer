using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Repositories.Interfaces
{
    public interface IWholesalerRepository
    {
        Task<List<Wholesaler>> GetAllAsync();
    }
}