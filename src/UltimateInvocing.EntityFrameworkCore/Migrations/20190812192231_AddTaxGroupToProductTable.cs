using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UltimateInvocing.Migrations
{
    public partial class AddTaxGroupToProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TaxGroupId",
                table: "Products",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_TaxGroupId",
                table: "Products",
                column: "TaxGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TaxGroups_TaxGroupId",
                table: "Products",
                column: "TaxGroupId",
                principalTable: "TaxGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TaxGroups_TaxGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TaxGroupId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TaxGroupId",
                table: "Products");
        }
    }
}
