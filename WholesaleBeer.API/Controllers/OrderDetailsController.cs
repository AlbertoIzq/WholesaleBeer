using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WholesaleBeer.API.CustomActionFilters;
using WholesaleBeer.API.Helpers;
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
        private readonly IBeerStockRepository _beerStockRepository;
        private readonly IWholesalerRepository _wholesalerRepository;

        private readonly IOrderDetailPriceCalculator _orderDetailPriceCalculator;
        private readonly IOrderDetailValidator _orderDetailValidator;
        private readonly IBeerRepository _beerRepository;

        public OrderDetailsController(IOrderDetailRepository orderDetailRepository,
            IMapper mapper, IBeerStockRepository beerStockRepository,
            IWholesalerRepository wholesalerRepository, IBeerRepository beerRepository,
            IOrderDetailPriceCalculator orderDetailPriceCalculator, IOrderDetailValidator orderDetailValidator)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
            _beerStockRepository = beerStockRepository;
            _wholesalerRepository = wholesalerRepository;
            _beerRepository = beerRepository;
            _orderDetailPriceCalculator = orderDetailPriceCalculator;
            _orderDetailValidator = orderDetailValidator;
        }

        // CREATE OrderDetail
        // POST: api/orderdetails
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddOrderDetailRequestDto addOrderDetailRequestDto)
        {
            try
            {
                if(await _orderDetailValidator.ValidateOrderDetail(addOrderDetailRequestDto))
                {
                    // Map DTO to Domain Model
                    var orderDetailDomainModel = _mapper.Map<OrderDetail>(addOrderDetailRequestDto);

                    // Calculate price
                    double price = await _orderDetailPriceCalculator.CalculatePrice(orderDetailDomainModel);
                    orderDetailDomainModel.Price = price;

                    // Create orderDetail
                    orderDetailDomainModel = await _orderDetailRepository.CreateAsync(orderDetailDomainModel);

                    // Map Domain Model back to DTO
                    var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetailDomainModel);

                    // Return created orderDetail back to the client
                    return Ok(orderDetailDto);
                }
                else
                {
                    return BadRequest("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, (int)HttpStatusCode.BadRequest);
            }
        }
    }
}