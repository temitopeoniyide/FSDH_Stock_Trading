using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth_Service.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblUser",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    password = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<string>(unicode: false, maxLength: 20, nullable: true, defaultValue: "Active"),
                    WalletBalance = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    RegistrationTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUser", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "TblUser",
                columns: new[] { "UserId", "Email", "Firstname", "Lastname", "password", "RegistrationTimeStamp" },
                values: new object[] { 1000L, "test@gmail.com", "Temitope", "Oniyide", "2gDuvyv7z/ZRGZ9swC3KjA==", new DateTime(2020, 9, 13, 1, 28, 45, 610, DateTimeKind.Local).AddTicks(1401) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblUser");
        }
    }
}
