using GestorPacientes.Application.Core;
using GestorPacientes.Application.Dtos.Pacientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Application.Validations
{
    public class ValidationsPacientes
    {
        public bool Cumple_ValidarPaciente(PacientesDto model)
        {

            ServiceResult serviceResult = new ServiceResult();

            /*PARA LOS STRING*/

            if (string.IsNullOrEmpty(model.Nombre_paciente))
            {
                serviceResult.Message = "El nombre del paciente es requerido";
                serviceResult.Success = false;
                return false;
            }

            if (string.IsNullOrEmpty(model.Direccion))
            {
                serviceResult.Message = "La Dirrecion es requerida";
                serviceResult.Success = false;
                return false;
            }

            if (string.IsNullOrEmpty(model.Alergias))
            {
                serviceResult.Message = "El campo Alergias es requerido, Sino tiene, pongale - NO TIENE ALERGIAS-";
                serviceResult.Success = false;
                return false;
            }

            if (string.IsNullOrEmpty(model.Diagnostico))
            {
                serviceResult.Message = "El Campo de Diagnostico es requerido, " +
                    "En dado caso que no se le ponga, Pongale -Mas adelante- y " +
                    "mas adelante lo edita";
                serviceResult.Success = false;
                return false;
            }

            if (string.IsNullOrEmpty(model.Numero_telefono))
            {
                serviceResult.Message = "El Numero de telefono es requerido, Sino Tiene" +
                    "Pongale -NO TIENE NUMERO DE TELEFONO-";
                serviceResult.Success = false;
                return false;
            }

            /*DIFERENTES A STRING*/

            if (!model.Idpacientes.HasValue)
            {
                serviceResult.Message = "El IdPaciente si es Requerido";
                serviceResult.Success = false;
                return false;
            }

            /*CANTIDADD DE LETRAS PARA LOS CAMPOS*/
            if (model.Nombre_paciente.Length > 40 ||
            model.Direccion.Length > 49 ||
            model.Numero_telefono.Length > 30 ||
            model.Alergias.Length > 195 ||
            model.Diagnostico.Length > 995)
            {
                serviceResult.Message = "Algunos campos tienen una longitud inválida.";
                serviceResult.Success = false;
            }

            return true;
        }
    }
}
