using FluentAssertions;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Domain.Tests.Brands
{
    public class BrandTests
    {
        [Fact]
        public void Brand_Create_ReturnsBrand()
        {
            // Arrange
            // Act
            var brand = Brand.Create(Constants.Sneaker.BrandName);

            // Assert
            brand.Should().BeOfType<Brand>();
            brand.Should().NotBeNull();
            brand.Name.Should().Be(Constants.Sneaker.BrandName);
        }
    }
}
