namespace GestorPacientes.Web.Models
{
    public class AgendaCitaModel
    {
        public int? Id_citas { get; set; }
        public int? Id_Pacientes { get; set; }
        public string Nombre_paciente { get; set; }
        public DateTime Fecha_cita { get; set; }
        public int? Precio { get; set; }
        public bool Asistio { get; set; }
    }
}
