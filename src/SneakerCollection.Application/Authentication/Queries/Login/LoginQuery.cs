using ErrorOr;
using MediatR;
using SneakerCollection.Application.Authentication.Common;

namespace SneakerCollection.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
