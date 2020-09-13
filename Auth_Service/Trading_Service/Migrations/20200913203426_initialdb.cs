using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trading_Service.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblPurchase",
                columns: table => new
                {
                    PurchaseId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PurchaseTimestamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    StockPrice = table.Column<decimal>(type: "money", nullable: false),
                    StockQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPurchase", x => x.PurchaseId);
                });

            migrationBuilder.CreateTable(
                name: "TblStockCompany",
                columns: table => new
                {
                    CompanyId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CompanyAcronym = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    StockPrice = table.Column<decimal>(type: "money", nullable: false),
                    RegistrationTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblStockCompany", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "TblStocks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblStocks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TblStockCompany",
                columns: new[] { "CompanyId", "CompanyAcronym", "CompanyName", "RegistrationTimeStamp", "StockPrice" },
                values: new object[] { 1000L, "GTB", "Guaranty Trust Bank", new DateTime(2020, 9, 13, 21, 34, 26, 96, DateTimeKind.Local).AddTicks(2504), 20.58m });

            migrationBuilder.InsertData(
                table: "TblStockCompany",
                columns: new[] { "CompanyId", "CompanyAcronym", "CompanyName", "RegistrationTimeStamp", "StockPrice" },
                values: new object[] { 1001L, "Stanbic", "Stanbic IBTC Bank", new DateTime(2020, 9, 13, 21, 34, 26, 98, DateTimeKind.Local).AddTicks(6613), 100.42m });

            migrationBuilder.InsertData(
                table: "TblStockCompany",
                columns: new[] { "CompanyId", "CompanyAcronym", "CompanyName", "RegistrationTimeStamp", "StockPrice" },
                values: new object[] { 1002L, "Unilever", "Unilever Plc", new DateTime(2020, 9, 13, 21, 34, 26, 98, DateTimeKind.Local).AddTicks(6711), 140.62m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblPurchase");

            migrationBuilder.DropTable(
                name: "TblStockCompany");

            migrationBuilder.DropTable(
                name: "TblStocks");
        }
    }
}
