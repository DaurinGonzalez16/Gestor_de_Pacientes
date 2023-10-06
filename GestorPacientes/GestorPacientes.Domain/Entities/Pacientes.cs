using GestorPacientes.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestorPacientes.Domain.Entities
{
    public class Pacientes : BaseEntity
    {
        /*NOMBRES DE LA COLUMNAS DE MI TABLA PACIENTES EN LA BASE DE DATOS*/
        [Key]
        public int? Idpacientes { get; set; }
        public string Nombre_paciente { get; set; }
        public DateTime Fecha_nacimiento{ get; set; }
        public string Direccion { get;set; }
        public string Numero_telefono { get; set; }
        public string Alergias { get; set;}
        public string Diagnostico { get; set; }

    }
}
