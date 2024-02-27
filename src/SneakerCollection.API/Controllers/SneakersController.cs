using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SneakerCollection.Application.Sneakers.Commands.CreateSneaker;
using SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;
using SneakerCollection.Application.Sneakers.Commands.UpdateSneaker;
using SneakerCollection.Application.Sneakers.Commands.UpsertSneaker;
using SneakerCollection.Application.Sneakers.Queries.GetSneaker;
using SneakerCollection.Application.Sneakers.Queries.ListSneakers;
using SneakerCollection.Contracts.Common;
using SneakerCollection.Contracts.Sneakers;
using SneakerCollection.Domain.SneakerAggregate;
using System.Security.Claims;

namespace SneakerCollection.API.Controllers
{
    [Route("[controller]")]
    public class SneakersController(IMapper mapper, ISender mediator) : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateSneakerAsync([FromBody] CreateSneakerRequest request)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command = mapper.Map<CreateSneakerCommand>((request, userId));

            var createSneakerResult = await mediator.Send(command);

            return createSneakerResult.Match(
                sneaker => CreatedAtGetSneaker(sneaker),
                errors => Problem(errors));
        }

        [HttpGet]
        public async Task<IActionResult> ListSneakersAsync([FromQuery] GetSneakersListRequest request)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var query = mapper.Map<ListSneakersQuery>((userId, request));

            var listSneakersResult = await mediator.Send(query);

            return listSneakersResult.Match(
                sneakers => Ok(new PagedList<SneakerResponse>(mapper.Map<List<SneakerResponse>>(sneakers.Items),
                                                              sneakers.Page,
                                                              sneakers.PageSize,
                                                              sneakers.TotalCount)),
                errors => Problem(errors));
        }

        [HttpGet("{sneakerId:guid}")]
        [ActionName(nameof(GetSneakerAsync))]
        public async Task<IActionResult> GetSneakerAsync([FromRoute] Guid sneakerId)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var query = mapper.Map<GetSneakerQuery>((sneakerId, userId));

            var getSneakerResult = await mediator.Send(query);

            return getSneakerResult.Match(
                sneaker => Ok(mapper.Map<SneakerResponse>(sneaker)),
                errors => Problem(errors));
        }

        [HttpPatch("{sneakerId:guid}")]
        public async Task<IActionResult> PatchSneakerAsync([FromRoute] Guid sneakerId, [FromBody] JsonPatchDocument<UpdateSneakerRequest> request)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command = mapper.Map<UpdateSneakerCommand>((sneakerId, request, userId));

            var updateSneakerResult = await mediator.Send(command);

            return updateSneakerResult.Match(
                updated => NoContent(),
                errors => Problem(errors));
        }

        [HttpPut("{sneakerId:guid}")]
        public async Task<IActionResult> UpsertSneakerAsync([FromRoute] Guid sneakerId, [FromBody] UpsertSneakerRequest request)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command = mapper.Map<UpsertSneakerCommand>((sneakerId, request, userId));

            var upsertSneakerResult = await mediator.Send(command);

            return upsertSneakerResult.Match(
                result => result.IsNewlyCreated ? CreatedAtGetSneaker(result.Sneaker) : NoContent(),
                errors => Problem(errors));
        }

        [HttpDelete("{sneakerId:guid}")]
        public async Task<IActionResult> DeleteSneakerAsync([FromRoute] Guid sneakerId)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command = mapper.Map<DeleteSneakerCommand>((sneakerId, userId));

            var deleteSneakerResult = await mediator.Send(command);

            return deleteSneakerResult.Match(
                deleted => NoContent(),
                errors => Problem(errors));
        }

        private CreatedAtActionResult CreatedAtGetSneaker(Sneaker sneaker)
        {
            return CreatedAtAction(
                actionName: nameof(GetSneakerAsync),
                routeValues: new { sneakerId = sneaker.Id.Value },
                value: mapper.Map<SneakerResponse>(sneaker));
        }
    }
}
