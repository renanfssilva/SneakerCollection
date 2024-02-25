using ErrorOr;
using MediatR;
using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Application.Sneakers.Queries
{
    public record ListSneakersQuery(string UserId) : IRequest<ErrorOr<List<Sneaker>>>;
}
