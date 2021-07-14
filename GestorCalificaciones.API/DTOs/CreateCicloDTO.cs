using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.DTOs
{
    public class CreateCicloDTO
    {
        public int IdCiclo { get; set; }
        public string Periodo { get; set; }
        public int? nCursos { get; set; }
        public double? PromedioFinal { get; set; }
        public double? PromedioBeca { get; set; }
    }
}
