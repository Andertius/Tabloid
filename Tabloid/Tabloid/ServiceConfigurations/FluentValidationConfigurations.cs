﻿using FluentValidation;

using MediatR;

using Tabloid.Application.Services;
using Tabloid.Application.Validators.Commands.Albums;

namespace Tabloid.ServiceConfigurations
{
    public static class FluentValidationConfigurations
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            AssemblyScanner.FindValidatorsInAssemblyContaining<AddAlbumCommandValidator>()
                .ForEach(result =>
                {
                    services.AddTransient(result.InterfaceType, result.ValidatorType);
                });

            return services;
        }
    }
}
