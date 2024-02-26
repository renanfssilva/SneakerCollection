using ErrorOr;
using MediatR;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Sneakers.Queries.GetSneaker
{
    public class GetSneakerQueryHandler(ISneakerRepository sneakerRepository) : IRequestHandler<GetSneakerQuery, ErrorOr<Sneaker>>
    {
        public async Task<ErrorOr<Sneaker>> Handle(GetSneakerQuery query, CancellationToken cancellationToken)
        {
            var createUserIdResult = UserId.Create(query.UserId);

            if (createUserIdResult.IsError)
                return createUserIdResult.Errors;

            var createSneakerIdResult = SneakerId.Create(query.SneakerId);

            var sneaker = await sneakerRepository.GetByIdAsync(createSneakerIdResult, createUserIdResult.Value);

            if (sneaker is null)
                return Errors.Sneaker.NotFound;

            return sneaker;
        }
    }
}