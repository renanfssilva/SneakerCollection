using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
