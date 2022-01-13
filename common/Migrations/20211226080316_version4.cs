using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "cuid",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Customer_id",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Customer_id",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Customer_id");
            

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Customer_id",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Customer_id",
                table: "BankAccounts");

            migrationBuilder.AddColumn<int>(
                name: "cuid",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "cuid");
            migrationBuilder.AddForeignKey("BankAccounts", "FK_BankAccounts_Customers", "Customer_id", "Customers");
        }
    }
}
