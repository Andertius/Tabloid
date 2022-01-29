using FluentValidation;

using MediatR;

using Tabloid.Application.Services;

namespace Tabloid.ServiceConfigurations
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            throw new NotImplementedException();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //AssemblyScanner.FindValidatorsInAssemblyContaining<AddBookingCommandValidator>()
            //    .ForEach(result => {
            //        services.AddTransient(result.InterfaceType, result.ValidatorType);
            //    });


            return services;
        }
    }
}
