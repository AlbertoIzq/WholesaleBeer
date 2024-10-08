using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WholesaleBeer.API.CustomActionFilters;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Models.DTO;
using WholesaleBeer.API.Repositories.Interfaces;

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

        // UPDATE BeerStock
        // PUT: api/beerstocks/{id}
        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateBeerStockRequestDto updateBeerStockRequestDto)
        {
            // Map from Dto to Domain Model
            var beerStockDomainModel = _mapper.Map<BeerStock>(updateBeerStockRequestDto);

            // Update if it exists
            beerStockDomainModel = await _beerStockRepository.UpdateAsync(id, beerStockDomainModel);

            if (beerStockDomainModel is null)
            {
                return NotFound();
            }

            // Map Domain Model to Dto
            var beerStockDto = _mapper.Map<BeerStockDto>(beerStockDomainModel);

            // Return updated beerStock back to the client
            return Ok(beerStockDto);
        }
    }
}