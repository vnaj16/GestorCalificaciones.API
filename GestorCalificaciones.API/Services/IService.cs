using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Services
{
    public interface IService<T>
    {
        public IEnumerable<T> GetAll(int maxRows = 100);
        public T GetById(int id);
        public T Create(T obj);
        public T Update(T obj);
        public bool Delete(int id);
    }
}
