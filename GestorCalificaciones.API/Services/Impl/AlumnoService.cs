using GestorCalificaciones.API.DTOs;
using GestorCalificaciones.API.Models;
using GestorCalificaciones.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Services.Impl
{
    public class AlumnoService : IAlumnoService
    {
        public IAlumnoRepository _alumnoRepository { get; set; }

        public AlumnoService(IAlumnoRepository alumnoRepository)
        {
            _alumnoRepository = alumnoRepository;
        }

        public AlumnoDTO Create(AlumnoDTO obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AlumnoDTO> GetAll(int maxRows = 100)
        {
            throw new NotImplementedException();
        }

        public AlumnoDTO GetById(int id=1)
        {
            var temp = _alumnoRepository.GetById(id);
            return new AlumnoDTO()
            {
                IdAlumno = id,
                Nombre = temp.Nombre,
                PromedioAcumulado = temp.PromedioAcumulado,
                Universidad = temp.Universidad
            };
        }

        public AlumnoDTO Update(AlumnoDTO obj)
        {
            Alumno temp = new Alumno()
            {
                IdAlumno = obj.IdAlumno,
                Nombre = obj.Nombre,
                PromedioAcumulado = obj.PromedioAcumulado,
                Universidad = obj.Universidad
            };

            _alumnoRepository.Update(temp);

            return obj;
        }
    }
}
