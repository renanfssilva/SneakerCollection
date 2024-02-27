using FluentAssertions;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Domain.Tests.Prices
{
    public class PriceTests
    {
        [Fact]
        public void Price_Create_ReturnsPrice()
        {
            // Arrange
            // Act
            var price = Price.Create(Constants.Sneaker.PriceAmount, Constants.Sneaker.PriceCurrency);

            // Assert
            price.Should().BeOfType<Price>();
            price.Should().NotBeNull();
            price.Amount.Should().Be(Constants.Sneaker.PriceAmount);
            price.Currency.Should().Be(Constants.Sneaker.PriceCurrency);
        }
    }
}
