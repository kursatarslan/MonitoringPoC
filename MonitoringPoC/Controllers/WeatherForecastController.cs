using System;
using System.Collections.Generic;
using System.Linq;
using App.Metrics;
using App.Metrics.Counter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MonitoringPoC.Controllers
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

        public IMetrics _metrics;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMetrics metrics)
        {
            _logger = logger;
            _metrics = metrics;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {


            //Measure.Counter.Increment(
            //new CounterOptions
            //{
            //    Name = "Sample Counter",
            //    MeasurementUnit = Unit.Calls,
            //});

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
