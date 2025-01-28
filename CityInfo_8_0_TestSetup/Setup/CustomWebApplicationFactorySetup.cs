using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo_8_0_TestSetup.Setup
{
    public class CustomWebApplicationFactorySetup<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, configBuilder) =>
            {
                configBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                         .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                         .AddEnvironmentVariables();

                var config = configBuilder.Build();
                var environment = config["ASPNETCORE_ENVIRONMENT"] ?? "Development";

                // Set the environment based on the ASPNETCORE_ENVIRONMENT variable
                context.HostingEnvironment.EnvironmentName = environment;
            });

            builder.ConfigureServices(services =>
            {
                // Additional configuration for services if needed
            });
        }

        public void CheatMethod(IWebHostBuilder builder)
        {
            ConfigureWebHost(builder);
        }
    }
}
