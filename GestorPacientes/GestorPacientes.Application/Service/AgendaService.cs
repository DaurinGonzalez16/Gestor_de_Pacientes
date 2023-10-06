using GestorPacientes.Application.Contract;
using GestorPacientes.Application.Core;
using GestorPacientes.Application.Dtos.Agenda_Citas;
using GestorPacientes.Application.Validations;
using GestorPacientes.Domain.Entities;
using GestorPacientes.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Application.Service
{
    public class AgendaService : IAgendaCitaService
    {
        private readonly ILogger<AgendaService> _logger;
        private readonly IAgendaCitasRepository _agendaCitasRepository;

        public AgendaService(ILogger<AgendaService> logger, IAgendaCitasRepository agendaCitasRepository)
        {
            _logger = logger;
            _agendaCitasRepository = agendaCitasRepository;
        }

        public ServiceResult Get()
        {

            ServiceResult servicios = new ServiceResult();

            try
            {
                var _Cita = this._agendaCitasRepository.GetRegistros();
                servicios.Data = _Cita;
            }
            catch (Exception ex)
            {

                servicios.Success = false;
                servicios.Message = "Error Obteniendo la cita";
                this._logger.LogError($"{ex.Message}", ex.ToString());
            }

            return servicios;

        }

        public ServiceResult GetById(int id)
        {
            ServiceResult servicios = new ServiceResult();

            try
            {
                var _Cita = this._agendaCitasRepository.GetRegistro(id);
                servicios.Data = _Cita;
            }
            catch (Exception ex)
            {
                servicios.Success = false;
                servicios.Message = "ERROR AL CONSEGUIR EL PACIENTE";
                this._logger.LogError($"{ex.Message}", ex.ToString());
            }

            return servicios;
        }

        public ServiceResult Remove(AgendaCitaRemoveDto model)
        {
            ServiceResult _servicios = new ServiceResult();
            ValidationsAgendaCitas validationsAgenda = new ValidationsAgendaCitas();

            try
            {

                if (!validationsAgenda.Cumple_ValidarAgenda(model))
                {
                    return _servicios;
                }

                var _GetCita = this._agendaCitasRepository.GetPaciente_Id(model.Id_citas);

                if (_GetCita != null)
                {
                    _servicios.Success = false;
                    _servicios.Message = "LA CITA NO EXISTE";
                    return _servicios;
                }

                this._agendaCitasRepository.Remove(_GetCita);
                _servicios.Message = "Cita eliminada correctamente.";

            }
            catch (Exception ex)
            {
                _servicios.Message = "Error al Eliminar la Cita";
                _servicios.Success = false;
                this._logger.LogError($"{ex.Message}", ex.ToString());
            }

            return _servicios;
        }

        public ServiceResult Save(AgendaCitaAddDto model)
        {
            ServiceResult _servicio = new ServiceResult();
            ValidationsAgendaCitas validationsAgenda = new ValidationsAgendaCitas();

            try
            {
                /*VALIDACIONES*/

                if (validationsAgenda.Cumple_ValidarAgenda(model))
                {
                    return _servicio;
                }

                DateTime fechaActual = DateTime.Now;

                this._agendaCitasRepository.Add(new Agenda_Citas()
                {
                    Id_citas = model.Id_citas,
                    id_paciente = model.id_paciente,
                    Nombre_paciente = model.Nombre_paciente,
                    Fecha_cita = model.Fecha_cita,
                    Precio = model.Precio,
                    Asistio = model.Asistio,
                    CreationDate = fechaActual,
                    CreationUser = model.ChangeUser
                });

                _servicio.Message = "CITA AGENDADA";
            }

            catch (Exception ex)
            {
                _servicio.Message = "ERROR AL CREAR LA CITA";
                _servicio.Success = false;
                this._logger.LogError($"{ex.Message}", ex.ToString());
            }

            return _servicio;
        }

        public ServiceResult Update(AgendaCitaUpdateDto model)
        {
            ServiceResult _Service = new ServiceResult();
            ValidationsAgendaCitas validationsAgenda = new ValidationsAgendaCitas();

            try
            {
                if (validationsAgenda.Cumple_ValidarAgenda(model))
                {
                    return _Service;
                }

                var paciente = this._agendaCitasRepository.GetPaciente_Id(model.Id_citas);

                if (paciente != null)
                {
                    _Service.Success = false;
                    _Service.Message = "LA CITA NO EXISTE";
                    return _Service;
                }

                DateTime fechaactual = DateTime.Now;

                paciente.Id_citas = model.Id_citas;
                paciente.id_paciente = model.id_paciente;
                paciente.Nombre_paciente = model.Nombre_paciente;
                paciente.Fecha_cita = model.Fecha_cita;
                paciente.Precio = model.Precio;
                paciente.Asistio = model.Asistio;
                paciente.CreationDate = fechaactual;
                paciente.CreationUser = model.ChangeUser;

                this._agendaCitasRepository.Update(paciente);
                _Service.Message = "Cita actualizada correctamente.";

            }
            catch (Exception ex)
            {
                _Service.Success = false;
                _Service.Message = "Error al actualizar la Cita";
                this._logger.LogError($"{_Service.Message}", ex.ToString());
            }

            return _Service;
        }
    }
}
