using ConsoleApp1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.Extensions.Configuration;
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
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json");

            //Host.CreateDefaultBuilder(args)
            //   .ConfigureWebHostDefaults(webBuilder =>
            //   {
            //       //webBuilder.
            //       webBuilder.UseStartup<Startup>(builder => new Startup());
            //       webBuilder.UseUrls("http://*:8000");
            //   }).Build().Run();
            var app = builder.Build();

        }
    }
}