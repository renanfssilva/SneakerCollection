using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SneakerCollection.Application.Sneakers.Commands.CreateSneaker;

namespace SneakerCollection.Application.Sneakers.Commands.UpdateSneaker
{
    public record UpdateSneakerCommand(
        Guid SneakerId,
        string UserId,
        JsonPatchDocument<CreateSneakerCommand> JsonPatchDocument) : IRequest<ErrorOr<Updated>>;
}
