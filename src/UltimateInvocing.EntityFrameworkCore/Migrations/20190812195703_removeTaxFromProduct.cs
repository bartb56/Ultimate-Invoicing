using Microsoft.EntityFrameworkCore.Migrations;

namespace UltimateInvocing.Migrations
{
    public partial class removeTaxFromProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tax",
                table: "Products",
                maxLength: 15,
                nullable: false,
                defaultValue: 0);
        }
    }
}
