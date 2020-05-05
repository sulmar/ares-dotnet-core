using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Ares.Api.Middlewares;
using Ares.Domain.Models;
using Ares.Domain.Services;
using Ares.Infrastructure.Fakers;
using Ares.Infrastructure.FakeServices;
using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ares.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IMessageSender, SmsMessageSender>();

            services.AddSingleton<Faker<Product>, ProductFaker>();

            services.AddMessage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                Trace.WriteLine($"{context.Request.Method} {context.Request.Path}");

                next();

                Trace.WriteLine($"{context.Response.StatusCode}");

            });



            app.UseMiddleware<LoggerMiddleware>();

            app.UseMiddleware<MessageMiddleware>();

            app.UseLogger();

            app.UseMessage();

            app.Use(async (context, next) =>
            {
                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    next();
                }
                else
                {
                    context.Response.StatusCode = 403;
                    context.Response.WriteAsync("Brak autoryzacji");
                }
            });


            //app.Run(async context => 
            //{
            //    var response = context.Response.WriteAsync("Hello S³awek!");
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello .NET Core!");
                });

                endpoints.MapGet("/api/products", async context =>
                {
                    var productFaker = context.RequestServices.GetRequiredService<Faker<Product>>();

                    var products = productFaker.Generate(10);

                    string json = JsonSerializer.Serialize(products);

                    context.Response.Headers.Append("content-type", new Microsoft.Extensions.Primitives.StringValues("application/json"));
                    await context.Response.WriteAsync(json);

                });
            });

        }
    }
}
