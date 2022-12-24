using Frederik.TariffComparison.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application.Features.TariffCalculation
{
    public interface ICalculateTariffHandler
    {
        Task<List<TariffCalculationDto>> Calculate(GetConsumptionRequest getConsumptionDto);
    }
}
