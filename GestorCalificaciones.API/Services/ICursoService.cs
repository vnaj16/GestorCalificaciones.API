using GestorCalificaciones.API.DTOs;
using GestorCalificaciones.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Services
{
    public interface ICursoService : IService<CursoDTO, CreateCursoDTO, DetailCursoDTO>
    {
        public IEnumerable<EvaluacionDTO> GetEvaluacionesByCursoId(int idCurso);
        public void UpdateAverage(int idCurso);
    }
}
