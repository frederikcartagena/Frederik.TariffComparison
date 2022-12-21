using Frederik.TariffComparison.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application.Models.TariffProvider
{
    public class TariffFactory
    {
        public Tariff GetTariff(int tariffType)
        {
            switch (tariffType)
            {
                case (int)TariffType.Basic:
                    return new BasicTariff();
                case (int)TariffType.Packaged:
                    return new PackagedTariff();
                default:
                    throw new ApplicationException(string.Format("We need to define the calculations rules for this new tariff type", tariffType    ));
            }

            return new BasicTariff();
        }
    }
}
