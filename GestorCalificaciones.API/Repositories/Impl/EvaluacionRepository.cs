using GestorCalificaciones.API.Context;
using GestorCalificaciones.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Repositories.Impl
{
    public class EvaluacionRepository : BaseRepository, IEvaluacionRepository
    {
        public EvaluacionRepository(GestorCalificacionesContext context) : base(context)
        {

        }
        public Evaluacion Create(Evaluacion obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evaluacion> GetAll(int maxRows = 0)
        {
            throw new NotImplementedException();
        }

        public Evaluacion GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evaluacion> GetEvaluacionesByCurso(int idCurso)
        {
            //TODO: In process...
            return null;//_context.Evaluaciones.Where(x => x. == id).ToList();
        }

        public Evaluacion Update(Evaluacion obj)
        {
            throw new NotImplementedException();
        }
    }
}
