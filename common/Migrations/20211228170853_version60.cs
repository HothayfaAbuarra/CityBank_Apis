using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version60 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer_id",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomersCustomer_id",
                table: "BankAccounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Customer_id",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomersCustomer_id",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
