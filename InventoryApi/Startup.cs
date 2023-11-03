using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
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
