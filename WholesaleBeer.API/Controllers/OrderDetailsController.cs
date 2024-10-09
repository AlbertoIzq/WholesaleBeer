using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public OrderDetailsController(IOrderDetailRepository orderDetailRepository,
            IMapper mapper, IBeerRepository beerRepository, IBeerStockRepository beerStockRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
            _beerRepository = beerRepository;
            _beerStockRepository = beerStockRepository;
        }

        // CREATE OrderDetail
        // POST: api/orderdetails
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddOrderDetailRequestDto addOrderDetailRequestDto)
        {
            try
            {
            ValidateOrderDetail(addOrderDetailRequestDto);

            if (ModelState.IsValid)
            {
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

        private void ValidateOrderDetail(AddOrderDetailRequestDto addOrderDetailRequestDto)
        {
            if (addOrderDetailRequestDto.Quantity <= 0)
            {
                throw new Exception("The order cannot be empty");
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