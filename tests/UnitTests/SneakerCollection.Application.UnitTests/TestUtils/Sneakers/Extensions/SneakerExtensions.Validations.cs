using FluentAssertions;
using SneakerCollection.Application.Sneakers.Commands.CreateSneaker;
using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Application.UnitTests.TestUtils.Sneakers.Extensions
{
    public static partial class SneakerExtensions
    {
        public static void ValidateCreatedFrom(this Sneaker sneaker, CreateSneakerCommand command)
        {
            sneaker.Name.Should().Be(command.Name);
            sneaker.Brand.Name.Should().Be(command.Brand.Name);
            sneaker.Price.Currency.Should().Be(command.Price.Currency);
            sneaker.Price.Amount.Should().Be(command.Price.Amount);
            sneaker.SizeUS.Should().Be(command.SizeUS);
            sneaker.Year.Should().Be(command.Year);
            sneaker.Rate.Should().Be(command.Rate);
            sneaker.UserId.Value.ToString().Should().Be(command.UserId);
        }
    }
}
