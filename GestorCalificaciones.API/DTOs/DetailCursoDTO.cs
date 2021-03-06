using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.DTOs
{
    public class DetailCursoDTO
    {
        public int IdCurso { get; set; }
        public int IdCiclo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int? Creditos { get; set; }
        public int? nCampos { get; set; }
        public int nCamposRegistrados { get; set; }
        public double? PromedioTemporal { get; set; }
        public double? PromedioFinal { get; set; }
        public int Vez { get; set; }
        public double? PorcentajeCumplido { get; set; }
    }
}
