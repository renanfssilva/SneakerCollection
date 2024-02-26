using Mapster;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using SneakerCollection.Application.Sneakers.Commands.CreateSneaker;
using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Application.Common.Mapping
{
    public class JsonPatchMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<JsonPatchDocument<CreateSneakerCommand>, JsonPatchDocument<Sneaker>>()
                .Map(dest => dest.ContractResolver, src => src.ContractResolver)
                .Map(dest => dest.Operations, src => src.Operations.ConvertAll(opr =>
                new Operation<Sneaker>
                {
                    op = opr.op,
                    path = opr.path,
                    value = opr.value
                }).ToList());
        }
    }
}
