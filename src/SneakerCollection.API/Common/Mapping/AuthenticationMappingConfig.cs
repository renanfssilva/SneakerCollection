using Mapster;
using SneakerCollection.Application.Authentication.Commands.Register;
using SneakerCollection.Application.Authentication.Common;
using SneakerCollection.Application.Authentication.Queries.Login;
using SneakerCollection.Contracts.Authentication;

namespace SneakerCollection.API.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Id, src => src.User.Id.Value.ToString())
                .Map(dest => dest, src => src.User);
        }
    }
}
