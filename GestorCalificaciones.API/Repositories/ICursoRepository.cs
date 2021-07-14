using GestorCalificaciones.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Repositories
{
    public interface ICursoRepository : IRepository<Curso>
    {
        public IEnumerable<Curso> GetCursosByCiclo(int id);
    }
}
