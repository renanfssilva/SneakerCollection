using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using SneakerCollection.API.Common.Errors;
using SneakerCollection.API.Common.Mapping;

namespace SneakerCollection.API
{
    public static class PresentationExtensions
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwagger();

            services.AddMappings();

            // ProblemDetailsFactory overrided to add extensions
            services.AddSingleton<ProblemDetailsFactory, SneakerCollectionProblemDetailsFactory>();

            return services;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Sneakers API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }
    }
}
