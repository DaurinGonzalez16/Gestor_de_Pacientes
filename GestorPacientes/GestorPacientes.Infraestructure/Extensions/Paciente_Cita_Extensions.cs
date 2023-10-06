using GestorPacientes.Domain.Entities;
using GestorPacientes.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Infraestructure.Extensions
{
    public static class Paciente_Cita_Extensions
    {

        public static PacientesModel ConvertToEntityPacientesToModel(this Pacientes _paciente)
        {

            PacientesModel PacientesModel = new PacientesModel()
            {
                Idpacientes = _paciente.Idpacientes,
                Nombre_paciente = _paciente.Nombre_paciente,
                Fecha_nacimiento = _paciente.Fecha_nacimiento,
                Direccion = _paciente.Direccion,
                Numero_telefono = _paciente.Numero_telefono,
                Alergias = _paciente.Alergias,
                Diagnostico = _paciente.Diagnostico

            };

            return PacientesModel; 

        }

        public static AgendaCitaModel ConvertToEntityAgendaCitasToModel(this Agenda_Citas _agenda)
        {

            AgendaCitaModel agendaCitaModel = new AgendaCitaModel()
            {
                Id_citas = _agenda.Id_citas,  
                Id_Pacientes = _agenda.id_paciente,
                Nombre_paciente = _agenda.Nombre_paciente,
                Fecha_cita = _agenda.Fecha_cita,
                Precio = _agenda.Precio,
                Asistio = _agenda.Asistio,
            };

            return (agendaCitaModel);

        }

    }
}
