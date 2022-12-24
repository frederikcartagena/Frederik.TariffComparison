using FluentValidation;
using Frederik.TariffComparison.Application.DTOs.Validators;
using Frederik.TariffComparison.Application.Features.TariffCalculation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ICalculateTariffHandler, CalculateTariffHandler>();
            services.AddValidatorsFromAssemblyContaining<GetConsumptionRequestValidator>();

            return services;
        }
    }
}
