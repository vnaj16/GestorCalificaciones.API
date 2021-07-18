using GestorCalificaciones.API.Context;
using GestorCalificaciones.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Repositories.Impl
{
    public class CursoEvaluacionRepository : BaseRepository, ICursoEvaluacionRepository
    {
        public CursoEvaluacionRepository(GestorCalificacionesContext context) : base(context)
        {

        }

        public CursoEvaluacion Create(CursoEvaluacion obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CursoEvaluacion> GetAll(int maxRows = 0)
        {
            throw new NotImplementedException();
        }

        public CursoEvaluacion GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CursoEvaluacion> GetEvaluacionesByCurso(int idCurso)
        {
            return _context.CursoEvaluaciones
                .Include(x => x.Evaluacion)
                .Where(x => x.IdCurso == idCurso)
                .ToList();
        }

        public CursoEvaluacion Update(CursoEvaluacion obj)
        {
            throw new NotImplementedException();
        }
    }
}
