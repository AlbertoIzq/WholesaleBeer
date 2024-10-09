using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> CreateAsync(OrderDetail orderDetail);
        Task<List<OrderDetail>> GetAllAsync();
    }
}