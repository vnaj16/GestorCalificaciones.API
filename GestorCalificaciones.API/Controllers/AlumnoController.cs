using GestorCalificaciones.API.DTOs;
using GestorCalificaciones.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoService _alumnoService;
        public AlumnoController(IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
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
                return BadRequest(ex.Message);
            }
        }
    }
}
