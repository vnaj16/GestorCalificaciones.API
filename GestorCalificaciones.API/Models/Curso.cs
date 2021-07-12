using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Models
{
    [Table("Curso")]
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int? Creditos { get; set; }
        public int? nCampos { get; set; }
        public double? PromedioTemporal { get; set; }
        public double? PromedioFinal { get; set; }
        public int Vez { get; set; }


        public int IdCiclo { get; set; }
        [ForeignKey("IdCiclo")]
        public Ciclo Ciclo { get; set; }
    }
}
