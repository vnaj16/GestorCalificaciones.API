using GestorCalificaciones.API.Repositories;
using GestorCalificaciones.API.Repositories.Impl;
using GestorCalificaciones.API.Services;
using GestorCalificaciones.API.Services.Impl;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Utils
{
    public static class ConfigurationEntitiesExtension
    {
        public static IServiceCollection AddConfigurationEntities(this IServiceCollection services)
        {
            ConfigureServices(services);
            ConfigureRepositories(services);

            return services;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAlumnoService, AlumnoService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<ICicloService, CicloService>();
            services.AddScoped<IEvaluacionService, EvaluacionService>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IAlumnoRepository, AlumnoRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<ICicloRepository, CicloRepository>();
            services.AddScoped<ICursoEvaluacionRepository, CursoEvaluacionRepository>();
            services.AddScoped<IEvaluacionRepository, EvaluacionRepository>();
        }
    }
}
