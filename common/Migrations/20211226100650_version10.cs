using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomersCustomer_id",
                table: "BankAccounts",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_CustomersCustomer_id",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "CustomersCustomer_id",
                table: "BankAccounts");
        }
    }
}
