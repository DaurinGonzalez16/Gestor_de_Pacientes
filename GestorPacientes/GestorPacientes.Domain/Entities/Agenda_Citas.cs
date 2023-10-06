using GestorPacientes.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestorPacientes.Domain.Entities
{
    public class Agenda_Citas: BaseEntity
    {
        /*NOMBRES DE LA COLUMNAS DE MI TABLA PACIENTES EN LA BASE DE DATOS*/
        [Key]
        public int? Id_citas { get; set; }
        public int? id_paciente { get; set; }
        public string Nombre_paciente { get; set; }
        public DateTime Fecha_cita { get; set; }
        public int? Precio { get; set; }
        public bool Asistio { get; set; }

        //el tipo bit en sql server viene siendo bool en c#
    }
}
