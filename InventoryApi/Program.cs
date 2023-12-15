
using InventoryApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;
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
            //var builder = WebApplication.CreateBuilder(args);
            //builder.Configuration.AddJsonFile("appsettings.json");
            //builder.Configuration.GetConnectionString("TestDB");
            //builder.WebHost.UseStartup<Startup>();
            //builder.Build().Run();
            Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   //webBuilder.
                   webBuilder.UseStartup<Startup>();
               }).Build().Run();



            //Host.CreateDefaultBuilder(args)
            //   .ConfigureWebHostDefaults(webBuilder =>
            //   {
            //       //webBuilder.
            //       webBuilder.UseStartup<Startup>(builder => new Startup());
            //       //webBuilder.UseUrls("http://*:8000");
            //   }).Build().Run();
        }
    }
}



//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using TMS.Operations;
//using Microsoft.Extensions.Configuration;
//using TMS.DataAccess;
//using TMS.Domain;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Configuration.AddJsonFile("appsettings.json");
//builder.Services.AddDbContext<ApplicationContext>(options =>
//        options.UseNpgsql(builder.Configuration.GetConnectionString("TestDB")));

//builder.Services.AddTransient<IClaimsTransformation, ClaimsTransformer>();
//builder.Services.AddTransient<IRepository, EfCoreRepository>();


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//        .AddJwtBearer(options =>
//        {
//            options.Authority = "http://tmp.doker.ru:8080/realms/Test2";
//            options.Audience = "account";
//            options.RequireHttpsMetadata = false;
//        });

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
