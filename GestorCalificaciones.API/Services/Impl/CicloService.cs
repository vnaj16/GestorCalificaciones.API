using GestorCalificaciones.API.DTOs;
using GestorCalificaciones.API.Models;
using GestorCalificaciones.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Services.Impl
{
    public class CicloService : ICicloService
    {
        public ICicloRepository _cicloRepository { get; set; }
        public ICursoRepository _cursoRepository { get; set; }

        public CicloService(ICicloRepository cicloRepository, ICursoRepository cursoRepository)
        {
            _cicloRepository = cicloRepository;
            _cursoRepository = cursoRepository;
        }

        public CreateCicloDTO Create(CreateCicloDTO obj)
        {
            Ciclo newCiclo = new Ciclo()
            {
                nCursos = obj.nCursos,
                Periodo = obj.Periodo,
                PromedioBeca = obj.PromedioBeca,
                PromedioFinal = obj.PromedioFinal
            };

            var cicloDB = _cicloRepository.Create(newCiclo);

            obj.IdCiclo = cicloDB.IdCiclo;

            return obj;
        }

        public bool Delete(int id)
        {
            var cicloDB = _cicloRepository.GetById(id);
            if (cicloDB is null)
            {
                return false;
            }
            return _cicloRepository.Delete(id);
        }

        public IEnumerable<CicloDTO> GetAll(int maxRows = 100)
        {
            List<CicloDTO> list = new List<CicloDTO>();
            foreach (var ciclo in _cicloRepository.GetAll(maxRows))
            {
                var tempCiclo = new CicloDTO()
                {
                    IdCiclo = ciclo.IdCiclo,
                    Periodo = ciclo.Periodo,
                };

                list.Add(tempCiclo);
            }
            return list;
        }

        public DetailCicloDTO GetById(int id)
        {
            var cicloDB = _cicloRepository.GetById(id);
            if (cicloDB is null)
            {
                return null;
            }

            return new DetailCicloDTO()
            {
                IdCiclo = id,
                nCursos = cicloDB.nCursos,
                Periodo = cicloDB.Periodo,
                PromedioBeca = cicloDB.PromedioBeca,
                PromedioFinal = cicloDB.PromedioFinal
            };
        }

        public CreateCicloDTO Update(CreateCicloDTO obj)
        {
            Ciclo newCiclo = new Ciclo()
            {
                nCursos = obj.nCursos,
                Periodo = obj.Periodo,
                PromedioBeca = obj.PromedioBeca,
                PromedioFinal = obj.PromedioFinal
            };

            var cicloDB = _cicloRepository.Update(newCiclo);

            obj.nCursos = cicloDB.nCursos;
            obj.Periodo = cicloDB.Periodo;
            obj.PromedioBeca = cicloDB.PromedioBeca;
            obj.PromedioFinal = cicloDB.PromedioFinal;

            return obj;
        }

        public IEnumerable<CursoDTO> GetCursosByCicloId(int idCiclo)
        {
            List<CursoDTO> list = new List<CursoDTO>();
            foreach (var curso in _cursoRepository.GetCursosByCiclo(idCiclo))
            {
                CursoDTO temp = new CursoDTO()
                {
                    IdCurso = curso.IdCurso,
                    Codigo = curso.Codigo,
                    Nombre = curso.Nombre
                };

                list.Add(temp);
            }

            return list;
        }
    }
}
