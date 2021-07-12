using GestorCalificaciones.API.Context;
using GestorCalificaciones.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Repositories.Impl
{
    public class CicloRepository : BaseRepository, ICicloRepository
    {
        public CicloRepository(GestorCalificacionesContext context) : base(context)
        {

        }

        public Ciclo Create(Ciclo obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ciclo> GetAll(int maxRows = 0)
        {
            return _context.Ciclos.ToList();
        }

        public Ciclo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Ciclo Update(Ciclo obj)
        {
            throw new NotImplementedException();
        }
    }
}
