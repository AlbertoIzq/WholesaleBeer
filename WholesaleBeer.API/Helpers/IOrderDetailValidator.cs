using WholesaleBeer.API.Models.DTO;
using WholesaleBeer.API.Repositories.Interfaces;

namespace WholesaleBeer.API.Helpers
{
    public interface IOrderDetailValidator
    {
        public Task<bool> ValidateOrderDetail(AddOrderDetailRequestDto addOrderDetailRequestDto);
    }
}
