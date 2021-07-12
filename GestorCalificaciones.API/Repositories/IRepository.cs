using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Repositories
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll(int maxRows = 0);
        public T GetById(int id);
        public T Create(T obj);
        public T Update(T obj);
        public bool Delete(int id);
    }
}
