using Microsoft.AspNetCore.Mvc;
using WebApi.Factory;
using WebApi.Generic;
using WebApi.Generic.Bike;
using WebApi.Generic.Framewok.Dto;

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


            var bike = new BikeComponent();
            bike.GenerateComponent(new BikeDto()
            {
                Id = 10,
                Type = nameof(VehicleTypes.Bike),
                Components = new List<ComponentDto>()
                {
                    new ComponentDto()
                    {
                        Id = 1,
                        Name = nameof(BikeComponentTypes.Seat),
                        NumberOfUnitsNeed = 1
                    },
                    new ComponentDto()
                    {
                        Id = 1,
                        Name = nameof(BikeComponentTypes.Wheel),
                        NumberOfUnitsNeed = 2,
                        HasItems = true,
                        Items = new List<KeyValuePair<string, int>>
                        {
                            new KeyValuePair<string, int>("Frames", 60),
                            new KeyValuePair<string, int>("Tubes", 35)
                        }
                    }
                }
            });
            var createdBiks2 = bike.Build(new List<StockDto>()
            {
                new StockDto()
                {
                    Name = nameof(BikeComponentTypes.Seat),
                    Quantity = 40
                },
                new StockDto()
                {
                    Name = "Frames",
                    Quantity = 40
                },
                new StockDto()
                {
                    Name = "Tubes",
                    Quantity = 20
                },
            });

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
