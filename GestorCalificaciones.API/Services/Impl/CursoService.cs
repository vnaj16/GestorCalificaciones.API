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
        public ICursoEvaluacionRepository _cursoEvaluacionRepository { get; set; }
        public ICicloService _cicloService { get; set; }

        public CursoService(ICursoRepository cursoRepository, IEvaluacionRepository evaluacionRepository, ICursoEvaluacionRepository cursoEvaluacionRepository, ICicloService cicloService)
        {
            _cursoRepository = cursoRepository;
            _evaluacionRepository = evaluacionRepository;
            _cursoEvaluacionRepository = cursoEvaluacionRepository;
            _cicloService = cicloService;
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

            var evaluaciones = _cursoEvaluacionRepository.GetEvaluacionesByCurso(cursoDB.IdCiclo);
            var porcentajeCumplido = 0.0;
            foreach (var eva in evaluaciones.Where(x=>x.Rellenado.Value))
            {
                porcentajeCumplido += eva.Peso.Value;
            }

            var nCamposRegistrados = 6;

            return new DetailCursoDTO()
            {
                IdCurso = id,
                IdCiclo = cursoDB.IdCiclo,
                Codigo = cursoDB.Codigo,
                Creditos = cursoDB.Creditos,
                nCampos = cursoDB.nCampos,
                nCamposRegistrados = nCamposRegistrados,
                Nombre = cursoDB.Nombre,
                PromedioFinal = cursoDB.PromedioFinal,
                Vez = cursoDB.Vez,
                PromedioTemporal = cursoDB.PromedioTemporal,
                PorcentajeCumplido = porcentajeCumplido
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

        public void UpdateAverage(int idCurso)
        {
            Curso curso = _cursoRepository.GetById(idCurso);
            List<CursoEvaluacion> cursoEvaluaciones = _cursoEvaluacionRepository.GetEvaluacionesByCurso(idCurso).ToList();

            double newPromedio = 0;

            foreach (var evaluacion in cursoEvaluaciones)
            {
                newPromedio += (evaluacion.Peso.Value * (evaluacion.Nota.HasValue?evaluacion.Nota.Value:0))/100;
            }

            curso.PromedioTemporal = newPromedio;
            curso.PromedioFinal = (int)Math.Round(curso.PromedioTemporal.Value, MidpointRounding.AwayFromZero);

            _cursoRepository.Update(curso);

            _cicloService.UpdateAverage(curso.IdCiclo);
        }
    }
}
