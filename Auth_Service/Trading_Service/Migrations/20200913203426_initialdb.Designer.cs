﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trading_Service.Persistence;

namespace Trading_Service.Migrations
{
    [DbContext(typeof(StockContext))]
    [Migration("20200913203426_initialdb")]
    partial class initialdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("Trading_Service.Domain.Models.TblPurchase", b =>
                {
                    b.Property<long>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PurchaseTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal>("StockPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("StockQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("PurchaseId");

                    b.ToTable("TblPurchase");
                });

            modelBuilder.Entity("Trading_Service.Domain.Models.TblStockCompany", b =>
                {
                    b.Property<long>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyAcronym")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime>("RegistrationTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal>("StockPrice")
                        .HasColumnType("money");

                    b.HasKey("CompanyId");

                    b.ToTable("TblStockCompany");

                    b.HasData(
                        new
                        {
                            CompanyId = 1000L,
                            CompanyAcronym = "GTB",
                            CompanyName = "Guaranty Trust Bank",
                            RegistrationTimeStamp = new DateTime(2020, 9, 13, 21, 34, 26, 96, DateTimeKind.Local).AddTicks(2504),
                            StockPrice = 20.58m
                        },
                        new
                        {
                            CompanyId = 1001L,
                            CompanyAcronym = "Stanbic",
                            CompanyName = "Stanbic IBTC Bank",
                            RegistrationTimeStamp = new DateTime(2020, 9, 13, 21, 34, 26, 98, DateTimeKind.Local).AddTicks(6613),
                            StockPrice = 100.42m
                        },
                        new
                        {
                            CompanyId = 1002L,
                            CompanyAcronym = "Unilever",
                            CompanyName = "Unilever Plc",
                            RegistrationTimeStamp = new DateTime(2020, 9, 13, 21, 34, 26, 98, DateTimeKind.Local).AddTicks(6711),
                            StockPrice = 140.62m
                        });
                });

            modelBuilder.Entity("Trading_Service.Domain.Models.TblStocks", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Value")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("TblStocks");
                });
#pragma warning restore 612, 618
        }
    }
}
