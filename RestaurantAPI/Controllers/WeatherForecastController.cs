using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("generate")]
        [Route("{min}/{max}")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery]int results, [FromBody]TemperatureRequest request)
        {

            if (results > 0 && request.Min < request.Max)
            {
                var result = _service.Get(results, request.Min, request.Max);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }


        }
    }
}
