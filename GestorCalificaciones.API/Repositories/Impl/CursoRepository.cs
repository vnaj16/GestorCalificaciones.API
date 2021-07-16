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
            _context.Cursos.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var cursoDB = _context.Cursos.Find(id);
            if (cursoDB is null)
            {
                return false;
            }
            _context.Cursos.Remove(cursoDB);
            _context.SaveChanges();
            return true;
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
            var cursoDB = _context.Cursos.Find(id);
            if (cursoDB is null)
            {
                return null;
            }
            return cursoDB;
        }

        public IEnumerable<Curso> GetCursosByCiclo(int id)
        {
            return _context.Cursos.Where(x => x.IdCiclo == id).ToList();
        }

        public Curso Update(Curso obj)
        {
            var cursoDB = _context.Cursos.Find(obj.IdCurso);
            if (cursoDB is null)
            {
                throw new Exception($"Curso with id {obj.IdCiclo} doesnt exits");
            }

            cursoDB.Codigo = obj.Codigo;
            cursoDB.Creditos = obj.Creditos;
            cursoDB.nCampos = obj.nCampos;
            cursoDB.Nombre = obj.Nombre;
            cursoDB.PromedioFinal = obj.PromedioFinal;
            cursoDB.PromedioTemporal = obj.PromedioTemporal;
            cursoDB.Vez = obj.Vez;

            _context.SaveChanges();

            return obj;
        }
    }
}
