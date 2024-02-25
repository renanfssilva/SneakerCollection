using ErrorOr;
using MediatR;
using SneakerCollection.Application.Authentication.Common;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if ((await userRepository.GetUserByEmailAsync(command.Email)) is not null)
                return Errors.User.DuplicateEmail;

            var user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);

            await userRepository.AddAsync(user);

            var token = jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
