using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version53 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Customers_Customerscuid",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "customerID",
                table: "BankAccounts");

            migrationBuilder.AlterColumn<Guid>(
                name: "Customerscuid",
                table: "BankAccounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Customers_Customerscuid",
                table: "BankAccounts",
                column: "Customerscuid",
                principalTable: "Customers",
                principalColumn: "cuid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Customers_Customerscuid",
                table: "BankAccounts");

            migrationBuilder.AlterColumn<Guid>(
                name: "Customerscuid",
                table: "BankAccounts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "customerID",
                table: "BankAccounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Customers_Customerscuid",
                table: "BankAccounts",
                column: "Customerscuid",
                principalTable: "Customers",
                principalColumn: "cuid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
