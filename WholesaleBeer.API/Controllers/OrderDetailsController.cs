using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WholesaleBeer.API.CustomActionFilters;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Models.DTO;
using WholesaleBeer.API.Repositories.Interfaces;
using WholesaleBeer.Utility;

namespace WholesaleBeer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;
        private readonly IBeerRepository _beerRepository;
        private readonly IBeerStockRepository _beerStockRepository;
        private readonly IWholesalerRepository _wholesalerRepository;

        public OrderDetailsController(IOrderDetailRepository orderDetailRepository,
            IMapper mapper, IBeerRepository beerRepository, IBeerStockRepository beerStockRepository,
            IWholesalerRepository wholesalerRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
            _beerRepository = beerRepository;
            _beerStockRepository = beerStockRepository;
            _wholesalerRepository = wholesalerRepository;
        }

        // CREATE OrderDetail
        // POST: api/orderdetails
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddOrderDetailRequestDto addOrderDetailRequestDto)
        {
            try
            {
                await ValidateOrderDetail(addOrderDetailRequestDto);

                // Map DTO to Domain Model
                var orderDetailDomainModel = _mapper.Map<OrderDetail>(addOrderDetailRequestDto);

                // Calculate price
                double price = await CalculatePrice(orderDetailDomainModel);
                orderDetailDomainModel.Price = price;

                // Create orderDetail
                await _orderDetailRepository.CreateAsync(orderDetailDomainModel);

                // Map Domain Model back to DTO
                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetailDomainModel);

                // Return created orderDetail back to the client
                return Ok(orderDetailDto);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, (int)HttpStatusCode.BadRequest);
            }
        }

        private async Task ValidateOrderDetail(AddOrderDetailRequestDto addOrderDetailRequestDto)
        {
            // Check if order is empty
            if (addOrderDetailRequestDto.Quantity <= 0)
            {
                throw new Exception("The order cannot be empty");
            }

            // Check if wholesaler exists
            var wholesalers = await _wholesalerRepository.GetAllAsync();
            var wholesaler = wholesalers.FirstOrDefault(x => x.Id == addOrderDetailRequestDto.WholesalerId);
            if (wholesaler is null)
            {
                throw new Exception("The wholesaler must exist");
            }

            // Check if there's any duplicate in the order
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            var orderDetail = orderDetails.FirstOrDefault(x => x.BeerId == addOrderDetailRequestDto.BeerId &&
            x.WholesalerId == addOrderDetailRequestDto.WholesalerId && x.Quantity == addOrderDetailRequestDto.Quantity);
            if (orderDetail is not null)
            {
                throw new Exception("There can't be any duplicate in the order");
            }
        }

        private async Task<double> CalculatePrice(OrderDetail orderDetail)
        {
            var beerOrdered = await _beerRepository.GetByIdAsync(orderDetail.BeerId);
            var priceBeer = beerOrdered.Price;
            double price = orderDetail.Quantity * priceBeer;

            // Apply discount
            if (orderDetail.Quantity > SD.DISCOUNT_B_MIN_BEERS)
            {
                price *= (1 - SD.DISCOUNT_B);
            }
            else if (orderDetail.Quantity > SD.DISCOUNT_A_MIN_BEERS)
            {
                price *= (1 - SD.DISCOUNT_A);
            }

            return price;
        }
    }
}