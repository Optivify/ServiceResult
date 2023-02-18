using Microsoft.AspNetCore.Mvc;
using Optivify.ServiceResult.AspNetCore;

namespace Optivify.ServiceResult.Sample.WeatherForcasts
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService weatherForecastService;

        public WeatherForecastController(WeatherForecastService weatherForecastService)
        {
            this.weatherForecastService = weatherForecastService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] string? city)
        {
            var result = this.weatherForecastService.GetByCity(city);
            
            return result.ToActionResult(this);
        }
    }
}