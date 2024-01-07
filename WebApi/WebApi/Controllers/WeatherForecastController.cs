using Microsoft.AspNetCore.Mvc;
using WebApi.Factory;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        public IBikeFactory bikeFactory { get; }

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IBikeFactory bikeFactory)
        {
            _logger = logger;
            this.bikeFactory = bikeFactory;
        }


        [HttpGet]
        public int CreateBikes()
        {
            var sportBike = new SportBike();
            var createdBikes = sportBike.Build();

            return createdBikes;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var sportBike = new SportBike();
            var createdBikes = sportBike.Build();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
