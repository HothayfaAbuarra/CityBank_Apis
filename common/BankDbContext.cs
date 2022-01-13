using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace common
{
    public class BankdbContext : DbContext
    {
        public DbSet<CustomersModel> Customers { get; set; }
        public DbSet<BankAccountsModel> BankAccounts { get; set; }
        public DbSet<BalancesModel> Balances { get; set; }
        public DbSet<EmployeesModel> Employees { get; set; }
        public DbSet<DepartmentsModel> Departments { get; set; }
        public DbSet<RolesModel> Roles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SD-PC-W10-AABUA;Database=BankSystem;Integrated Security=True");
        }
    }
}
