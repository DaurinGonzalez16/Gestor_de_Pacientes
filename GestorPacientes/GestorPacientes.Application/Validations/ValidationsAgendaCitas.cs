using GestorPacientes.Application.Core;
using GestorPacientes.Application.Dtos.Agenda_Citas;
using GestorPacientes.Application.Dtos.Pacientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Application.Validations
{
    public class ValidationsAgendaCitas
    {
        public bool Cumple_ValidarAgenda(AgendaCitaDto model)
        {
            ServiceResult serviceResult = new ServiceResult();

            if (string.IsNullOrEmpty(model.Nombre_paciente))
            {
                serviceResult.Message = "El nombre del paciente es requerido";
                serviceResult.Success = false;
                return false;
            }

            if (!model.id_paciente.HasValue)
            {
                serviceResult.Message = "El idPacientes es requerido.";
                serviceResult.Success = false;
                return false;
            }

            if (model.Id_citas.HasValue)
            {
                serviceResult.Message = "El Idcitas No es requerido.";
                serviceResult.Success = false;
                return false;
            }

            if (model.Fecha_cita == DateTime.MinValue)
            {
                serviceResult.Message = "La fecha de cita es requerida.";
                serviceResult.Success = false;
                return false;
            }

            if (model.Precio.HasValue)
            {
                serviceResult.Message = "El Precio de la Cita No es requerido.";
                serviceResult.Success = false;
                return false;
            }

            if (!model.Asistio)
            {
                serviceResult.Message = "La asistencia debe ser especificada (verdadero o falso).";
                serviceResult.Success = false;
                return false;
            }

            /*CANTIDAD DE CARACTERES PARA EL CAMPO NOMBRE PACIENTE*/
            if (model.Nombre_paciente.Length > 40)
            {
                serviceResult.Message = "La longitud del nombre del paciente es inválida";
                serviceResult.Success = false;
                return false;
            }

            return true;

        }
    }
}
