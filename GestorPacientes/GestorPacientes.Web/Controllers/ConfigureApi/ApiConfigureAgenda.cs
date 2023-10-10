using Newtonsoft.Json;
using System.Text;

namespace GestorPacientes.Web.Controllers.ConfigureApi
{
    public class ApiConfigureAgenda : ApiConfigureBase
    {

        public ApiConfigureAgenda() : base("http://localhost:5234/api/Agenda/") { }

    }
}
