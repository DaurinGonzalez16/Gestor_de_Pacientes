using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Application.Dtos.Agenda_Citas
{
    public class AgendaCitaDto : DtoBase
    {
        public int? Id_citas { get; set; }
        public int? id_paciente { get; set; }
        public string Nombre_paciente { get; set; }
        public DateTime Fecha_cita { get; set; }
        public int? Precio { get; set; }
        public bool Asistio { get; set; }
    }
}
