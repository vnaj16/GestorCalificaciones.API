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

        public Ciclo Create(Ciclo obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ciclo> GetAll(int maxRows = 100)
        {
            return _cicloRepository.GetAll();
        }

        public Ciclo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Ciclo Update(Ciclo obj)
        {
            throw new NotImplementedException();
        }
    }
}
