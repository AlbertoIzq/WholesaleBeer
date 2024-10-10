using WholesaleBeer.API.Models.DTO;
using WholesaleBeer.API.Repositories.Interfaces;

namespace WholesaleBeer.API.Helpers
{
    public class OrderDetailValidator : IOrderDetailValidator
    {
        private readonly IWholesalerRepository _wholesalerRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IBeerStockRepository _beerStockRepository;

        public OrderDetailValidator(IWholesalerRepository wholesalerRepository,
            IOrderDetailRepository orderDetailRepository, IBeerStockRepository beerStockRepository)
        {
            _wholesalerRepository = wholesalerRepository;
            _orderDetailRepository = orderDetailRepository;
            _beerStockRepository = beerStockRepository;
        }

        public async Task<bool> ValidateOrderDetail(AddOrderDetailRequestDto addOrderDetailRequestDto)
        {
            // Check if order is empty
            if (addOrderDetailRequestDto.Quantity <= 0)
            {
                throw new Exception("The order cannot be empty");
            }

            // Check if wholesaler exists
            var wholesalers = await _wholesalerRepository.GetAllAsync();
            var wholesaler = wholesalers?.FirstOrDefault(x => x.Id == addOrderDetailRequestDto.WholesalerId);
            if (wholesaler is null)
            {
                throw new Exception("The wholesaler must exist");
            }

            // Check if there's any duplicate in the order
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            var orderDetail = orderDetails?.FirstOrDefault(x => x.BeerId == addOrderDetailRequestDto.BeerId &&
                x.WholesalerId == addOrderDetailRequestDto.WholesalerId && x.Quantity == addOrderDetailRequestDto.Quantity);
            if (orderDetail is not null)
            {
                throw new Exception("There can't be any duplicate in the order");
            }

            // Check if the beer is sold by the wholesaler and if there's enough stock
            var beerStocks = await _beerStockRepository.GetAllAsync();
            var beerStock = beerStocks?.FirstOrDefault(x => x.BeerId == addOrderDetailRequestDto.BeerId &&
                x.WholesalerId == addOrderDetailRequestDto.WholesalerId);
            if (beerStock is null)
            {
                throw new Exception("The beer must be sold by the wholesaler");
            }
            else
            {
                if (beerStock.StockLeft < addOrderDetailRequestDto.Quantity)
                {
                    throw new Exception("The number of beers ordered cannot be greater than the wholesaler's stock");
                }
            }

            return true;
        }
    }
}
