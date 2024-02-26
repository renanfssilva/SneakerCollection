using ErrorOr;
using MediatR;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Sneakers.Commands.UpsertSneaker
{
    public class UpsertSneakerCommandHandler(ISneakerRepository sneakerRepository) : IRequestHandler<UpsertSneakerCommand, ErrorOr<UpsertSneakerResponse>>
    {
        public async Task<ErrorOr<UpsertSneakerResponse>> Handle(UpsertSneakerCommand command, CancellationToken cancellationToken)
        {
            var createUserIdResult = UserId.Create(command.UserId);

            if (createUserIdResult.IsError)
                return createUserIdResult.Errors;

            var sneakerId = SneakerId.Create(command.SneakerId);

            if (await sneakerRepository.ExistsAsync(sneakerId, createUserIdResult.Value))
                return await UpdateSneaker(command, createUserIdResult, sneakerId);

            return await InsertSneaker(command, createUserIdResult);
        }

        private async Task<ErrorOr<UpsertSneakerResponse>> UpdateSneaker(UpsertSneakerCommand command, ErrorOr<UserId> createUserIdResult, SneakerId sneakerId)
        {
            var sneaker = Sneaker.Update(
                sneakerId,
                command.Name,
                Brand.Create(
                    command.Brand.Name),
                Price.Create(
                    command.Price.Amount,
                    command.Price.Currency),
                command.SizeUS,
                command.Year,
                command.Rate,
                createUserIdResult.Value);

            await sneakerRepository.UpdateAsync(sneaker);

            return new UpsertSneakerResponse(IsNewlyCreated: false, Sneaker: sneaker);
        }

        private async Task<ErrorOr<UpsertSneakerResponse>> InsertSneaker(UpsertSneakerCommand command, ErrorOr<UserId> createUserIdResult)
        {
            var sneaker = Sneaker.Create(
                command.Name,
                Brand.Create(
                    command.Brand.Name),
                Price.Create(
                    command.Price.Amount,
                    command.Price.Currency),
                command.SizeUS,
                command.Year,
                command.Rate,
                createUserIdResult.Value);

            await sneakerRepository.AddAsync(sneaker);

            return new UpsertSneakerResponse(IsNewlyCreated: true, Sneaker: sneaker);
        }
    }
}
