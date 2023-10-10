using GestorPacientes.Application.Contract;
using GestorPacientes.Application.Service;
using GestorPacientes.Infraestructure.Interfaces;
using GestorPacientes.Infraestructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.loc.Dependency
{
    public static class PacientesDependecy
    {

        public static void AddPacienteDependency(this IServiceCollection services)
        {
            services.AddScoped<IPacientesRepository, PacienteRepository>();
            services.AddTransient<IPacientesServices, PacientesService>();
        }

    }
}
