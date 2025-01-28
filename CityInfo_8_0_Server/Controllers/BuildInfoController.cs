using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityInfo_8_0_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildInfoController : ControllerBase
    {
        private readonly IWebHostEnvironment _currentEnvironment;

        public BuildInfoController(IWebHostEnvironment CurrentEnvironment)
        {
            this._currentEnvironment = CurrentEnvironment;
        }
        // GET: api/<BuildInfoController>
        [HttpGet]
        [Route("current-environment")]
        public IActionResult GetBuildConfiguration()
        {
            return Ok(_currentEnvironment.EnvironmentName);
        }

        [HttpGet]
        [Route("is-development")]
        public IActionResult IsDevelopment()
        {
            var isDevelopment = _currentEnvironment.IsDevelopment();
            return Ok(new { IsDevelopment = isDevelopment });
        }

        [HttpGet]
        [Route("is-production")]
        public IActionResult IsProduction()
        {
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
                IsProduction = _currentEnvironment.IsProduction()
            };
            return Ok(config);
        }
    }
}
