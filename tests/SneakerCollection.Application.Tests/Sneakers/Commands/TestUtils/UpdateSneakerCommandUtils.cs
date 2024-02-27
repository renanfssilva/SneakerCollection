using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json;
using SneakerCollection.Application.Sneakers.Commands.UpdateSneaker;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.Tests.TestUtils.Constants;

namespace SneakerCollection.Application.Tests.Sneakers.Commands.TestUtils
{
    public static class UpdateSneakerCommandUtils
    {
        public static UpdateSneakerCommand UpdateCommand(string? userId = null, Guid? sneakerId = null, string? jsonPatch = null)
        {
            return new UpdateSneakerCommand(
                        sneakerId ?? Constants.Sneaker.Id.Value,
                        userId ?? Constants.User.Id.Value.ToString()!,
                        CreateJsonPatchCommand(jsonPatch));
        }

        public static JsonPatchDocument<Sneaker> CreateJsonPatchCommand(string? jsonPatch = null)
        {
            if (jsonPatch != null)
                return JsonConvert.DeserializeObject<JsonPatchDocument<Sneaker>>(jsonPatch)!;

            var jsonPatchDocument = new JsonPatchDocument<Sneaker>();
            jsonPatchDocument.Operations.Add(
                new Operation<Sneaker>
                {
                    op = "replace",
                    path = "/Name",
                    value = "Air Jordan 1",
                });

            return jsonPatchDocument;
        }
    }
}
