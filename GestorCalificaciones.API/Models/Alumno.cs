using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Models
{
    [Table("Alumno")]
    public class Alumno
    {
        [Key]
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Universidad { get; set; }
        public double? PromedioAcumulado { get; set; }
    }
}
