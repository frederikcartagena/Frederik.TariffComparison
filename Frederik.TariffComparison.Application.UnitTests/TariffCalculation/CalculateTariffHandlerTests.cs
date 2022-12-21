using Frederik.TariffComparison.Application.Contracts.Infrastructure;
using Frederik.TariffComparison.Application.Features.TariffCalculation;
using Frederik.TariffComparison.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application.UnitTests.TariffCalculation
{
    public class CalculateTariffHandlerTests
    {
        private readonly Mock<ITariffProvider> _tariffProvider;

        public CalculateTariffHandlerTests()
        {
            _tariffProvider = MockTariffProvider.GetTariffProvider();
        }

        [Theory]
        [InlineData(3500, 800, 830)]
        [InlineData(4500, 950, 1050)]
        public async Task ConsumptionTariff_Calculation_IsCorrect(int consumptionKwh, int annualCosts1, int annualCosts2)
        {
            var handler = new CalculateTariffHandler(_tariffProvider.Object);
            var results = await handler.Calculate(consumptionKwh);

            results.Count.ShouldBe(2);

            results[0].TariffName.ShouldBe("Test Product B");
            results[0].TariffType.ShouldBe("Packaged");
            results[0].AnnualCosts.ShouldBe(annualCosts1);

            results[1].TariffName.ShouldBe("Test Product A");
            results[1].TariffType.ShouldBe("Basic");
            results[1].AnnualCosts.ShouldBe(annualCosts2);
        }
    }
}
