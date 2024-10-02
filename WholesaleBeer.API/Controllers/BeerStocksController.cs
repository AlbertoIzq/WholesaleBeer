using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WholesaleBeer.API.CustomActionFilters;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Models.DTO;
using WholesaleBeer.API.Repositories;

namespace WholesaleBeer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerStocksController : ControllerBase
    {
        private readonly IBeerStockRepository _beerStockRepository;
        private readonly IMapper _mapper;

        public BeerStocksController(IBeerStockRepository beerStockRepository, IMapper mapper)
        {
            _beerStockRepository = beerStockRepository;
            _mapper = mapper;
        }

        // CREATE BeerStock
        // POST: api/beerstocks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddBeerStockRequestDto addBeerStockRequestDto)
        {
            // Map DTO to Domain Model
            var beerStockDomainModel = _mapper.Map<BeerStock>(addBeerStockRequestDto);

            // Create BeerStock
            await _beerStockRepository.CreateAsync(beerStockDomainModel);

            // Map Domain Model back to DTO
            var beerStockDto = _mapper.Map<BeerStockDto>(beerStockDomainModel);

            // Return created beerStock back to the client
            return Ok(beerStockDto);
        }
    }
}