using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version52 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "customerID",
                table: "BankAccounts",
                type: "uniqueidentifier",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "customerID",
                table: "BankAccounts");
        }
    }
}
