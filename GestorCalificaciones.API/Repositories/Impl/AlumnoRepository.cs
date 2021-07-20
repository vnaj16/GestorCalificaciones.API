using GestorCalificaciones.API.Context;
using GestorCalificaciones.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Repositories.Impl
{
    public class AlumnoRepository : BaseRepository, IAlumnoRepository
    {
        public AlumnoRepository(GestorCalificacionesContext context) : base(context)
        {

        }

        public Alumno Create(Alumno obj)
        {
            _context.Alumnos.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var alumnoDB = _context.Alumnos.Find(id);
            if (alumnoDB is null)
            {
                return false;
            }
            _context.Alumnos.Remove(alumnoDB);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Alumno> GetAll(int maxRows = 0)
        {
            if (maxRows == 0)
            {
                return _context.Alumnos.ToList();
            }
            return _context.Alumnos.Take(maxRows).ToList();
        }

        public Alumno GetById(int id)
        {
            var alumnoDB = _context.Alumnos.Find(id);
            if (alumnoDB is null)
            {
                return null;
            }
            return alumnoDB;
        }

        public Alumno Update(Alumno obj)
        {
            var alumnoDB = _context.Alumnos.Find(obj.IdAlumno);
            if (alumnoDB is null)
            {
                throw new Exception($"Alumno with id {obj.IdAlumno} doesnt exits");
            }

            alumnoDB.Nombre = obj.Nombre;
            alumnoDB.PromedioAcumulado = obj.PromedioAcumulado;
            alumnoDB.Universidad = obj.Universidad;

            _context.SaveChanges();

            return obj;
        }
    }
}
