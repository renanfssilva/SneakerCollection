using SneakerCollection.Domain.Tests.TestUtils.Constants;
using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Infrastructure.Tests.TestUtils
{
    public static class UserUtils
    {
        public static User GetUser(string? firstName = null, string? lastName = null, string? email = null, string? password = null)
            => User.Create(
                firstName ?? Constants.User.FirstName,
                lastName ?? Constants.User.LastName,
                email ?? Constants.User.Email,
                password ?? Constants.User.Password);
    }
}
