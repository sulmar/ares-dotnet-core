using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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


            app.Run(async context => 
            {
                var response = context.Response.WriteAsync("Hello S³awek!");
            });

            /*
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello .NET Core!");
                });
            });

    */
        }
    }
}
