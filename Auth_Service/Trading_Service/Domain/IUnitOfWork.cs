using Trading_Service.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading_Service.Domain
{
   public interface IUnitOfWork:IDisposable
    {
        IStockCompanyRepository StockCompanies { get; set; }
        IStocksRepository Stocks { get; set; }
        IPurchaseRepository Purchase { get; set; }

        int CommitChanges();
        Task<int> CommitChangesAsync();

    }
}
