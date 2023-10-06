using GestorPacientes.Domain.Entities;
using GestorPacientes.Infraestructure.Context;
using GestorPacientes.Infraestructure.Core;
using GestorPacientes.Infraestructure.Exceptios;
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
            if (this.Exists(cd => cd.Id_citas == entity.Id_citas))
                throw new PacientesExceptions("El Id ya Existe");

            base.Add(entity);
            base.SaveChanged();
        }

        public override void Remove(Agenda_Citas entity)
        {

            try
            {
                Agenda_Citas AgendaToRemove = base.GetEntity(entity.Id_citas);

                if (AgendaToRemove == null)
                {
                    throw new PacientesExceptions("La Cita No Existe");
                }

                AgendaToRemove.Deleted = true;
                AgendaToRemove.DeletedDate = DateTime.Now;
                AgendaToRemove.UserDeleted = entity.UserDeleted;

                base.SaveChanged();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error al eliminar la cita: " + ex.Message, ex);
            }
        }

        public override void Update(Agenda_Citas entity)
        {
            try
            {
                Agenda_Citas agenda_citas = base.GetEntity(entity.Id_citas);
                
                if (agenda_citas is null)
                    throw new PacientesExceptions("La cita no existe.");

                agenda_citas.Id_citas = entity.Id_citas;
                agenda_citas.id_paciente = entity.id_paciente;
                agenda_citas.Nombre_paciente = entity.Nombre_paciente;
                agenda_citas.Fecha_cita = entity.Fecha_cita;
                agenda_citas.Precio = entity.Precio;
                agenda_citas.Asistio = entity.Asistio;
  
                base.Update(agenda_citas);
                base.SaveChanged();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Ocurrió un error actualizando la cita", ex.ToString());
            }
        }

        public AgendaCitaModel GetRegistro(int IdAgenda)
        {
            AgendaCitaModel model = new AgendaCitaModel();

            try
            {
                model = base.GetEntity(IdAgenda).ConvertToEntityAgendaCitasToModel();
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
