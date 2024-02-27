using FluentAssertions;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Domain.Tests.Sneakers
{
    public class SneakerIdTests
    {
        [Fact]
        public void ShouldCreateSneakerId()
        {
            // Act
            var sneakerId = SneakerId.Create(Constants.Sneaker.Id.Value);

            // Assert
            sneakerId.Should().NotBeNull();
            sneakerId.Should().BeOfType<SneakerId>();
            sneakerId.Value.Should().NotBeEmpty();
        }

        [Fact]
        public void ShouldCreateUniqueSneakerId()
        {
            // Act
            var sneakerId = SneakerId.CreateUnique();

            // Assert
            sneakerId.Should().NotBeNull();
            sneakerId.Should().BeOfType<SneakerId>();
            sneakerId.Value.Should().NotBeEmpty();
        }
    }
}
