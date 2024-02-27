using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;
using System.Reflection;

namespace SneakerCollection.Application.Sneakers.Commands.UpdateSneaker
{
    public class UpdateSneakerCommandHandler(ISneakerRepository sneakerRepository) : IRequestHandler<UpdateSneakerCommand, ErrorOr<Updated>>
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

            await PatchAsync(command.JsonPatchDocument, existingSneaker);

            return Result.Updated;
        }

        private async Task PatchAsync(JsonPatchDocument<Sneaker> sneakerPatch, Sneaker sneaker)
        {
            ApplyPatchToSneaker(sneakerPatch, sneaker);
            await sneakerRepository.UpdateAsync(sneaker);
        }

        private static void ApplyPatchToSneaker(JsonPatchDocument<Sneaker> patch, Sneaker sneaker)
        {
            // Apply each operation in the patch document for Sneaker private sets
            foreach (var operation in patch.Operations)
            {
                var propertyInfo = typeof(Sneaker).GetProperty(operation.path.Substring(1), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (propertyInfo == null || !propertyInfo.CanWrite)
                    throw new InvalidOperationException($"Property {operation.path} not found or not writable.");

                propertyInfo.SetValue(sneaker, Convert.ChangeType(operation.value, propertyInfo.PropertyType));
            }
        }
    }
}
