using Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityInfo_8_0_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildInfoController : ControllerBase
    {
        private readonly IWebHostEnvironment _currentEnvironment;
        private ILoggerManager _logger;
        private IServiceCollection _services;
        private IConfiguration _configuration;

        public BuildInfoController(IWebHostEnvironment CurrentEnvironment,
                                   ILoggerManager logger,
                                   IConfiguration configuration)
        {
            this._currentEnvironment = CurrentEnvironment;
            this._logger = logger;
            this._configuration = configuration;
        }

        // GET: api/<BuildInfoController>
        [HttpGet]
        [Route("current-environment")]
        public IActionResult GetBuildConfiguration()
        {
            this._logger.LogInfo($"GetBuildConfiguration action _currentEnvironment.EnvironmentName : {_currentEnvironment.EnvironmentName}");
            return Ok(_currentEnvironment.EnvironmentName);
        }

        [HttpGet]
        [Route("is-development")]
        public IActionResult IsDevelopment()
        {
            this._logger.LogInfo($"IsDevelopment action _currentEnvironment.IsDevelopment() : {_currentEnvironment.IsDevelopment()}");
            var isDevelopment = _currentEnvironment.IsDevelopment();
            return Ok(new { IsDevelopment = isDevelopment });
        }

        [HttpGet]
        [Route("is-production")]
        public IActionResult IsProduction()
        {
            this._logger.LogInfo($"IsProduction action _currentEnvironment.IsProduction() : {_currentEnvironment.IsProduction()}");
            var isProduction = _currentEnvironment.IsProduction();
            return Ok(new { IsProduction = isProduction });
        }

        [HttpGet]
        [Route("configuration")]
        public IActionResult GetConfiguration()
        {
            var config = new
            {
                EnvironmentName = _currentEnvironment.EnvironmentName,
                IsDevelopment = _currentEnvironment.IsDevelopment(),
                IsProduction = _currentEnvironment.IsProduction(),
                connectionString = _configuration["ConnectionStrings:cityInfoDBConnectionString"]
            };

            this._logger.LogInfo($"GetConfiguration action _currentEnvironment.EnvironmentName : {_currentEnvironment.EnvironmentName}");
            this._logger.LogInfo($"GetConfiguration action _currentEnvironment.IsDevelopment() : {_currentEnvironment.IsDevelopment()}");
            this._logger.LogInfo($"GetConfiguration action _currentEnvironment.IsProduction() : {_currentEnvironment.IsProduction()}");
            this._logger.LogInfo($"GetConfiguration action ConnectionString : {config.connectionString}");
            return Ok(config);
        }
    }
}
