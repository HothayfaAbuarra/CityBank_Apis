using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_BankAccounts_Customers", "BankAccounts");
            migrationBuilder.DropColumn(
                name: "Customer_id",
                table: "BankAccounts");

            migrationBuilder.RenameColumn(
                name: "Customer_id",
                table: "Customers",
                newName: "cuid");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cuid",
                table: "Customers",
                newName: "Customer_id");

            migrationBuilder.AddColumn<int>(
                name: "Customer_id",
                table: "BankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
