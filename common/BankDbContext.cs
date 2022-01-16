using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace common
{
    public class BankdbContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<BankAccounts> BankAccounts { get; set; }
        public DbSet<Balances> Balances { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<RolesModel> Roles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SD-PC-W10-AABUA;Database=BankSystem;Integrated Security=True");
        }
    }
}
