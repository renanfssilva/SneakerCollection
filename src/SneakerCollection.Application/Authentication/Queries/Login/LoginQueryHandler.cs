using ErrorOr;
using MediatR;
using SneakerCollection.Application.Authentication.Common;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if ((await userRepository.GetUserByEmailAsync(query.Email)) is not User user
                || user.Password != query.Password)
                return Errors.Authentication.InvalidCredentials;

            var token = jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
