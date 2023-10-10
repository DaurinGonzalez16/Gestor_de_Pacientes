using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Application.Dtos.Pacientes
{
    public class PacientesDto:DtoBase
    {
        public int Idpacientes { get; set; }
        public string Nombre_paciente { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string Direccion { get; set; }
        public string Numero_telefono { get; set; }
        public string Alergias { get; set; }
        public string Diagnostico { get; set; }
    }
}
