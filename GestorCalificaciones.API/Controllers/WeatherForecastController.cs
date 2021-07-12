using GestorCalificaciones.API.Context;
using GestorCalificaciones.API.Services;
using GestorCalificaciones.API.Services.Impl;
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
        public ICicloService _cicloService;
        public ICursoService _cursoService;
        public IEvaluacionService _evaluacionService { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICicloService cicloService
            , ICursoService cursoService, IEvaluacionService evaluacionService)
        {
            _logger = logger;
            _cicloService = cicloService;
            _cursoService = cursoService;
            _evaluacionService = evaluacionService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var ciclo = _cicloService.GetAll();
            //var curso = _cursoService.GetAll();
            //var evas = _evaluacionService.GetAll();
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
