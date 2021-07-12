using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Models
{
    [Table("Ciclo")]
    public class Ciclo
    {
        [Key]
        public int IdCiclo { get; set; }
        public string Periodo { get; set; }
        public int? nCursos { get; set; }
        public double? PromedioFinal { get; set; }
        public double? PromedioBeca { get; set; }


        public int IdAlumno { get; set; }
        [ForeignKey("IdAlumno")]
        public Alumno Alumno { get; set; }
    }
}
