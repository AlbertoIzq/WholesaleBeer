using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> CreateAsync(OrderDetail orderDetail);
    }
}