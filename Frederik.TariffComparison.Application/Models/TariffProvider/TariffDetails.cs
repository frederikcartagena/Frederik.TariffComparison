using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application.Models.TariffProvider
{
    public class TariffDetails
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public double BaseCost { get; set; }
        public double AdditionalKwhCost { get; set; }
        public double? IncludedKwh { get; set; }
    }
}
