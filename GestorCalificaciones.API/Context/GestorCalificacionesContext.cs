using GestorCalificaciones.API.Models;
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

        public DbSet<Ciclo> Ciclos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoEvaluacion> CursoEvaluaciones { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
    }
}
