using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WholesaleBeer.API.Controllers;
using WholesaleBeer.API.Mappings;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Models.DTO;
using WholesaleBeer.API.Repositories.Interfaces;

namespace WholesaleBeer.API.Tests
{
    public class BeersControllerTests
    {
        private readonly Mock<IBeerRepository> _beerRepositoryMock;
        private readonly IMapper _mapper;

        private readonly BeersController _beersController;

        // Arrange
        public BeersControllerTests()
        {
            _beerRepositoryMock = new Mock<IBeerRepository>();
            _beerRepositoryMock.Setup(repo => repo.GetAllAsync(null, true)).ReturnsAsync(GetAllBeersRepositoryData());

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            _mapper = mapper.CreateMapper();

            _beersController = new BeersController(_beerRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            // Act
            var actionResult = await _beersController.GetAll(null, null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<ICollection<BeerDto>>(okResult.Value);
            var expected = GetAllBeersDtoTestData();
            Assert.Equivalent(expected, result);
        }

        private List<Beer> GetAllBeersRepositoryData()
        {
            var beers = new List<Beer>()
            {
                new Beer
                {
                    Id = Guid.Parse("771F94AC-9BD6-4C82-2457-08DCE27BE8AE"),
                    Name = "Orval",
                    AlcoholContentPercentage = 6.2,
                    Price = 3.7,
                    BreweryId = Guid.Parse("8DB2BB14-5AE6-4894-9AAB-205D29BFB176"),
                    Brewery = new Brewery
                    {
                        Id = Guid.Parse("8DB2BB14-5AE6-4894-9AAB-205D29BFB176"),
                        Name = "Abbaye d'Orval"
                    }
                },
                new Beer
                {
                    Id = Guid.Parse("6E3B4A15-AE20-40A1-114A-08DCE2D288AD"),
                    Name = "Rochefort 10",
                    AlcoholContentPercentage = 11.3,
                    Price = 4.1,
                    BreweryId = Guid.Parse("91D8C67C-C92B-48A4-95B3-77182BFCBF73"),
                    Brewery = new Brewery
                    {
                        Id = Guid.Parse("91D8C67C-C92B-48A4-95B3-77182BFCBF73"),
                        Name = "Abbaye Notre Dame de St Remy"
                    }
                }
            };

            return beers;
        }

        private List<BeerDto> GetAllBeersDtoTestData()
        {
            var beersDto = new List<BeerDto>()
            {
                new BeerDto
                {
                    Id = Guid.Parse("771F94AC-9BD6-4C82-2457-08DCE27BE8AE"),
                    Name = "Orval",
                    AlcoholContentPercentage = 6.2,
                    Price = 3.7,
                    Brewery = new Brewery
                    {
                        Id = Guid.Parse("8DB2BB14-5AE6-4894-9AAB-205D29BFB176"),
                        Name = "Abbaye d'Orval"
                    }
                },
                new BeerDto
                {
                    Id = Guid.Parse("6E3B4A15-AE20-40A1-114A-08DCE2D288AD"),
                    Name = "Rochefort 10",
                    AlcoholContentPercentage = 11.3,
                    Price = 4.1,
                    Brewery = new Brewery
                    {
                        Id = Guid.Parse("91D8C67C-C92B-48A4-95B3-77182BFCBF73"),
                        Name = "Abbaye Notre Dame de St Remy"
                    }
                }
            };

            return beersDto;
        }
    }
}