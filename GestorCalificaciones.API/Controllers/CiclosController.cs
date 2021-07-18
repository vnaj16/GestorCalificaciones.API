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
    public class CiclosController : ControllerBase
    {
        private readonly ICicloService _cicloService;
        public CiclosController(ICicloService cicloService)
        {
            _cicloService = cicloService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CicloDTO>> GetCiclos()
        {
            try
            {
                return Ok(_cicloService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<DetailCicloDTO> GetCiclo(int id)
        {
            try
            {
                return Ok(_cicloService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<CreateCicloDTO> CreateCiclo(CreateCicloDTO createCicloDTO)
        {
            try
            {
                return Ok(_cicloService.Create(createCicloDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<CreateCicloDTO> UpdateCiclo(int id, CreateCicloDTO ciclo)
        {
            try
            {
                ciclo.IdCiclo = id;
                return Ok(_cicloService.Update(ciclo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/cursos")]
        public ActionResult<IEnumerable<CursoDTO>> GetCursos(int id)
        {
            try
            {
                return Ok(_cicloService.GetCursosByCicloId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
