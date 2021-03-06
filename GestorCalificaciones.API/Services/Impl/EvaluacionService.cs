using GestorCalificaciones.API.DTOs;
using GestorCalificaciones.API.Models;
using GestorCalificaciones.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Services.Impl
{
    public class EvaluacionService : IEvaluacionService
    {
        public IEvaluacionRepository _evaluacionRepository { get; set; }
        public ICursoEvaluacionRepository _cursoEvaluacionRepository { get; set; }

        public ICursoService _cursoService { get; set; }


        public EvaluacionService(IEvaluacionRepository evaluacionRepository, ICursoEvaluacionRepository cursoEvaluacionRepository, ICursoService cursoService)
        {
            _evaluacionRepository = evaluacionRepository;
            _cursoEvaluacionRepository = cursoEvaluacionRepository;
            _cursoService = cursoService;
        }

        public EvaluacionDTO Create(EvaluacionDTO obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EvaluacionDTO> GetAll(int maxRows = 100)
        {
            List<EvaluacionDTO> list = new List<EvaluacionDTO>();

            foreach (var item in _evaluacionRepository.GetAll())
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

        public EvaluacionDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CursoEvaluacionDTO> GetEvaluacionesInfoByCurso(int idCurso)
        {
            var listCursoEvaluacion = _cursoEvaluacionRepository.GetEvaluacionesByCurso(idCurso);
            var list = new List<CursoEvaluacionDTO>();

            foreach (var item in listCursoEvaluacion)
            {
                CursoEvaluacionDTO temp = new CursoEvaluacionDTO()
                {
                    Descripcion = item.Evaluacion.Descripcion,
                    IdCurso = idCurso,
                    IdCursoEvaluacion = item.IdCursoEvaluacion,
                    IdEvaluacion = item.IdEvaluacion,
                    Nota = item.Nota,
                    Numero = item.Evaluacion.Numero,
                    Peso = item.Peso,
                    Rellenado = item.Rellenado,
                    Tipo = item.Evaluacion.Tipo
                };

                list.Add(temp);
            }

            return list;
        }

        public EvaluacionDTO Update(EvaluacionDTO obj)
        {
            throw new NotImplementedException();
        }

        public CreateCursoEvaluacionDTO CreateCursoEvaluacion(CreateCursoEvaluacionDTO createCursoEvaluacion)
        { //TODO: Falta validar que no se exceda el 100% y tal
            CursoEvaluacion newObj = new CursoEvaluacion()
            {
                IdCurso = createCursoEvaluacion.IdCurso,
                IdEvaluacion = createCursoEvaluacion.IdEvaluacion,
                Nota = null,
                Peso = createCursoEvaluacion.Peso,
                Rellenado = false
            };

            var objDB = _cursoEvaluacionRepository.Create(newObj);

            createCursoEvaluacion.IdCursoEvaluacion = objDB.IdCursoEvaluacion;

            return createCursoEvaluacion;
        }

        public CreateCursoEvaluacionDTO UpdateGrade(CreateCursoEvaluacionDTO obj)
        {
            CursoEvaluacion cursoEvaluacion = new CursoEvaluacion()
            {
                IdCurso = obj.IdCurso,
                IdCursoEvaluacion = obj.IdCursoEvaluacion,
                IdEvaluacion = obj.IdEvaluacion,
                Nota = obj.Nota,
                Peso = obj.Peso,
                Rellenado = true
            };

            _cursoEvaluacionRepository.Update(cursoEvaluacion);
            obj.Rellenado = true;

            //TODO: Actualizar promedio del curso
            _cursoService.UpdateAverage(obj.IdCurso);

            return obj;
        }
    }
}
