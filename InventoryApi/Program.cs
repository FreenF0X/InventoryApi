using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace InventoryApi
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {

                   webBuilder.UseStartup<Startup>();
                   webBuilder.UseUrls("http://*:8000");
               }).Build().Run();
        }
    }
}