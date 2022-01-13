using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("CustomersCustomer_id", "BankAccounts","Customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("CustomersCustomer_id", "BankAccounts", "Customer_id");
        }
    }
}
