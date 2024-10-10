using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WholesaleBeer.API.Controllers;
using WholesaleBeer.API.Helpers;
using WholesaleBeer.API.Mappings;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Models.DTO;
using WholesaleBeer.API.Repositories.Interfaces;
using WholesaleBeer.Utility;

namespace WholesaleBeer.API.Tests
{
    public class OrderDetailsControllerTests
    {
        private readonly Mock<IOrderDetailRepository> _orderDetailRepositoryMock;
        private readonly IMapper _mapper;
        private readonly Mock<IOrderDetailPriceCalculator> _orderDetailPriceCalculatorMock;
        private readonly Mock<IOrderDetailValidator> _orderDetailValidatorMock;

        private readonly Mock<IBeerRepository> _beerRepositoryMock;
        private readonly Mock<IBeerStockRepository> _beerStockRepositoryMock;
        private readonly Mock<IWholesalerRepository> _wholesalerRepositoryMock;

        private readonly OrderDetailsController _orderDetailsController;

        // Arrange
        public OrderDetailsControllerTests()
        {
            _orderDetailRepositoryMock = new Mock<IOrderDetailRepository>();
            _orderDetailRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<OrderDetail>())).ReturnsAsync(GetOrderDetailRepositoryData());

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            _mapper = mapper.CreateMapper();            

            _beerRepositoryMock = new Mock<IBeerRepository>();
            _beerStockRepositoryMock = new Mock<IBeerStockRepository>();
            _wholesalerRepositoryMock = new Mock<IWholesalerRepository>();

            _orderDetailPriceCalculatorMock = new Mock<IOrderDetailPriceCalculator>();
            _orderDetailPriceCalculatorMock.Setup(x => x.CalculatePrice(It.IsAny<OrderDetail>())).ReturnsAsync(PriceOrderDetail);

            _orderDetailValidatorMock = new Mock<IOrderDetailValidator>();
            _orderDetailValidatorMock.Setup(x => x.ValidateOrderDetail(It.IsAny<AddOrderDetailRequestDto>())).ReturnsAsync(true);

            _orderDetailsController = new OrderDetailsController(_orderDetailRepositoryMock.Object, _mapper,
                _beerStockRepositoryMock.Object, _wholesalerRepositoryMock.Object, _beerRepositoryMock.Object,
                _orderDetailPriceCalculatorMock.Object, _orderDetailValidatorMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOk()
        {
            // Act
            var actionResult = await _orderDetailsController.Create(GetAddOrderDetailRequestDtoTestData());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsAssignableFrom<OrderDetailDto>(okResult.Value);
            var expected = GetOrderDetailDtoExpected();
            Assert.Equivalent(expected, result);
        }

        private AddOrderDetailRequestDto GetAddOrderDetailRequestDtoTestData()
        {
            return new AddOrderDetailRequestDto
            {
                BeerId = Guid.Parse("771F94AC-9BD6-4C82-2457-08DCE27BE8AE"),
                WholesalerId = Guid.Parse("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"),
                Quantity = 10
            };
        }

        private OrderDetail GetOrderDetailRepositoryData()
        {
            return new OrderDetail
            {
                Id = Guid.NewGuid(),
                BeerId = Guid.Parse("771F94AC-9BD6-4C82-2457-08DCE27BE8AE"),
                WholesalerId = Guid.Parse("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"),
                Quantity = 10,
                Price = 33.3,
                Beer = new Beer
                {
                    Id = Guid.Parse("771F94AC-9BD6-4C82-2457-08DCE27BE8AE"),
                    Name = "Orval",
                    AlcoholContentPercentage = 6.2,
                    Price = 3.7,
                    BreweryId = Guid.Parse("8db2bb14-5ae6-4894-9aab-205d29bfb176"),
                    Brewery = new Brewery
                    {
                        Id = Guid.Parse("8db2bb14-5ae6-4894-9aab-205d29bfb176"),
                        Name = "Abbaye d'Orval"
                    }
                },
                Wholesaler = new Wholesaler
                {
                    Id = Guid.Parse("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"),
                    Name = "Belgibeer"
                }
            };
        }

        private const double PriceOrderDetail = 33.3;

        private OrderDetailDto GetOrderDetailDtoExpected()
        {
            return new OrderDetailDto
            {
                Id = Guid.NewGuid(),
                Quantity = 10,
                Price = 33.3,
                Beer = new BeerDto
                {
                    Id = Guid.Parse("771F94AC-9BD6-4C82-2457-08DCE27BE8AE"),
                    Name = "Orval",
                    AlcoholContentPercentage = 6.2,
                    Price = 3.7,
                    Brewery = new Brewery
                    {
                        Id = Guid.Parse("8db2bb14-5ae6-4894-9aab-205d29bfb176"),
                        Name = "Abbaye d'Orval"
                    },
                },
                Wholesaler = new Wholesaler
                {
                    Id = Guid.Parse("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"),
                    Name = "Belgibeer"
                }
            };
        }
    }
}