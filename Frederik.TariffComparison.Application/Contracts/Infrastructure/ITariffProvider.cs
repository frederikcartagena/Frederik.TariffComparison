using Frederik.TariffComparison.Application.Models.TariffProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application.Contracts.Infrastructure
{
    public interface ITariffProvider
    {
        Task<List<TariffDetails>> GetTariffProductsDetails();
    }
}
