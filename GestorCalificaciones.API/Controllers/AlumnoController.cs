using GestorCalificaciones.API.DTOs;
using GestorCalificaciones.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using GestorCalificaciones.API.Utils;

namespace GestorCalificaciones.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoService _alumnoService;
        private readonly ILoggerGC _loggerGC;
        public AlumnoController(IAlumnoService alumnoService, ILoggerGC loggerGC)
        {
            _alumnoService = alumnoService;
            _loggerGC = loggerGC;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<AlumnoDTO> GetAlumno(int id=1)
        {
            try
            {
                return Ok(_alumnoService.GetById(id));
            }
            catch (Exception ex)
            {
                _loggerGC.WriteLog(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
