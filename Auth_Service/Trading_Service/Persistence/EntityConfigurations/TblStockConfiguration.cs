using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading_Service.Domain.Models;
using Trading_Service.Utilities;

namespace Trading_Service.Persistence.EntityConfigurations
{
    public class TblStockConfiguration : IEntityTypeConfiguration<TblStocks>
    {
        public void Configure(EntityTypeBuilder<TblStocks> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CompanyId).HasColumnType("bigint");
            builder.Property(e => e.UserId).HasColumnType("bigint");
            builder.Property(e => e.Value).HasColumnType("money");

        }
    }
}
