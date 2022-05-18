using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBusProject.Business.Abstract;
using MyBusProject.Business.Concrete;
using MyBusProject.Data.Abstract;
using MyBusProject.Data.Concrete;
using MyBusProject.Data.Concrete.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusProject.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //Data Kýsmý Scop
            services.AddScoped<IBusRepository, EfCoreBusRepository>();
            services.AddScoped<IPassengerRepository, EfCorePassengerRepository>();
            services.AddScoped<IRouteRepository, EfCoreRouteRepository>();
            services.AddScoped<ITicketRepository, EfCoreTicketRepository>();
            services.AddScoped<IVoyageRepository, EfCoreVoyageRepository>();

            //Business kýsmý scop
            services.AddScoped<IBusService, BusManager>();
            services.AddScoped<IPassengerService, PassengerManager>();
            services.AddScoped<IRouteService, RouteManager>();
            services.AddScoped<ITicketService, TicketManager>();
            services.AddScoped<IVoyageService, VoyageManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                SeedDataBase.Seed();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
