using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Context
{
    public class GestorCalificacionesContext : DbContext
    {
        public GestorCalificacionesContext(DbContextOptions<GestorCalificacionesContext> options)
            : base(options)
        {
        }
    }
}
