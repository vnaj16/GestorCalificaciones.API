using GestorCalificaciones.API.DTOs;
using GestorCalificaciones.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Services
{
    public interface IEvaluacionService : IService<EvaluacionDTO, EvaluacionDTO, EvaluacionDTO>
    {
        public IEnumerable<CursoEvaluacionDTO> GetEvaluacionesInfoByCurso(int idCurso);
        public CreateCursoEvaluacionDTO CreateCursoEvaluacion(CreateCursoEvaluacionDTO createCursoEvaluacion);
    }
}
