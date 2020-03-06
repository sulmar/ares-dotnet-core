using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ares.MVCApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration( (hostingContext, options)=>
            {
                string name = hostingContext.HostingEnvironment.EnvironmentName;

                options.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                options.AddJsonFile($"appsettings.{name}.json", optional: true);
                options.AddXmlFile("appsettings.xml", optional: false);
             })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
