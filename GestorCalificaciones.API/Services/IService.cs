using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Services
{
    public interface IService<T, Q, D>
    {
        public IEnumerable<T> GetAll(int maxRows = 100);
        public D GetById(int id);
        public Q Create(Q obj);
        public Q Update(Q obj);
        public bool Delete(int id);
    }
}
