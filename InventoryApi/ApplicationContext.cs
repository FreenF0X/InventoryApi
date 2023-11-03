using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Collections;
using InventoryApi.Entityes;

namespace ConsoleApp1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Element> Elements { get; set; }

        public ApplicationContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Structures;Username=User;Password=1");
        }

        public void RecreateDb()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
