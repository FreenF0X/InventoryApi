using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using BuisnessLogic;

namespace InventoryApi
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("TestDB")));
            services.AddScoped<IRepository, EfCoreRepository>();

            services.AddEndpointsApiExplorer();

            services.AddScoped<ProductLogic>();
            services.AddScoped<ProviderLogic>();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            services.AddScoped<IRepository, EfCoreRepository>();
            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(AppMappingProfile));
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
