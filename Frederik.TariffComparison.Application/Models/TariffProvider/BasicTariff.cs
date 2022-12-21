using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application.Models.TariffProvider
{
    public class BasicTariff : Tariff
    {
        private readonly int MONTHS_IN_A_YEAR = 12;
        public override double CalculateConsumption(TariffDetails tariffDetails, int consumptionKwh)
        {
            double consumption = (tariffDetails.BaseCost * MONTHS_IN_A_YEAR) + ((tariffDetails.AdditionalKwhCost * consumptionKwh) / 100);
            return consumption;
        }
    }
}
