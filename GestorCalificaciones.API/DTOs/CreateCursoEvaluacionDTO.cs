using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.DTOs
{
    public class CreateCursoEvaluacionDTO
    {
        public int IdCursoEvaluacion { get; set; }
        public int IdCurso { get; set; }
        public int IdEvaluacion { get; set; }
        public double? Peso { get; set; }
        public double? Nota { get; set; }
        public bool? Rellenado { get; set; }
    }
}
