using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Sneakers.Commands.UpdateSneaker
{
    public class UpdateSneakerCommandHandler(ISneakerRepository sneakerRepository, IMapper mapper) : IRequestHandler<UpdateSneakerCommand, ErrorOr<Updated>>
    {
        public async Task<ErrorOr<Updated>> Handle(UpdateSneakerCommand command, CancellationToken cancellationToken)
        {
            var createUserIdResult = UserId.Create(command.UserId);

            if (createUserIdResult.IsError)
                return createUserIdResult.Errors;

            var sneakerId = SneakerId.Create(command.SneakerId);
            var existingSneaker = await sneakerRepository.GetByIdAsync(sneakerId, createUserIdResult.Value);

            if (existingSneaker is null)
                return Errors.Sneaker.NotFound;

            var sneakerPatch = mapper.Map<JsonPatchDocument<Sneaker>>(command.JsonPatchDocument);

            await sneakerRepository.PatchAsync(sneakerPatch, existingSneaker);

            return Result.Updated;
        }
    }
}
