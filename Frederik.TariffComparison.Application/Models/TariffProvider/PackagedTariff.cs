using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application.Models.TariffProvider
{
    public class PackagedTariff : Tariff
    {
        public override double CalculateConsumption(TariffDetails tariffDetails, int consumptionKwh)
        {
            if (consumptionKwh <= tariffDetails.IncludedKwh)
                return tariffDetails.BaseCost;

            double additionalConsumption = consumptionKwh - (tariffDetails.IncludedKwh ?? 0);
            return tariffDetails.BaseCost + ((tariffDetails.AdditionalKwhCost * additionalConsumption) / 100);
        }
    }
}
