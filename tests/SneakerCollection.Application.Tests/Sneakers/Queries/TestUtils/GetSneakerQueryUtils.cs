using SneakerCollection.Application.Sneakers.Queries.GetSneaker;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Application.Tests.Sneakers.Queries.TestUtils
{
    public class GetSneakerQueryUtils
    {
        public static GetSneakerQuery GetQuery(Guid? sneakerId = null, string? userId = null)
        {
            return new GetSneakerQuery(
                sneakerId ?? Constants.Sneaker.Id.Value,
                userId ?? Constants.User.Id.Value.ToString()!);
        }
    }
}
