using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "bankId",
                table: "BankAccounts",
                type: "uniqueidentifier",
                nullable: false
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bankId",
                table: "BankAccounts");
        }
    }
}
