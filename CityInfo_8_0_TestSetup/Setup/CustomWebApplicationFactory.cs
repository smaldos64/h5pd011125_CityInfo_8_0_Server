using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using LoggerService;
using Microsoft.AspNetCore.Hosting;
using Xunit;

namespace CityInfo_8_0_TestSetup.Setup
{
    public class EnvironmentConfiguration
    {
        public string? EnvironmentName { get; set; }
        public bool IsDevelopment { get; set; }
        public bool IsProduction { get; set; }
    }

    //public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class 
    //public class CustomWebApplicationFactory
    public class CustomWebApplicationFactory : IClassFixture<CustomWebApplicationFactorySetup<Program>>
    {
        private readonly HttpClient _client;
        private EnvironmentConfiguration ?_environmentConfiguration;
        private WebApplicationFactory<Program> _factory;

        private LoggerManager _loggerManager;

        //private CustomWebApplicationFactorySetup<Program> _customWebApplicationFactorySetup;

        //protected override void ConfigureWebHost(IWebHostBuilder builder)
        //{
        //    builder.ConfigureAppConfiguration((context, configBuilder) =>
        //    {
        //        var config = configBuilder.Build();
        //        var environment = config["ASPNETCORE_ENVIRONMENT"] ?? "Development";

        //        // Set the environment based on the ASPNETCORE_ENVIRONMENT variable
        //        context.HostingEnvironment.EnvironmentName = environment;
        //    });

        //    builder.ConfigureServices(services =>
        //    {
        //        // Additional configuration for services if needed
        //    });
        //}

        // You can override methods here if needed for custom setup.
        //public CustomWebApplicationFactory()
        public CustomWebApplicationFactory(CustomWebApplicationFactorySetup<Program> factory)
        {
            //_factory = new WebApplicationFactory<Program>();
            _client = factory.CreateClient();
            _loggerManager = new LoggerManager();

            //_customWebApplicationFactorySetup = new CustomWebApplicationFactorySetup<Program>();
            //_customWebApplicationFactorySetup.CheatMethod(_factory);
        }

        public bool IsDevelopment()
        {
            var response = _client.GetAsync("/api/BuildInfo/configuration").Result;
            response.EnsureSuccessStatusCode();
            _environmentConfiguration = response.Content.ReadFromJsonAsync<EnvironmentConfiguration>().Result;
            //return (_environmentConfiguration?.IsDevelopment == true);
            _loggerManager.LogInfo($"Test Setup : EnvironmentName : {_environmentConfiguration?.EnvironmentName}");
            _loggerManager.LogInfo($"Test Setup : IsDevelopment : {_environmentConfiguration?.IsDevelopment}");
            _loggerManager.LogInfo($"Test Setup : IsProduction : {_environmentConfiguration?.IsProduction}");
            return (_environmentConfiguration?.EnvironmentName == "Development");
            //return false;
        }
    }
}
