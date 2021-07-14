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
            _context.Ciclos.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var cicloDB = _context.Ciclos.Find(id);
            if (cicloDB is null)
            {
                return false;
            }
            _context.Ciclos.Remove(cicloDB);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Ciclo> GetAll(int maxRows = 0)
        {
            if (maxRows==0)
            {
                return _context.Ciclos.ToList();
            }
            return _context.Ciclos.Take(maxRows).ToList();
        }

        public Ciclo GetById(int id)
        {
            var cicloDB = _context.Ciclos.Find(id);
            if (cicloDB is null)
            {
                return null;
            }
            return cicloDB;
        }

        public Ciclo Update(Ciclo obj)
        {
            var cicloDB = _context.Ciclos.Find(obj.IdCiclo);
            if (cicloDB is null)
            {
                throw new Exception($"Ciclo with id {obj.IdCiclo} doesnt exits");
            }

            cicloDB.nCursos = obj.nCursos;
            cicloDB.Periodo = obj.Periodo;
            cicloDB.PromedioBeca = obj.PromedioBeca;
            cicloDB.PromedioFinal = obj.PromedioFinal;

            _context.SaveChanges();

            return obj;
        }
    }
}
