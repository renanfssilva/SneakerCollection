using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Application.Sneakers.Commands.UpsertSneaker
{
    public record UpsertSneakerResponse(
        bool IsNewlyCreated,
        Sneaker Sneaker);
}
