using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading_Service.Domain.Models;

namespace Trading_Service.Persistence.EntityConfigurations
{
    public class TblStockCompanyConfiguration : IEntityTypeConfiguration<TblStockCompany>
    {
        public void Configure(EntityTypeBuilder<TblStockCompany> builder)
        {
            builder.HasKey(e => e.CompanyId);
            builder.Property(e => e.CompanyId).ValueGeneratedOnAdd();
            builder.Property(e => e.CompanyName).IsUnicode(false).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CompanyAcronym).IsUnicode(false).IsRequired().HasMaxLength(100);
            builder.Property(e => e.RegistrationTimeStamp).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(e => e.StockPrice).HasColumnType("money");
            builder.HasData(new TblStockCompany
            {
                CompanyId = 1000,
                CompanyAcronym = "GTB",
                CompanyName = "Guaranty Trust Bank",
                RegistrationTimeStamp = DateTime.Now,
                StockPrice =(decimal) 20.58


            },
            new TblStockCompany
            {
                CompanyId = 1001,
                CompanyAcronym = "Stanbic",
                CompanyName = "Stanbic IBTC Bank",
                RegistrationTimeStamp = DateTime.Now,
                StockPrice = (decimal)100.42

            },
              new TblStockCompany
              {
                  CompanyId = 1002,
                  CompanyAcronym = "Unilever",
                  CompanyName = "Unilever Plc",
                  RegistrationTimeStamp = DateTime.Now,
                  StockPrice = (decimal)140.62


              }
            );

        }
    }
}
