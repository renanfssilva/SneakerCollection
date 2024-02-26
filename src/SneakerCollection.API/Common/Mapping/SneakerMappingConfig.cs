using Mapster;
using SneakerCollection.Application.Sneakers.Commands.CreateSneaker;
using SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;
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
            config.NewConfig<(CreateSneakerRequest Request, string UserId), CreateSneakerCommand>()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.SizeUS, src => src.Request.SizeUS);

            config.NewConfig<string, ListSneakersQuery>()
                .MapWith(src => new ListSneakersQuery(src));

            config.NewConfig<Sneaker, SneakerResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.SizeUS, src => src.SizeUS);

            config.NewConfig<Price, PriceResponse>()
                .Map(dest => dest.Amount, src => src.Amount);

            config.NewConfig<(Guid SneakerId, string UserId), DeleteSneakerCommand>()
                .Map(dest => dest.SneakerId, src => src.SneakerId)
                .Map(dest => dest.UserId, src => src.UserId);

        }
    }
}
