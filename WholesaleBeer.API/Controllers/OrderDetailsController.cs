using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WholesaleBeer.API.CustomActionFilters;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Models.DTO;
using WholesaleBeer.API.Repositories.Interfaces;
using static System.Net.Mime.MediaTypeNames;

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
            ValidateOrderDetail(addOrderDetailRequestDto);

            if (ModelState.IsValid)
            {
                // Map DTO to Domain Model
                var orderDetailDomainModel = _mapper.Map<OrderDetail>(addOrderDetailRequestDto);

                // Calculate price
                var beerOrdered = await _beerRepository.GetByIdAsync(orderDetailDomainModel.BeerId);
                var priceBeer = beerOrdered.Price;
                orderDetailDomainModel.Price = orderDetailDomainModel.Quantity * priceBeer;

                // Create orderDetail
                await _orderDetailRepository.CreateAsync(orderDetailDomainModel);

                // Map Domain Model back to DTO
                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetailDomainModel);

                // Return created orderDetail back to the client
                return Ok(orderDetailDto);
            }

            return BadRequest(ModelState);
        }

        private void ValidateOrderDetail(AddOrderDetailRequestDto addOrderDetailRequestDto)
        {
            /// @todo
        }
    }
}