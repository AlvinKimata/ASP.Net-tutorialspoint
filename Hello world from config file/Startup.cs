using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

namespace FirstAppDemo
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("AppSettings.json");
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. 
        // Use this method to add services to the container. 
        // For more information on how to configure your application, 
        // visit http://go.microsoft.com/fwlink/?LinkID=398940 
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime.  
        // Use this method to configure the HTTP request pipeline. 
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();
            app.Run(async (context) => {
                var msg = Configuration["message"];
                await context.Response.WriteAsync(msg);
            });
        }

        // Entry point for the application. 
        public static void Main(string[] args) =7gt; WebApplication.Run<Startup>(args); 
   }
}