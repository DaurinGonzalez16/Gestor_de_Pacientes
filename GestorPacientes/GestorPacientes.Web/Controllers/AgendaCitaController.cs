using GestorPacientes.Application.Dtos.Agenda_Citas;
using GestorPacientes.Application.Dtos.Pacientes;
using GestorPacientes.Domain.Entities;
using GestorPacientes.Web.Controllers.ConfigureApi;
using GestorPacientes.Web.Models.Responses.Agenda;
using GestorPacientes.Web.Models.Responses.Paciente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorPacientes.Web.Controllers
{
    public class AgendaCitaController : Controller
    {

        private readonly ApiConfigureAgenda apiConfigure;

        public AgendaCitaController(IConfiguration configuration)
        {
            apiConfigure = new ApiConfigureAgenda();
        }

        // GET: AgendaCitaController
        public async Task<ActionResult> Index()
        {
            try
            {
                var AgendaList = await apiConfigure.GetApiResponseAsync<AgendaCitaListResponse>("GetCitas");
                return View(AgendaList.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al Obtener las Citas desde la Api: " + ex.Message;
                return View();
            }
        }

        // GET: AgendaCitaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var AgendaDetails = await apiConfigure.GetApiResponseAsync<AgendaCitaDetailsResponse>($"{id}");
                return View(AgendaDetails.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los detalles de la cita desde el API: " + ex.Message;
                return View();
            }
        }

        // GET: AgendaCitaController/Create
        public async Task<ActionResult> Create()
        {
            try
            {
                var AgendaDetails = await apiConfigure.GetApiResponseAsync<AgendaCitaDetailsResponse>("");
                return View(AgendaDetails.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los datos necesarios para crear una Cita: " + ex.Message;
                return View();
            }
        }

        // POST: AgendaCitaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AgendaCitaAddDto _Agenda)
        {
            try
            {
                var AgendaAdd = await apiConfigure.PostApiRequestAsync<AgendaCitaAddResponse>("Save", _Agenda);

                if (!AgendaAdd.Success)
                {
                    ViewBag.Message = AgendaAdd.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al guardar la nueva cita: " + ex.Message;
                return View();
            }
        }

        // GET: AgendaCitaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var AgendaDetails = await apiConfigure.GetApiResponseAsync<AgendaCitaDetailsResponse>($"{id}");
                return View(AgendaDetails.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al obtener los detalles la cita para editar: " + ex.Message;
                return View();
            }
        }

        // POST: AgendaCitaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AgendaCitaUpdateDto _AgendaUpDto)
        {
            try
            {
                var AgendaUpdateResponse = await apiConfigure.PostApiRequestAsync<AgendaCitaUpdateResponse>("Update", _AgendaUpDto);

                if (!AgendaUpdateResponse.Success)
                {
                    ViewBag.Message = AgendaUpdateResponse.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al actualizar los datos de la cita: " + ex.Message;
                return View();
            }
        }

    }
}
