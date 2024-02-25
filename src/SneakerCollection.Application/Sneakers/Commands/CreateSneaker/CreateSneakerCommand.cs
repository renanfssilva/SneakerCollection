using ErrorOr;
using MediatR;
using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Application.Sneakers.Commands.CreateSneaker
{
    public record CreateSneakerCommand(
        string UserId,
        string Name,
        BrandCommand Brand,
        PriceCommand Price,
        double SizeUS,
        int Year,
        int Rate) : IRequest<ErrorOr<Sneaker>>;

    public record PriceCommand(
        decimal Amount,
        string Currency);

    public record BrandCommand(
        string Name);
}
