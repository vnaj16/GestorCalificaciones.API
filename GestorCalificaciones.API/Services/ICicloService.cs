using GestorCalificaciones.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Services
{
    public interface ICicloService : IService<CicloDTO, CreateCicloDTO, DetailCicloDTO>
    {
        public IEnumerable<CursoDTO> GetCursosByCicloId(int idCiclo);
        public void UpdateAverage(int idCiclo);
    }
}
