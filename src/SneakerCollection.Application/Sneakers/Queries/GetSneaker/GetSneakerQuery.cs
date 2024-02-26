using ErrorOr;
using MediatR;
using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Application.Sneakers.Queries.GetSneaker
{
    public record GetSneakerQuery(
        Guid SneakerId,
        string UserId) : IRequest<ErrorOr<Sneaker>>;
}
