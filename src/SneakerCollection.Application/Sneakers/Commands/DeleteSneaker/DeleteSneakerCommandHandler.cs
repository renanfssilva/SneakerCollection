using ErrorOr;
using MediatR;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Sneakers.Commands.DeleteSneaker
{
    public class DeleteSneakerCommandHandler(ISneakerRepository sneakerRepository) : IRequestHandler<DeleteSneakerCommand, ErrorOr<Deleted>>
    {
        public async Task<ErrorOr<Deleted>> Handle(DeleteSneakerCommand command, CancellationToken cancellationToken)
        {
            var createUserIdResult = UserId.Create(command.UserId);

            if (createUserIdResult.IsError)
                return createUserIdResult.Errors;

            var sneakerId = SneakerId.Create(command.SneakerId);
            await sneakerRepository.DeleteAsync(sneakerId, createUserIdResult.Value);

            return Result.Deleted;
        }
    }
}
