using Frederik.TariffComparison.Application.Contracts.Infrastructure;
using Frederik.TariffComparison.Application.Models.TariffProvider;
using Newtonsoft.Json;

namespace Frederik.TariffComparison.Infrastructure.Tariff
{
    public class TariffProvider : ITariffProvider
    {
        public async Task<List<TariffDetails>> GetTariffProductsDetails()
        {
            // using await just to simulate an async service method
            return await Task.Run(async () =>
            {
                await Task.Delay(5);
                var MockTariffProviderResponse = @"[{""name"": ""Product A"", ""type"": 1, ""baseCost"": 5, ""additionalKwhCost"": 22},
                                                    {""name"": ""Product B"", ""type"": 2, ""includedKwh"": 4000, ""baseCost"": 800,
                                                    ""additionalKwhCost"": 30},]";

                List<TariffDetails> tariffDetails = JsonConvert.DeserializeObject<List<TariffDetails>>(MockTariffProviderResponse);

                return tariffDetails;
            });
        }
    }
}
