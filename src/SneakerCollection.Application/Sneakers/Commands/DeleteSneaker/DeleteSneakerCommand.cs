using ErrorOr;
using MediatR;

namespace SneakerCollection.Application.Sneakers.Commands.DeleteSneaker
{
    public record DeleteSneakerCommand(
        Guid SneakerId,
        string UserId) : IRequest<ErrorOr<Deleted>>;
}
