using GestorCalificaciones.API.DTOs;
using GestorCalificaciones.API.Services;
using GestorCalificaciones.API.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;
        private readonly ILoggerGC _loggerGC;
        public CursosController(ICursoService cursoService, ILoggerGC loggerGC)
        {
            _cursoService = cursoService;
            _loggerGC = loggerGC;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CursoDTO>> GetCursos()
        {
            try
            {
                return Ok(_cursoService.GetAll());
            }
            catch (Exception ex)
            {
                _loggerGC.WriteLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<DetailCursoDTO> GetCurso(int id)
        {
            try
            {
                return Ok(_cursoService.GetById(id));
            }
            catch (Exception ex)
            {
                _loggerGC.WriteLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<CreateCursoDTO> CreateCurso(CreateCursoDTO createCursoDTO)
        {
            try
            {
                return Ok(_cursoService.Create(createCursoDTO));
            }
            catch (Exception ex)
            {
                _loggerGC.WriteLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<CreateCursoDTO> Updatecurso(int id, CreateCursoDTO curso)
        {
            try
            {
                return Ok(_cursoService.Update(curso));
            }
            catch (Exception ex)
            {
                _loggerGC.WriteLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/evaluaciones")]
        public ActionResult<IEnumerable<EvaluacionDTO>> GetEvaluaciones(int id)
        {
            try
            {
                return Ok(_cursoService.GetEvaluacionesByCursoId(id));
            }
            catch (Exception ex)
            {
                _loggerGC.WriteLog(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
