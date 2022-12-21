using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application.DTOs
{
    public class TariffCalculationDto
    {
        public string TariffName { get; set; }
        public string TariffType { get; set; }
        public double AnnualCosts { get; set; }
    }
}
