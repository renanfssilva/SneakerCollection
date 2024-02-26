using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Application.Sneakers.Commands.UpdateSneaker
{
    public record UpdateSneakerCommand(
        Guid SneakerId,
        string UserId,
        JsonPatchDocument<Sneaker> JsonPatchDocument) : IRequest<ErrorOr<Updated>>;
}
