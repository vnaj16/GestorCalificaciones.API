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

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
        public CursoDTO Create(CursoDTO obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
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
                    //Creditos = curso.Creditos,
                    //nCampos = curso.nCampos,
                    //PromedioFinal = curso.PromedioFinal,
                    //PromedioTemporal = curso.PromedioTemporal,
                    //Vez = curso.Vez
                };

                list.Add(tempCurso);
            }
            return list;
        }

        public CursoDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CursoDTO Update(CursoDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
