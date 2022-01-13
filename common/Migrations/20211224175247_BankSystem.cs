using Microsoft.EntityFrameworkCore.Migrations;

namespace common
{
    public partial class BankSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_identity = table.Column<int>(type: "int", nullable: false),
                    Customer_age = table.Column<int>(type: "int", nullable: false),
                    Customer_phone = table.Column<int>(type: "int", nullable: false),
                    Customer_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_id);
                });

                migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    BankAccount_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_id = table.Column<int>(type: "int", nullable: false),
                    Account_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Account_Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.BankAccount_id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Customers",
                        column: x => x.Customer_id,
                        principalTable: "Customers",
                        principalColumn: "Customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    Balance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    balance = table.Column<double>(type: "float", nullable: false),
                    Account_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Balance_id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Balances",
                        column: x => x.Account_id,
                        principalTable: "BankAccounts",
                        principalColumn: "BankAccount_id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Department_id);
                });
            migrationBuilder.CreateTable(
               name: "Roles",
               columns: table => new
               {
                   Role_id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Role_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Roles", x => x.Role_id);
               });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_id = table.Column<int>(type: "int", nullable: false),
                    Role_id = table.Column<int>(type: "int", nullable: false),
                    Employee_username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments",
                        column: x => x.Department_id,
                        principalTable: "Departments",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Roles",
                        column: x => x.Role_id,
                        principalTable: "Roles",
                        principalColumn: "Role_id",
                        onDelete: ReferentialAction.Cascade);
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
