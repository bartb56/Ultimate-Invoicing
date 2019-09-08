using Microsoft.EntityFrameworkCore.Migrations;

namespace UltimateInvocing.Migrations
{
    public partial class AddTaxGroupToProductTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        }
    }
}
