using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading_Service.Domain.IRepositories;
using Trading_Service.Domain.Models;

namespace Trading_Service.Persistence.Repositories
{
    public class PurchaseRepository : Repository<TblPurchase>, IPurchaseRepository
    {
        public PurchaseRepository(StockContext context) : base(context)
        {
        }



        public StockContext DataContext { get { return Context as StockContext; } }
    }
}
