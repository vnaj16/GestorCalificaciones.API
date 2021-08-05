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
    public class EvaluacionesController : ControllerBase
    {
        private readonly IEvaluacionService _evaluacionesService;
        private readonly ILoggerGC _loggerGC;

        public EvaluacionesController(IEvaluacionService evaluacionesService, ILoggerGC loggerGC)
        {
            _evaluacionesService = evaluacionesService;
            _loggerGC = loggerGC;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EvaluacionDTO>> GetEvaluaciones()
        {
            try
            {
                return Ok(_evaluacionesService.GetAll());
            }
            catch (Exception ex)
            {
                _loggerGC.WriteLog(ex);
                return BadRequest(ex.Message);
            }
        }

        #region CursoEvaluacion

        [HttpGet]
        [Route("cursos/{id}")]
        public ActionResult<IEnumerable<CursoEvaluacionDTO>> GetEvaluacionesByCurso(int id)
        {
            try
            {
                return Ok(_evaluacionesService.GetEvaluacionesInfoByCurso(id));
            }
            catch (Exception ex)
            {
                _loggerGC.WriteLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("cursos/{id}")]
        public ActionResult<CreateCursoEvaluacionDTO> CreateCursoEvaluacion(int id, CreateCursoEvaluacionDTO createCursoEvaluacionDTO)
        {
            try
            {
                createCursoEvaluacionDTO.IdCurso = id;
                return Ok(_evaluacionesService.CreateCursoEvaluacion(createCursoEvaluacionDTO));
            }
            catch (Exception ex)
            {
                _loggerGC.WriteLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("cursos/{id}/evaluacion/{idEvaluacion}")]
        public ActionResult<CreateCursoEvaluacionDTO> UpdateCursoEvaluacion(int id, int idEvaluacion, CreateCursoEvaluacionDTO createCursoEvaluacionDTO)
        {
            try
            {
                createCursoEvaluacionDTO.IdCurso = id;
                createCursoEvaluacionDTO.IdCursoEvaluacion = idEvaluacion;
                return Ok(_evaluacionesService.UpdateGrade(createCursoEvaluacionDTO));
            }
            catch (Exception ex)
            {
                _loggerGC.WriteLog(ex);
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
