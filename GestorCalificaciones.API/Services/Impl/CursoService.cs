using GestorCalificaciones.API.DTOs;
using GestorCalificaciones.API.Models;
using GestorCalificaciones.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Services.Impl
{
    public class CursoService : ICursoService
    {
        public ICursoRepository _cursoRepository { get; set; }
        public IEvaluacionRepository _evaluacionRepository { get; set; }

        public CursoService(ICursoRepository cursoRepository, IEvaluacionRepository evaluacionRepository)
        {
            _cursoRepository = cursoRepository;
            _evaluacionRepository = evaluacionRepository;
        }
        public IEnumerable<CursoDTO> GetAll(int maxRows = 100)
        {
            List<CursoDTO> list = new List<CursoDTO>();
            foreach (var curso in _cursoRepository.GetAll(maxRows))
            {
                var tempCurso = new CursoDTO()
                {
                    IdCurso = curso.IdCurso,
                    Codigo = curso.Codigo,
                    Nombre = curso.Nombre,
                };

                list.Add(tempCurso);
            }
            return list;
        }

        public DetailCursoDTO GetById(int id)
        {
            var cursoDB = _cursoRepository.GetById(id);
            if (cursoDB is null)
            {
                return null;
            }

            return new DetailCursoDTO()
            {
                IdCurso = id,
                IdCiclo = cursoDB.IdCiclo,
                Codigo = cursoDB.Codigo,
                Creditos = cursoDB.Creditos,
                nCampos = cursoDB.nCampos,
                Nombre = cursoDB.Nombre,
                PromedioFinal = cursoDB.PromedioFinal,
                Vez = cursoDB.Vez,
                PromedioTemporal = cursoDB.PromedioTemporal
            };
        }

        public CreateCursoDTO Create(CreateCursoDTO obj)
        {
            Curso newCurso = new Curso()
            {
                IdCiclo = obj.IdCiclo,
                Codigo = obj.Codigo,
                Creditos = obj.Creditos,
                nCampos = obj.nCampos,
                Nombre = obj.Nombre,
                PromedioFinal = 0,
                Vez = obj.Vez,
                PromedioTemporal = 0
            };

            var cursoDB = _cursoRepository.Create(newCurso);

            obj.IdCurso = cursoDB.IdCurso;

            return obj;
        }

        public CreateCursoDTO Update(CreateCursoDTO obj)
        {
            Curso newCurso = new Curso()
            {
                IdCurso = obj.IdCurso,
                Codigo = obj.Codigo,
                Creditos = obj.Creditos,
                nCampos = obj.nCampos,
                Nombre = obj.Nombre,
                PromedioFinal = obj.PromedioFinal,
                Vez = obj.Vez,
                PromedioTemporal = obj.PromedioTemporal
            };

            var cursoDB = _cursoRepository.Update(newCurso);

            obj.Codigo = cursoDB.Codigo;
            obj.Creditos = cursoDB.Creditos;
            obj.nCampos = cursoDB.nCampos;
            obj.Nombre = cursoDB.Nombre;
            obj.PromedioFinal = cursoDB.PromedioFinal;
            obj.Vez = cursoDB.Vez;
            obj.PromedioTemporal = cursoDB.PromedioTemporal;

            return obj;
        }

        public bool Delete(int id)
        {
            var cursoDB = _cursoRepository.GetById(id);
            if (cursoDB is null)
            {
                return false;
            }
            return _cursoRepository.Delete(id);
        }

        public IEnumerable<EvaluacionDTO> GetEvaluacionesByCursoId(int idCurso)
        {
            List<EvaluacionDTO> list = new List<EvaluacionDTO>();

            foreach (var item in _evaluacionRepository.GetEvaluacionesByCurso(idCurso))
            {
                EvaluacionDTO temp = new EvaluacionDTO()
                {
                    Descripcion = item.Descripcion,
                    IdEvaluacion = item.IdEvaluacion,
                    Numero = item.Numero,
                    Tipo = item.Tipo
                };

                list.Add(temp);
            }

            return list;
        }
    }
}
