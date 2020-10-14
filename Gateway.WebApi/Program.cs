using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Gateway.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })

         .ConfigureAppConfiguration((hostingContext, config) =>
         {
            config
            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
            //adds the new json file so that the ASP.NET Core 3.1 Application is able to access these settings. 
            .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
         });
    }
}
