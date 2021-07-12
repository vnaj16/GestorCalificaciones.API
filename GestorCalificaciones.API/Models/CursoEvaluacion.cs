using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestorCalificaciones.API.Models
{
    [Table("CursoEvaluacion")]
    public class CursoEvaluacion
    {
        [Key]
        public int IdCursoEvaluacion { get; set; }
        public double? Peso { get; set; }
        public double? Nota { get; set; }
        public bool? Rellenado { get; set; }


        public int IdCurso { get; set; }
        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }
        public int IdEvaluacion { get; set; }
        [ForeignKey("IdEvaluacion")]
        public Evaluacion Evaluacion { get; set; }
    }
}
