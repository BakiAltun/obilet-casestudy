using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OBilet.CaseStudy.ApplicationCore.Interfaces;
using OBilet.CaseStudy.ApplicationCore.Validations;
using OBilet.CaseStudy.Infrastructure.Application.Validations;
using OBilet.CaseStudy.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.Infrastructure.MediatR
{
    public static class MediatRExtennsions
    {

        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatRExtennsions));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(new[] { typeof(GetLocationQueryValidator).GetTypeInfo().Assembly });

            });
            return services;
        }


        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            return services;
        }

    }
}
