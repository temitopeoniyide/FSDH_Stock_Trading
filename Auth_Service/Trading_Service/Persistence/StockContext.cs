using Trading_Service.Domain.Models;
using Trading_Service.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Trading_Service.Persistence
{
    public class StockContext:DbContext
    {
        public StockContext(DbContextOptions<StockContext> options):base(options)
        {

        }
        public DbSet<TblStockCompany> TblStockCompany { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TblPurchaseConfiguration());
            builder.ApplyConfiguration(new TblStockCompanyConfiguration());
            builder.ApplyConfiguration(new TblStockConfiguration());

        }
    }
}
