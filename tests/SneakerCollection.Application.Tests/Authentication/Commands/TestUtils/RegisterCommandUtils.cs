using SneakerCollection.Application.Authentication.Commands.Register;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Application.Tests.Authentication.Commands.TestUtils
{
    public class RegisterCommandUtils
    {
        public static RegisterCommand RegisterCommand(string? firstName = null, string? lastName = null, string? email = null, string? password = null)
        {
            return new RegisterCommand(
                        firstName ?? Constants.User.FirstName,
                        lastName ?? Constants.User.LastName,
                        email ?? Constants.User.Email,
                        password ?? Constants.User.Password);
        }
    }
}
