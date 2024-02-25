using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Common.Interfaces.Services;
using SneakerCollection.Infrastructure.Authentication;
using SneakerCollection.Infrastructure.Persistence;
using SneakerCollection.Infrastructure.Persistence.Repositories;
using SneakerCollection.Infrastructure.Services;

namespace SneakerCollection.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
                .AddAuth(configuration)
                .AddPersistance(configuration);

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<SneakerCollectionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISneakerRepository, SneakerRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.ConfigureOptions<JwtBearerTokenValidationConfiguration>()
                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

            return services;
        }
    }
}
