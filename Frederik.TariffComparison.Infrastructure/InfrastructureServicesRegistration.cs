using Frederik.TariffComparison.Application.Contracts.Infrastructure;
using Frederik.TariffComparison.Infrastructure.Tariff;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<ITariffProvider, TariffProvider>();

            return services;
        }
    }
}
