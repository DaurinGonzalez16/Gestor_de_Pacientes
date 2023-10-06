using GestorPacientes.Application.Contract;
using GestorPacientes.Application.Dtos.Pacientes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorPacientes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private readonly IPacientesServices _services;

        public PacienteController(IPacientesServices services)
        {
            _services = services;
        }


        [HttpGet("GetPacientes")]
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
        public IActionResult Post([FromBody] PacientesAddDto _PacientAddDto)
        {
            var result = this._services.Save(_PacientAddDto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] PacientesUpdateDto _PacienteUpdateDtop)
        {
            var result = this._services.Update(_PacienteUpdateDtop);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }


        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            // Crear un objeto PacientesRemoveDto con el ID proporcionado
            var removeDto = new PacientesRemoveDto { Idpacientes = id };

            var result = this._services.Remove(removeDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}
