using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application.Models.TariffProvider
{
    public abstract class Tariff
    {
        public abstract double CalculateConsumption(TariffDetails tariffDetails, int consumptionKwh);
    }
}
