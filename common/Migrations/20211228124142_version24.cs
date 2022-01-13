using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class version24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "cuid",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cuid",
                table: "Customers");
        }
    }
}
