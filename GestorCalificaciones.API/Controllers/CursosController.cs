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
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;
        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
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
                return BadRequest(ex.Message);
            }
        }
    }
}
