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
    public class BeersController : ControllerBase
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IMapper _mapper;

        public BeersController(IBeerRepository beerRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
        }

        // CREATE Beer
        // POST: api/beers
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddBeerRequestDto addBeerRequestDto)
        {
            // Map DTO to Domain Model
            var beerDomainModel = _mapper.Map<Beer>(addBeerRequestDto);

            // Create Beer
            await _beerRepository.CreateAsync(beerDomainModel);

            // Map Domain Model back to DTO
            var beerDto = _mapper.Map<BeerDto>(beerDomainModel);

            // Return created beer back to the client
            return Ok(beerDto);
        }

        // DELETE Beer
        // DELETE: api/beers/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Delete if it exists
            var beerDomainModel = await _beerRepository.DeleteAsync(id);

            if (beerDomainModel is null)
            {
                return NotFound();
            }

            // Map Domain Model back to DTO
            var beerDto = _mapper.Map<BeerDto>(beerDomainModel);

            // Return deleted beer back to the client
            return Ok(beerDto);
        }

        // GET All Beer
        // GET: api/beers?sortBy=PropertyName&isAscending=true
        // e.g. sortBy=Brewery&isAscending=false
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? sortBy, [FromQuery] bool? isAscending)
        {
            // Get all beers
            var beersDomainModel = await _beerRepository.GetAllAsync(sortBy, isAscending ?? true);

            // Map Domain Model back to DTO
            var beersDto = _mapper.Map<List<BeerDto>>(beersDomainModel);

            // Return created beer back to the client
            return Ok(beersDto);
        }
    }
}