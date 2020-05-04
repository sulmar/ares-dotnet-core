using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ares.Domain.Models;
using Ares.Domain.Services;
using Ares.Infrastructure.Fakers;
using Ares.Infrastructure.FakeServices;
using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ares.MVCApi
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
            services.AddScoped<ICustomerRepository, FakeCustomerRepository>();
            services.AddScoped<Faker<Customer>, CustomerFaker>();

            services.AddScoped<IProductRepository, FakeProductRepository>();
            services.AddScoped<Faker<Product>, ProductFaker>();

            services.AddScoped<IMessageSender, SmsMessageSender>();

            services.Configure<FakeOptions>(Configuration.GetSection("FakeOptions"));
            //services.Configure<FakeOptions>(config => new FakeOptions { Quantity = 3 });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string url = Configuration["SmsService:Url"];

            int timeout = int.Parse(Configuration["SmsService:Timeout"]);

            string connectionString = Configuration.GetConnectionString("ErisConnection");

            string name = env.EnvironmentName;


            if (env.IsDevelopment())
            {
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
