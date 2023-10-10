using GestorPacientes.Application.Dtos.Pacientes;
using GestorPacientes.Web.Models;
using GestorPacientes.Web.Models.Responses.Paciente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GestorPacientes.Web.Controllers
{
    public class PacienteController : Controller
    {

        public readonly ApiConfigurePacientes apiConfigure;

        public PacienteController(IConfiguration configuration)
        {
            apiConfigure = new ApiConfigurePacientes();   
        }

        // GET: PacienteController
        public async Task<ActionResult> Index()
        {
            try
            {
                var pacienteslist = await apiConfigure.GetApiResponseAsync<PacienteListResponse>("GetPacientes");
                return View(pacienteslist.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al Obtener las ventas desde la Api: " + ex.Message;
                return View();  
            }
        }

        // GET: PacienteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var PacienteDetails = await apiConfigure.GetApiResponseAsync<PacienteDetailsResponse>($"{id}");
                return View(PacienteDetails.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los detalles del paciente desde el API: " + ex.Message;
                return View();
            }
        }

        // GET: PacienteController/Create
        public async Task<ActionResult> Create()
        {
            try
            {
                var PacienteDetails = await apiConfigure.GetApiResponseAsync<PacienteDetailsResponse>("");
                return View(PacienteDetails.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los datos necesarios para crear un paciente: " + ex.Message;
                return View();
            }
        }

        // POST: PacienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PacientesAddDto paciente)
        {
            try
            {
                var PacienteAdd = await apiConfigure.PostApiRequestAsync<PacienteAddResponse>("Save", paciente);

                if (!PacienteAdd.Success)
                {
                    ViewBag.Message = PacienteAdd.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al guardar el nuevo paciente: " + ex.Message;
                return View();
            }
        }

        // GET: PacienteController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var PacienteDetails = await apiConfigure.GetApiResponseAsync<PacienteDetailsResponse>($"{id}");
                return View(PacienteDetails.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los detalles del paciente para editar: " + ex.Message;
                return View();
            }
        }

        // POST: PacienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PacientesUpdateDto pacienteUpdate)
        {
            try
            {
                var PacienteUpdateResponse = await apiConfigure.PostApiRequestAsync<PacienteUpdateResponse>("Update", pacienteUpdate);

                if (!PacienteUpdateResponse.Success)
                {
                    ViewBag.Message = PacienteUpdateResponse.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al actualizar los datos del Paciente: " + ex.Message;
                return View();
            }
        }

    }
}
