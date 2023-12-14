using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace InventoryApi
{
    public class Startup
    {
        string connectionString;
        public Startup(string connString)
        {
            connectionString = connString;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.Authority = "http://tmp.doker.ru:8080/realms/Test2";
            //        options.Audience = "account";
            //        options.RequireHttpsMetadata = false;
            //    });
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            services.AddScoped<IRepository>(servises =>
            {
                return new EfCoreRepository(connectionString);
            });
            services.AddSwaggerGen();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
