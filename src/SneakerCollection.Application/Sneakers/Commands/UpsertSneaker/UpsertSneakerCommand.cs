using ErrorOr;
using MediatR;
using SneakerCollection.Application.Sneakers.Common;

namespace SneakerCollection.Application.Sneakers.Commands.UpsertSneaker
{
    public record UpsertSneakerCommand(
        Guid SneakerId,
        string UserId,
        string Name,
        BrandCommand Brand,
        PriceCommand Price,
        double SizeUS,
        int Year,
        int Rate) : IRequest<ErrorOr<UpsertSneakerResponse>>;
}
