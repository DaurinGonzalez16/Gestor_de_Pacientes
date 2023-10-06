using GestorPacientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Infraestructure.Context
{
    public partial class GestorPacientesContext:DbContext
    {
        /*ESTA CLASE ES SIMPLEMENTE PARA LA CONEXION A LA BASE DE DATOS*/
        
        public GestorPacientesContext()
        {
            
        }

        public GestorPacientesContext(DbContextOptions<GestorPacientesContext> options) : base(options) { }

        /*ESTAS SON MIS TABLAS*/
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Agenda_Citas> Agenda_Citas { get; set; }


    }
}
