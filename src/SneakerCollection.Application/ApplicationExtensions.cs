using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SneakerCollection.Application.Common.Behaviors;
using System.Reflection;

namespace SneakerCollection.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationExtensions).Assembly));

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
