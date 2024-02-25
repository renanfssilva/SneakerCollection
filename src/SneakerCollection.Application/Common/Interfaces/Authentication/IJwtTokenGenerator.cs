using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
