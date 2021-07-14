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

        public CicloService(ICicloRepository cicloRepository)
        {
            _cicloRepository = cicloRepository;
        }

        public CicloDTO Create(CicloDTO obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CicloDTO> GetAll(int maxRows = 100)
        {
            List<CicloDTO> list = new List<CicloDTO>();
            foreach (var ciclo in _cicloRepository.GetAll(maxRows))
            {
                var tempCiclo = new CicloDTO()
                {
                    IdCiclo = ciclo.IdCiclo,
                    //nCursos = ciclo.nCursos,
                    Periodo = ciclo.Periodo,
                    //PromedioBeca = ciclo.PromedioBeca,
                    //PromedioFinal = ciclo.PromedioFinal
                };

                list.Add(tempCiclo);
            }
            return list;
        }

        public CicloDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CicloDTO Update(CicloDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
