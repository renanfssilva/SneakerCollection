using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakerCollection.Application.Authentication.Commands.Register;
using SneakerCollection.Application.Authentication.Queries.Login;
using SneakerCollection.Contracts.Authentication;
using SneakerCollection.Domain.Common.Errors;

namespace SneakerCollection.API.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController(ISender mediator, IMapper mapper) : ApiController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = mapper.Map<RegisterCommand>(request);
            var authResult = await mediator.Send(command);

            return authResult.Match(
                authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = mapper.Map<LoginQuery>(request);
            var authResult = await mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);

            return authResult.Match(
                authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }
    }
}
