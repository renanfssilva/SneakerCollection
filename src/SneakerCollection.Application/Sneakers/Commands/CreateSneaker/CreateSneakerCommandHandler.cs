using ErrorOr;
using MediatR;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Sneakers.Commands.CreateSneaker
{
    public class CreateSneakerCommandHandler(ISneakerRepository sneakerRepository) : IRequestHandler<CreateSneakerCommand, ErrorOr<Sneaker>>
    {
        public async Task<ErrorOr<Sneaker>> Handle(CreateSneakerCommand command, CancellationToken cancellationToken)
        {
            var createUserIdResult = UserId.Create(command.UserId);

            if (createUserIdResult.IsError)
                return createUserIdResult.Errors;

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

            return sneaker;
        }
    }
}
