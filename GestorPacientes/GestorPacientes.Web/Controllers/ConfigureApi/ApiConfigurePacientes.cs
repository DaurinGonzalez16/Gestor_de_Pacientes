using GestorPacientes.Infraestructure.Exceptios;
using GestorPacientes.Web.Controllers.ConfigureApi;
using Newtonsoft.Json;
using System.Net.Security;
using System.Text;

namespace GestorPacientes.Web.Controllers
{
    public class ApiConfigurePacientes : ApiConfigureBase
    {
        public ApiConfigurePacientes() : base("http://localhost:5234/api/Paciente/") { }

    }

}
