using GestorCalificaciones.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Repositories
{
    public interface ICicloRepository : IRepository<Ciclo>
    {
        public Ciclo GetCicloByPeriod(string period);
    }
}
