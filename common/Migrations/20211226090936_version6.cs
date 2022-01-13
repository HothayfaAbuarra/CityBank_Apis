using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Customer_id", "BankAccounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("Customer_id", "BankAccounts", nullable: false);

        }
    }
}
