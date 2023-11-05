using ConsoleApp1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace InventoryApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = args[0];
            using (var db = new ApplicationContext(ConnectionString))
            {
                db.RecreateDb();
            }

            Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {

                   webBuilder.UseStartup<Startup>(builder => new Startup(ConnectionString));
                   webBuilder.UseUrls("http://*:8000");
               }).Build().Run();
        }
    }
}