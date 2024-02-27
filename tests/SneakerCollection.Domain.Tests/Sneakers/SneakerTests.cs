using FluentAssertions;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Domain.Tests.Sneakers
{
    public class SneakerTests
    {
        [Fact]
        public void Sneaker_Create_ReturnsUser()
        {
            // Arrange
            var brand = Brand.Create(Constants.Sneaker.BrandName);
            var price = Price.Create(Constants.Sneaker.PriceAmount, Constants.Sneaker.PriceCurrency);

            // Act
            var sneaker = Sneaker.Create(Constants.Sneaker.Name,
                                        brand,
                                        price,
                                        Constants.Sneaker.SizeUS,
                                        Constants.Sneaker.Year,
                                        Constants.Sneaker.Rate,
                                        Constants.User.Id);

            // Assert
            sneaker.Should().NotBeNull();
            sneaker.Id.Should().NotBeNull();
            sneaker.Id.Value.Should().NotBeEmpty();
            sneaker.UserId.Should().Be(Constants.User.Id);
            sneaker.Brand.Should().Be(brand);
            sneaker.Price.Should().Be(price);
            sneaker.Name.Should().Be(Constants.Sneaker.Name);
            sneaker.SizeUS.Should().Be(Constants.Sneaker.SizeUS);
            sneaker.Year.Should().Be(Constants.Sneaker.Year);
            sneaker.Rate.Should().Be(Constants.Sneaker.Rate);
        }

        [Fact]
        public void Sneaker_Update_ReturnsUser()
        {
            // Arrange
            var brand = Brand.Create(Constants.Sneaker.BrandName);
            var price = Price.Create(Constants.Sneaker.PriceAmount, Constants.Sneaker.PriceCurrency);

            // Act
            var sneaker = Sneaker.Update(Constants.Sneaker.Id,
                                            Constants.Sneaker.Name,
                                            brand,
                                            price,
                                            Constants.Sneaker.SizeUS,
                                            Constants.Sneaker.Year,
                                            Constants.Sneaker.Rate,
                                            Constants.User.Id);

            // Assert
            sneaker.Should().NotBeNull();
            sneaker.Id.Should().NotBeNull();
            sneaker.Id.Value.Should().NotBeEmpty();
            sneaker.UserId.Should().Be(Constants.User.Id);
            sneaker.Brand.Should().Be(brand);
            sneaker.Price.Should().Be(price);
            sneaker.Name.Should().Be(Constants.Sneaker.Name);
            sneaker.SizeUS.Should().Be(Constants.Sneaker.SizeUS);
            sneaker.Year.Should().Be(Constants.Sneaker.Year);
            sneaker.Rate.Should().Be(Constants.Sneaker.Rate);
        }
    }
}
