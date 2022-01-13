using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Employee_IDD",
                table: "Employees",
                newName: "Employee_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Employee_id",
                table: "Employees",
                newName: "Employee_IDD");
        }
    }
}
