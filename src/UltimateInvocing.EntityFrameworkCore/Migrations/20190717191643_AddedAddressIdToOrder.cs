using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UltimateInvocing.Migrations
{
    public partial class AddedAddressIdToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerAddressId",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAddressId",
                table: "Orders");
        }
    }
}
