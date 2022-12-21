using Frederik.TariffComparison.Application.Contracts.Infrastructure;
using Frederik.TariffComparison.Application.Models.TariffProvider;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application.UnitTests.Mocks
{
    public static class MockTariffProvider
    {
        public static Mock<ITariffProvider> GetTariffProvider()
        {
            var mockTariffProvider = new Mock<ITariffProvider>();

            var tariffDetails = new List<TariffDetails>
            {
                new TariffDetails
                {
                    Name = "Test Product A",
                    Type = 1,
                    BaseCost = 5,
                    AdditionalKwhCost = 22,
                },
                new TariffDetails
                {
                    Name = "Test Product B",
                    Type = 2,
                    IncludedKwh = 4000,
                    BaseCost = 800,
                    AdditionalKwhCost = 30,
                }
            };

            mockTariffProvider.Setup(x => x.GetTariffProductsDetails()).ReturnsAsync(tariffDetails);

            return mockTariffProvider;
        }
    }
}
