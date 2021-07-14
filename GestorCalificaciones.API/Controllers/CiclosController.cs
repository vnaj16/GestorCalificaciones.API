﻿using GestorCalificaciones.API.DTOs;
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
            return Ok(_cicloService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<CicloDTO>> GetCiclo(int id)
        {
            return Ok(_cicloService.GetById(id));
        }

        [HttpGet]
        [Route("{id}/cursos")]
        public ActionResult<IEnumerable<CursoDTO>> GetCursos(int id)
        {
            return Ok(_cicloService.GetCursosByCicloId(id));
        }
    }
}