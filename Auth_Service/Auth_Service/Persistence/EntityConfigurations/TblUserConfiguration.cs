using Auth_Service.Domain.Models;
using Auth_Service.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Service.Persistence.EntityConfigurations
{
    public class TblUserConfiguration : IEntityTypeConfiguration<TblUser>
    {
    public void Configure(EntityTypeBuilder<TblUser> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.Property(e => e.UserId).ValueGeneratedOnAdd();
            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Firstname)
                .HasColumnName("Firstname")
                .HasMaxLength(50)
                .IsUnicode(false);


            builder.Property(e => e.Lastname)
                .HasColumnName("Lastname")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .HasMaxLength(200)
                .IsUnicode(true);

           

            builder.Property(e => e.RegistrationTimeStamp)
                .HasColumnName("RegistrationTimeStamp")
                .HasColumnType("datetime");
            builder.Property(e => e.WalletBalance)
              .HasColumnName("WalletBalance")
              .HasColumnType("money").HasDefaultValue(0);


            builder.Property(e => e.Status)
                .HasColumnName("Status").HasDefaultValue("Active")
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.HasData(new TblUser
            {
                Email="test@gmail.com",
                Firstname="Temitope",
                Lastname="Oniyide",
                RegistrationTimeStamp=DateTime.Now,
                Password=new Encryptor().EncodePasswordMd5("P@ssw0rd123"),
                UserId=1000
                

            });;
        }
    }
}
