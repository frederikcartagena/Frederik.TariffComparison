using Frederik.TariffComparison.Application.Contracts.Infrastructure;
using Frederik.TariffComparison.Application.DTOs;
using Frederik.TariffComparison.Application.DTOs.Validators;
using Frederik.TariffComparison.Application.Enums;
using Frederik.TariffComparison.Application.Exceptions;
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
        private readonly GetConsumptionRequestValidator _getConsumptionRequestValidator;

        public CalculateTariffHandler(ITariffProvider tariffProvider, GetConsumptionRequestValidator getConsumptionRequestValidator)
        {
            _tariffProvider = tariffProvider;
            _getConsumptionRequestValidator = getConsumptionRequestValidator;
        }

        public async Task<List<TariffCalculationDto>> Calculate(GetConsumptionRequest getConsumptionRequest)
        {
            var validationResult = await _getConsumptionRequestValidator.ValidateAsync(getConsumptionRequest);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var tariffDetailsResponse = await _tariffProvider.GetTariffProductsDetails();
            List<TariffCalculationDto> tariffCalculations = MapResultsToDto(getConsumptionRequest, tariffDetailsResponse);

            return tariffCalculations.OrderBy(x => x.AnnualCosts).ToList();
        }

        private List<TariffCalculationDto> MapResultsToDto(GetConsumptionRequest getConsumptionRequest, List<TariffDetails> tariffDetailsResponse)
        {
            List<TariffCalculationDto> tariffCalculations = new List<TariffCalculationDto>();
            var factory = new TariffFactory();

            foreach (var tariff in tariffDetailsResponse)
            {
                var tariffCalculator = factory.GetTariff(tariff.Type);
                var calculation = new TariffCalculationDto
                {
                    TariffType = ((TariffType)tariff.Type).ToString(),
                    TariffName = tariff.Name,
                    AnnualCosts = tariffCalculator.CalculateConsumption(tariff, getConsumptionRequest.ConsumptionKwh)
                };
                tariffCalculations.Add(calculation);
            }

            return tariffCalculations;
        }
    }
}
