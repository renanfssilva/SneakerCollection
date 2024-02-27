using ErrorOr;
using MediatR;
using SneakerCollection.Contracts.Common;
using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Application.Sneakers.Queries.ListSneakers
{
    public record ListSneakersQuery(
        string UserId,
        string? SearchTerm,
        string? SortColumn,
        string? SortOrder,
        int Page,
        int PageSize) : IRequest<ErrorOr<PagedList<Sneaker>>>;
}
