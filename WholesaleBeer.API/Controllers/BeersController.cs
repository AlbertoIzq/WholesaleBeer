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

            // Show information to the client
            return Ok(beerDto);
        }
    }
}
