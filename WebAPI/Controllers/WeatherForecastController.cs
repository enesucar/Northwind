using Microsoft.AspNetCore.Mvc;
using WebAPI.Caching;
using WebAPI.Caching.Redis;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICacheManager _cacheManager;

        public WeatherForecastController(ICacheManager cacheManager, ILogger<WeatherForecastController> logger)
        {
            _cacheManager = cacheManager;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            if (_cacheManager.Contains("weather"))
            {
                //_cacheManager.RemoveByPattern("weath");
                _cacheManager.RemoveByPattern("weat");
                var temp = _cacheManager.Get<WeatherForecast[]>("weather");
                return temp;
            }

            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            _cacheManager.Set("weather", data, 1);
            return data;
        }
    }
}