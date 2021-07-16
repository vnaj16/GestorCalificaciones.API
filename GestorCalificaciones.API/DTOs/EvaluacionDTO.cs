using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.DTOs
{
    public class EvaluacionDTO
    {
        public int IdEvaluacion { get; set; }
        public string Tipo { get; set; }
        public int? Numero { get; set; }
        public string Descripcion { get; set; }
    }
}
