using Microsoft.EntityFrameworkCore.Migrations;

namespace UltimateInvocing.Migrations
{
    public partial class CustomersEmailTypeReFactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyPhonenumber",
                table: "Customers",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Customers",
                newName: "CustomerMainPhonenumber");

            migrationBuilder.RenameColumn(
                name: "CompanyEmail",
                table: "Customers",
                newName: "CustomerEmail");

            migrationBuilder.AlterColumn<string>(
                name: "HtmlContent",
                table: "EmailTemplates",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "EmailTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EmailTemplates",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerTaxNumber",
                table: "Customers",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "CustomerTaxNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Customers",
                newName: "CompanyPhonenumber");

            migrationBuilder.RenameColumn(
                name: "CustomerMainPhonenumber",
                table: "Customers",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "CustomerEmail",
                table: "Customers",
                newName: "CompanyEmail");

            migrationBuilder.AlterColumn<string>(
                name: "HtmlContent",
                table: "EmailTemplates",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
