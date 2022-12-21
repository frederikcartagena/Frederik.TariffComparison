using Frederik.TariffComparison.Application.Contracts.Infrastructure;
using Frederik.TariffComparison.Application.DTOs;
using Frederik.TariffComparison.Application.Enums;
using Frederik.TariffComparison.Application.Models.TariffProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application.Features.TariffCalculation
{
    public class CalculateTariffHandler : ICalculateTariffHandler
    {
        private readonly ITariffProvider _tariffProvider;

        public CalculateTariffHandler(ITariffProvider tariffProvider)
        {
            _tariffProvider = tariffProvider;
        }

        public async Task<List<TariffCalculationDto>> Calculate(int consumptionKwh)
        {
            var tariffDetailsResponse = await _tariffProvider.GetTariffProductsDetails();
            List<TariffCalculationDto> tariffCalculations = new List<TariffCalculationDto>();
            var factory = new TariffFactory();

            foreach (var tariff in tariffDetailsResponse)
            {
                var tariffCalculator = factory.GetTariff(tariff.Type);
                var calculation = new TariffCalculationDto 
                { 
                     TariffType = ((TariffType)tariff.Type).ToString(),
                     TariffName = tariff.Name,
                     AnnualCosts = tariffCalculator.CalculateConsumption(tariff, consumptionKwh)
                };
                tariffCalculations.Add(calculation);
            }

            return tariffCalculations.OrderBy(x => x.AnnualCosts).ToList();
        }
    }
}
