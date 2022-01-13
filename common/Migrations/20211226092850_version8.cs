using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
            name: "FK_BankAccounts_Customers_CustomersCustomer_id",
            table: "BankAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccounts_CustomersCustomer_id",
                table: "BankAccounts",
                newName: "IX_BankAccounts_Customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Customers_Customer_id",
                table: "BankAccounts",
                column: "Customer_id",
                principalTable: "Customers",
                principalColumn: "Customer_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
