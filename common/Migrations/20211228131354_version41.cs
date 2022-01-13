using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Customers_Customerscuid",
                table: "BankAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_Customerscuid",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "Customerscuid",
                table: "BankAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Customer_id",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomersCustomer_id",
                table: "BankAccounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_CustomersCustomer_id",
                table: "BankAccounts",
                column: "CustomersCustomer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Customers_CustomersCustomer_id",
                table: "BankAccounts",
                column: "CustomersCustomer_id",
                principalTable: "Customers",
                principalColumn: "Customer_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Customers_CustomersCustomer_id",
                table: "BankAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_CustomersCustomer_id",
                table: "BankAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Customer_id",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomersCustomer_id",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Customerscuid",
                table: "BankAccounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "cuid");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_Customerscuid",
                table: "BankAccounts",
                column: "Customerscuid");

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
