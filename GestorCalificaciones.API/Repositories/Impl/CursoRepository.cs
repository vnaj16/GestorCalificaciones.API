using GestorCalificaciones.API.Context;
using GestorCalificaciones.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Repositories.Impl
{
    public class CursoRepository : BaseRepository, ICursoRepository
    {
        public CursoRepository(GestorCalificacionesContext context) : base(context)
        {

        }
        public Curso Create(Curso obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Curso> GetAll(int maxRows = 0)
        {
            if (maxRows == 0)
            {
                return _context.Cursos.ToList();
            }
            return _context.Cursos.Take(maxRows).ToList();
        }

        public Curso GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Curso> GetCursosByCiclo(int id)
        {
            return _context.Cursos.Where(x => x.IdCiclo == id).ToList();
        }

        public Curso Update(Curso obj)
        {
            throw new NotImplementedException();
        }
    }
}
