using SneakerCollection.Application.Authentication.Queries.Login;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Application.Tests.Authentication.Queries.TestUtils
{
    public class LoginQueryUtils
    {
        public static LoginQuery GetQuery(string? email = null, string? password = null)
        {
            return new LoginQuery(
                        email ?? Constants.User.Email,
                        password ?? Constants.User.Password);
        }
    }
}
