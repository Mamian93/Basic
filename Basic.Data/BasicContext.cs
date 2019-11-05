using Basic.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Data
{
    public class BasicContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-G67V9RV\SQLEXPRESS;Database=BasicDb;Trusted_Connection=True;");
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
