using BlazerDapperCrud.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// ReSharper disable All

namespace BlazerDapperCrud {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();
            services.AddServerSideBlazor(); 
            ///∆ ............. Adding our services .............
            services.AddScoped<IVideoService, VideoService>();
            
            ///∆ ............. SQL-SERVER DATABASE CONNECTION .............
            var SqlServerConnection = new MySqlConnectConfig(
                Configuration.GetConnectionString("SqlDBContext"));
            //∆ : -Adding service
            services.AddSingleton(SqlServerConnection);
            //∆ : -Adds a better detailed debugging if null
            services.AddServerSideBlazor(configure: DetailedError);
        }

        private void DetailedError(CircuitOptions e) {
            e.DetailedErrors = true;
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}