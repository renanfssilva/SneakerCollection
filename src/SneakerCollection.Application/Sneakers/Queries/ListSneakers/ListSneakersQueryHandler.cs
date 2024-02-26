using ErrorOr;
using MediatR;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate.ValueObjects;
namespace SneakerCollection.Application.Sneakers.Queries.ListSneakers
{
    public class ListSneakersQueryHandler(ISneakerRepository sneakerRepository) : IRequestHandler<ListSneakersQuery, ErrorOr<List<Sneaker>>>
    {
        public async Task<ErrorOr<List<Sneaker>>> Handle(ListSneakersQuery query, CancellationToken cancellationToken)
        {
            var createUserIdResult = UserId.Create(query.UserId);

            if (createUserIdResult.IsError)
                return createUserIdResult.Errors;

            return await sneakerRepository.ListAsync(createUserIdResult.Value);
        }
    }
}