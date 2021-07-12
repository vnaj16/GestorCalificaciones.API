using GestorCalificaciones.API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Controllers
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
        public GestorCalificacionesContext gestorCalificacionesContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, GestorCalificacionesContext gestorCalificacionesContext)
        {
            _logger = logger;
            this.gestorCalificacionesContext = gestorCalificacionesContext;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var x = gestorCalificacionesContext.CursoEvaluaciones.ToList();
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
