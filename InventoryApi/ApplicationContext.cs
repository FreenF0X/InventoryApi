﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Collections;
using InventoryApi.Entityes;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace InventoryApi
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }

        //private string connectionString;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //connectionString = conString;
        }

        public void RecreateDb()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
