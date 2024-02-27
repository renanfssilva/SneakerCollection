using Mapster;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using SneakerCollection.Application.Sneakers.Commands.CreateSneaker;
using SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;
using SneakerCollection.Application.Sneakers.Commands.UpdateSneaker;
using SneakerCollection.Application.Sneakers.Commands.UpsertSneaker;
using SneakerCollection.Application.Sneakers.Queries.GetSneaker;
using SneakerCollection.Application.Sneakers.Queries.ListSneakers;
using SneakerCollection.Contracts.Sneakers;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;

namespace SneakerCollection.API.Common.Mapping
{
    public class SneakerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            RegisterCreateSneaker(config);
            RegisterQuerySneaker(config);
            RegisterDeleteSneaker(config);
            RegisterUpsertSneaker(config);
            RegisterUpdateSneaker(config);
        }

        private void RegisterCreateSneaker(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateSneakerRequest Request, string UserId), CreateSneakerCommand>()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.SizeUS, src => src.Request.SizeUS);

            config.NewConfig<Sneaker, SneakerResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.SizeUS, src => src.SizeUS);

            config.NewConfig<Price, PriceResponse>()
                .Map(dest => dest.Amount, src => src.Amount);
        }

        private void RegisterQuerySneaker(TypeAdapterConfig config)
        {
            config.NewConfig<(string UserId, GetSneakersListRequest? Request), ListSneakersQuery>()
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.UserId, src => src.UserId);

            config.NewConfig<(Guid SneakerId, string UserId), GetSneakerQuery>()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.SneakerId, src => src.SneakerId);
        }

        private void RegisterDeleteSneaker(TypeAdapterConfig config)
        {
            config.NewConfig<(Guid SneakerId, string UserId), DeleteSneakerCommand>()
                .Map(dest => dest.SneakerId, src => src.SneakerId)
                .Map(dest => dest.UserId, src => src.UserId);
        }

        private void RegisterUpsertSneaker(TypeAdapterConfig config)
        {
            config.NewConfig<(Guid SneakerId, UpsertSneakerRequest Request, string UserId), UpsertSneakerCommand>()
                .Map(dest => dest.SneakerId, src => src.SneakerId)
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.SizeUS, src => src.Request.SizeUS);
        }

        private void RegisterUpdateSneaker(TypeAdapterConfig config)
        {
            config.NewConfig<JsonPatchDocument<UpdateSneakerRequest>, JsonPatchDocument<Sneaker>>()
                .Map(dest => dest.ContractResolver, src => src.ContractResolver)
                .Map(dest => dest.Operations, src => src.Operations.ConvertAll(opr =>
                new Operation<Sneaker>
                {
                    op = opr.op,
                    path = opr.path,
                    value = opr.value
                }).ToList());

            config.NewConfig<(Guid SneakerId, JsonPatchDocument<UpdateSneakerRequest> Request, string UserId), UpdateSneakerCommand>()
                .Map(dest => dest.SneakerId, src => src.SneakerId)
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.JsonPatchDocument, src => src.Request);
        }
    }
}
