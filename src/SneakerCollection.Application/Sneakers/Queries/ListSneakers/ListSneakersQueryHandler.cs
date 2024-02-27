using ErrorOr;
using MediatR;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Contracts.Common;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Sneakers.Queries.ListSneakers
{
    public class ListSneakersQueryHandler(ISneakerRepository sneakerRepository) : IRequestHandler<ListSneakersQuery, ErrorOr<PagedList<Sneaker>>>
    {
        public async Task<ErrorOr<PagedList<Sneaker>>> Handle(ListSneakersQuery query, CancellationToken cancellationToken)
        {
            var createUserIdResult = UserId.Create(query.UserId);

            if (createUserIdResult.IsError)
                return createUserIdResult.Errors;

            var sneakers = sneakerRepository.List(createUserIdResult.Value,
                                                  query.SearchTerm,
                                                  query.SortColumn,
                                                  query.SortOrder);

            return await PagedList<Sneaker>.CreateAsync(sneakers,
                                                              query.Page,
                                                              query.PageSize);
        }
    }
}