using Microsoft.EntityFrameworkCore;
using react_back.Models;
using Pomelo.EntityFrameworkCore.MySql;
using System;

namespace CRUD
{
    public class DBConnection : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=127.0.0.1;Database=db;Uid=root;Pwd=;", new MySqlServerVersion(new Version(8, 0, 23)));
        }
    }
}
