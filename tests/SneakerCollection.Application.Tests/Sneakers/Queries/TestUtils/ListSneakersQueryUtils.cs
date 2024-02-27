using SneakerCollection.Application.Sneakers.Queries.ListSneakers;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Application.Tests.Sneakers.Queries.TestUtils
{
    public class ListSneakersQueryUtils
    {
        public static ListSneakersQuery GetQuery(string? userId = null, int page = 1, int pageSize = 10, string? searchTerm = null, string? sortColumn = null, string? sortOrder = null)
        {
            return new ListSneakersQuery(
                userId ?? Constants.User.Id.Value.ToString()!,
                searchTerm,
                sortColumn,
                sortOrder,
                page,
                pageSize);
        }
    }
}
