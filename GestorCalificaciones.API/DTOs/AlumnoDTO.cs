using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.DTOs
{
    public class AlumnoDTO
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Universidad { get; set; }
        public double? PromedioAcumulado { get; set; }
    }
}
