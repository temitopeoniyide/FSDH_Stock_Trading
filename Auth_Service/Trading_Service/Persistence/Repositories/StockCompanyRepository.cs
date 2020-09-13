using Trading_Service.Domain.IRepositories;
using Trading_Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading_Service.Persistence.Repositories
{
    public class StockCompanyRepository : Repository<TblStockCompany>, IStockCompanyRepository
    {
        public StockCompanyRepository(StockContext context) : base(context)
        {
        }



        public StockContext DataContext { get { return Context as StockContext; } }
    }
}
