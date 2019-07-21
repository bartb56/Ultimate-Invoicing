using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UltimateInvocing.Migrations
{
    public partial class InitOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerCompanyName = table.Column<string>(nullable: true),
                    CustomerCompanyEmail = table.Column<string>(nullable: true),
                    CustomerCompanyPhonenumber = table.Column<string>(nullable: true),
                    CustomerCity = table.Column<string>(nullable: true),
                    CustomerStreetAddress = table.Column<string>(nullable: true),
                    CustomerHouseNumber = table.Column<string>(nullable: true),
                    CustomerPostalCode = table.Column<string>(nullable: true),
                    CustomerPhoneNumber = table.Column<string>(nullable: true),
                    CustomerTaxable = table.Column<bool>(nullable: false),
                    CustomerCountryName = table.Column<string>(nullable: true),
                    CustomerProvinceName = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyKVK = table.Column<string>(nullable: true),
                    CompanyIBAN = table.Column<string>(nullable: true),
                    CompanyLogo = table.Column<string>(nullable: true),
                    CompanyBTW = table.Column<string>(nullable: true),
                    CompanyCountryName = table.Column<string>(nullable: true),
                    CompanyProvinceName = table.Column<string>(nullable: true),
                    CompanyCity = table.Column<string>(nullable: true),
                    CompanyStreetAddress = table.Column<string>(nullable: true),
                    CompanyHouseNumber = table.Column<string>(nullable: true),
                    CompanyPostalCode = table.Column<string>(nullable: true),
                    CompanyPhoneNumber = table.Column<string>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: false),
                    PaymentTypeName = table.Column<string>(nullable: true),
                    PaymentTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CompanyId",
                table: "Orders",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentTypeId",
                table: "Orders",
                column: "PaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
