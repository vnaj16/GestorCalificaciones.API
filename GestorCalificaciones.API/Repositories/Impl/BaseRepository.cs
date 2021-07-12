using GestorCalificaciones.API.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Repositories.Impl
{
    public class BaseRepository
    {
        protected readonly GestorCalificacionesContext _context;

        public BaseRepository(GestorCalificacionesContext context)
        {
            _context = context;
        }
    }
}
