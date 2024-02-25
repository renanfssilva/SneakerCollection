using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SneakerCollection.Application.Sneakers.Commands.CreateSneaker;
using SneakerCollection.Application.Sneakers.Queries;
using SneakerCollection.Contracts.Sneakers;
using System.Security.Claims;

namespace SneakerCollection.API.Controllers
{
    [Route("[controller]")]
    public class SneakersController(IMapper mapper, ISender mediator) : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateSneaker(CreateSneakerRequest request)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command = mapper.Map<CreateSneakerCommand>((request, userId));

            var createSneakerResult = await mediator.Send(command);

            return createSneakerResult.Match(
                sneaker => Ok(mapper.Map<SneakerResponse>(sneaker)),
                errors => Problem(errors));
        }

        [HttpGet]
        public async Task<IActionResult> ListSneakers()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var query = mapper.Map<ListSneakersQuery>(userId);

            var listSneakersResult = await mediator.Send(query);

            return listSneakersResult.Match(
                sneakers => Ok(sneakers.Select(sneaker => mapper.Map<SneakerResponse>(sneaker))),
                errors => Problem(errors));
        }
    }
}
