using GestorPacientes.Application.Contract;
using GestorPacientes.Application.Dtos.Agenda_Citas;
using GestorPacientes.Application.Dtos.Pacientes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorPacientes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {

        private readonly IAgendaCitaService _services;

        public AgendaController(IAgendaCitaService services)
        {
            _services = services;
        }

        [HttpGet("GetCitas")]
        public IActionResult Get()
        {
            var result = this._services.Get();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this._services.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] AgendaCitaAddDto agendaAddDto)
        {
            var result = this._services.Save(agendaAddDto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] AgendaCitaUpdateDto agendaupdateDto)
        {
            var result = this._services.Update(agendaupdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            // Crear un objeto PacientesRemoveDto con el ID proporcionado
            var removeDto = new AgendaCitaRemoveDto { Id_citas = id };

            var result = this._services.Remove(removeDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
