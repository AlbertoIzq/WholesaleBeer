using Moq;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Repositories.Interfaces;
using WholesaleBeer.Utility;

namespace WholesaleBeer.API.Tests
{
    public class OrderDetailPriceCalculatorTests
    {
        private readonly Mock<IBeerRepository> _beerRepositoryMock;

        private readonly OrderDetailPriceCalculator _orderDetailPriceCalculator;

        // Arrange
        public OrderDetailPriceCalculatorTests()
        {
            _beerRepositoryMock = new Mock<IBeerRepository>();
            _beerRepositoryMock.Setup(repo => repo.GetByIdAsync(beerGuid)).ReturnsAsync(RepositoryData());

            _orderDetailPriceCalculator = new OrderDetailPriceCalculator(_beerRepositoryMock.Object);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public async Task CalculatePrice_Successful(OrderDetail orderDetail, double price)
        {
            // Act
            var result = await _orderDetailPriceCalculator.CalculatePrice(orderDetail);

            // Assert
            Assert.Equivalent(price, result);
        }

        private Beer RepositoryData()
        {
            return new Beer
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
            };
        }

        private Guid beerGuid = Guid.Parse("771F94AC-9BD6-4C82-2457-08DCE27BE8AE");

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                new OrderDetail
                {
                    BeerId = Guid.Parse("771F94AC-9BD6-4C82-2457-08DCE27BE8AE"), // Price = 3.7
                    WholesalerId = Guid.Parse("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"),
                    Quantity = 5
                },
                18.5
            };
            yield return new object[]
            {
                new OrderDetail
                {
                    BeerId = Guid.Parse("771F94AC-9BD6-4C82-2457-08DCE27BE8AE"),
                    WholesalerId = Guid.Parse("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"),
                    Quantity = 15,
                },
                49.95
            };
            yield return new object[]
            {
                new OrderDetail
                {
                    BeerId = Guid.Parse("771F94AC-9BD6-4C82-2457-08DCE27BE8AE"),
                    WholesalerId = Guid.Parse("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"),
                    Quantity = 25,
                },
                74
            };
        }
    }
}