using GestorPacientes.Application.Contract;
using GestorPacientes.Application.Core;
using GestorPacientes.Application.Dtos.Pacientes;
using GestorPacientes.Application.Validations;
using GestorPacientes.Domain.Entities;
using GestorPacientes.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Application.Service
{
    public class PacientesService : IPacientesServices
    {

        private readonly IPacientesRepository pacientesRepository;
        private readonly ILogger<PacientesService> logger;

        public PacientesService(IPacientesRepository pacientesRepository, ILogger<PacientesService> logger)
        {
            this.pacientesRepository = pacientesRepository;
            this.logger = logger;
        }

        public ServiceResult Get()
        {

            ServiceResult servicios = new ServiceResult();

            try
            {

                var _Pacientes = this.pacientesRepository.GetPacientes();
                servicios.Data = _Pacientes; 

            }
            catch (Exception ex)
            {

               servicios.Success = false;
               servicios.Message = "Error Obteniendo los pacientes";
               this.logger.LogError($"{ex.Message}",ex.ToString());
            }

            return servicios;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult servicios = new ServiceResult();

            try
            {

                var _paciente = this.pacientesRepository.GetPaciente(id);
                servicios.Data = _paciente;
            }
            catch (Exception ex)
            {
                servicios.Success =false;
                servicios.Message = "ERROR AL CONSEGUIR EL PACIENTE";
                this.logger.LogError($"{ex.Message}",ex.ToString());
            }

            return servicios;
        }

        public ServiceResult Save(PacientesAddDto model)
        {
            ServiceResult _servicio  = new ServiceResult();
            ValidationsPacientes validaciones = new ValidationsPacientes();

            try
            {
                // VALIDACIONES
                if (!validaciones.Cumple_ValidarPaciente(model))
                {
                    _servicio.Message = "Los datos del paciente no cumplen con las validaciones.";
                    return _servicio;
                }

                this.pacientesRepository.Add(new Pacientes()
                {
                    Idpacientes = model.Idpacientes,
                    Nombre_paciente = model.Nombre_paciente,
                    Fecha_nacimiento = model.Fecha_nacimiento,
                    Direccion = model.Direccion,
                    Numero_telefono = model.Numero_telefono,
                    Alergias = model.Alergias,
                    Diagnostico = model.Diagnostico,
                    CreationDate = DateTime.Now,
                    CreationUser = model.ChangeUser,
                   
                });

                _servicio.Message = "Paciente creado correctamente.";
            }
            catch (Exception ex)
            {
                _servicio.Message = "Error al crear el paciente.";
                _servicio.Success = false;
                this.logger.LogError($"Error al crear el paciente: {ex.Message}", ex.ToString());
            }

            return _servicio;

        }

        public ServiceResult Remove(PacientesRemoveDto model)
        {
            ServiceResult _servicios = new ServiceResult();

            try
            {
               
                var _GetPaciente = this.pacientesRepository.GetEntity(model.Idpacientes);

                if (_GetPaciente == null)
                {
                    _servicios.Message = "El paciente no existe.";
                    _servicios.Success = false;
                }
                else
                {
                    this.pacientesRepository.Remove(_GetPaciente);
                    _servicios.Message = "Paciente eliminado correctamente.";
                }
            }
            catch (Exception ex)
            {
                _servicios.Message = "Error al eliminar al paciente.";
                _servicios.Success = false;
                this.logger.LogError($"Error al eliminar al paciente: {ex.Message}", ex.ToString());
            }

            return _servicios;

        }

        public ServiceResult Update(PacientesUpdateDto model)
        {

            ServiceResult _Service = new ServiceResult();
            ValidationsPacientes validations = new ValidationsPacientes();

            try
            {
                if (!validations.Cumple_ValidarPaciente(model)){
                    return _Service;
                }

                var paciente = this.pacientesRepository.GetEntity(model.Idpacientes);

                if (paciente == null)
                {
                    _Service.Success = false;
                    _Service.Message = "EL PACIENTE NO EXISTE";
                    return _Service;
                }

                paciente.Idpacientes = model.Idpacientes;
                paciente.Nombre_paciente = model.Nombre_paciente;
                paciente.Fecha_nacimiento = model.Fecha_nacimiento;
                paciente.Direccion = model.Direccion;
                paciente.Numero_telefono = model.Numero_telefono;
                paciente.Alergias = model.Alergias;
                paciente.Diagnostico = model.Diagnostico;
                paciente.CreationDate = DateTime.Now;
                paciente.CreationUser = model.ChangeUser;

                this.pacientesRepository.Update(paciente);
                _Service.Message = "Paciente actualizado correctamente.";

            }
            catch (Exception ex)
            {
                _Service.Success = false;
                _Service.Message = "Error al actualizar el paciente";
                this.logger.LogError($"{_Service.Message}", ex.ToString());
            }

            return _Service;

        }
    }
}
