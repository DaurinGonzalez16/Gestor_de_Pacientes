using GestorPacientes.Domain.Entities;
using GestorPacientes.Infraestructure.Context;
using GestorPacientes.Infraestructure.Core;
using GestorPacientes.Infraestructure.Extensions;
using GestorPacientes.Infraestructure.Interfaces;
using GestorPacientes.Infraestructure.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorPacientes.Infraestructure.Repository
{
    public class AgendaRepository : BaseRepository<Agenda_Citas>, IAgendaCitasRepository
    {

        private readonly ILogger<AgendaRepository> logger;  
        private readonly GestorPacientesContext context;


        public AgendaRepository( ILogger<AgendaRepository> logger,
            GestorPacientesContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        /*IMPLEMENTACION DE LOS METODOS PROPIOS DE AGENDA*/

        public override void Add(Agenda_Citas entity)
        {
            base.Add(entity);
        }

        public override void Remove(Agenda_Citas entity)
        {
            base.Remove(entity);
        }

        public override void Update(Agenda_Citas entity)
        {
            base.Update(entity);
        }

        public AgendaCitaModel GetRegistro(int IdAgenda)
        {
            AgendaCitaModel model = new AgendaCitaModel();

            try
            {
                model = base.GetPaciente_Id(IdAgenda).ConvertToEntityAgendaCitasToModel();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error al Conseguir la lista{ex.Message}",ex.ToString());
            }

            return model;

        }

        public List<AgendaCitaModel> GetRegistros()
        {
            List<AgendaCitaModel> _listaCitas = new List<AgendaCitaModel>();

            try
            {
                _listaCitas = (from cita in base.GetEntities()
                               join paciente in base.GetEntities() on cita.id_paciente equals paciente.id_paciente
                               where !paciente.Deleted
                               select new AgendaCitaModel()
                               {
                                   Id_citas = cita.Id_citas,
                                   Id_Pacientes = cita.id_paciente,
                                   Nombre_paciente = paciente.Nombre_paciente,
                                   Fecha_cita = cita.Fecha_cita,
                                   Precio = cita.Precio,
                                   Asistio = cita.Asistio
                               }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error obteniendo la lista de Citas: {ex.Message}", ex.ToString());
            }

            return _listaCitas;

        }
    }
}
