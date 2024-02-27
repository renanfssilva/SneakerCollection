using SneakerCollection.Domain.Tests.TestUtils.Constants;
using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Application.Tests.Authentication.Utils
{
    public class UserUtils
    {
        public static User CreateUser(string? firstName = null, string? lastName = null, string? email = null, string? password = null)
        {
            return User.Create(
                        firstName ?? Constants.User.FirstName,
                        lastName ?? Constants.User.LastName,
                        email ?? Constants.User.Email,
                        password ?? Constants.User.Password);
        }
    }
}
