using Trading_Service.Domain.Models;
using Trading_Service.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading_Service.Persistence.EntityConfigurations
{
    public class TblPurchaseConfiguration : IEntityTypeConfiguration<TblPurchase>
    {
    public void Configure(EntityTypeBuilder<TblPurchase> builder)
        {
            builder.HasKey(e => e.PurchaseId);
            builder.Property(e => e.PurchaseId).ValueGeneratedOnAdd();
            builder.Property(e => e.CompanyId).HasColumnType("bigint");
            builder.Property(e => e.UserId).HasColumnType("bigint");
            builder.Property(e => e.StockPrice).HasColumnType("money");
            builder.Property(e => e.StockQuantity).HasColumnType("decimal(18,2)");
            builder.Property(e => e.Cost).HasColumnType("money");
            builder.Property(e => e.PurchaseTimestamp).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

        }
    }
}
