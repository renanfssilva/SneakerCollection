using ErrorOr;
using MediatR;
using SneakerCollection.Application.Authentication.Common;

namespace SneakerCollection.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
