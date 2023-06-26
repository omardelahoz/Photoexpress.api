using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Photoexpress.Domain.Entities;
using Photoexpress.Application.Features.Events.Validators;

namespace Photoexpress.Application
{
    public static class ApplicationServiceRegistration
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(m => m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IValidator<Event>, CreateEventCommandValitor>();
            return services;
        }

    }
}
