using SneakerCollection.Application.Sneakers.Queries.ListSneakers;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Application.Tests.Sneakers.Queries.TestUtils
{
    public class ListSneakersQueryUtils
    {
        public static ListSneakersQuery GetQuery(string? userId = null)
        {
            return new ListSneakersQuery(
                userId ?? Constants.User.Id.Value.ToString()!);
        }
    }
}
