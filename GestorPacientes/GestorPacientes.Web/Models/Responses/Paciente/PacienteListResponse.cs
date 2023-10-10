namespace GestorPacientes.Web.Models.Responses.Paciente
{
    public class PacienteListResponse:BaseResponse
    {
        public List<PacienteModel> data { get; set; }
    }
}
