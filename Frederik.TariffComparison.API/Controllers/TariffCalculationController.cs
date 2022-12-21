using Frederik.TariffComparison.Application.DTOs;
using Frederik.TariffComparison.Application.Features.TariffCalculation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frederik.TariffComparison.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TariffCalculationController : ControllerBase
    {
        private readonly ICalculateTariffHandler _calculateTariffHandler;

        public TariffCalculationController(ICalculateTariffHandler calculateTariffHandler)
        {
            _calculateTariffHandler = calculateTariffHandler;
        }

        [HttpGet("{consumptionKwh}")]
        public async Task<ActionResult<List<TariffCalculationDto>>> Get(int consumptionKwh)
        {
            var calculations = await _calculateTariffHandler.Calculate(consumptionKwh);
            return calculations;
        }
    }
}
