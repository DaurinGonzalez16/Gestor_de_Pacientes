using GestorPacientes.Domain.Entities;
using GestorPacientes.Domain.Repository;
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
using System.Linq.Expressions;
using System.Text;

namespace GestorPacientes.Infraestructure.Repository
{
    public class PacienteRepository : BaseRepository<Pacientes>, IPacientesRepository
    {
        /*IMPLEMENTACION DE LOS METODOS PROPIOS DE Pacientes*/

        private readonly ILogger<PacienteRepository> _logger;
        private readonly GestorPacientesContext _context;

        public PacienteRepository(ILogger<PacienteRepository> logger,
            GestorPacientesContext context) : base(context)
        {
            this._logger = logger;
            this._context = context;
        }

        /*¿POR QUE SOLO ESTOS METODOS? PORQUE SON LOS UNICOS METODOS QUE HAY QUE
         HACERLE UN OVERRIDE PARA QUE FUNCIONEN EN PACIENTE, LOS DEMAS PUEDEN USARSE
         Y CUALQUEIR ENTIDAD*/

        public override void Add(Pacientes entity)
        {
           if (this.Exists(cd => cd.Idpacientes == entity.Idpacientes))
                throw new PacientesExceptions("El Id ya Existe");
     
            base.Add(entity);
            base.SaveChanged();
        }

        public override void Remove(Pacientes entity)
        {

            try
            {
                Pacientes PacientesToRemove = base.GetEntity(entity.Idpacientes);

                if (PacientesToRemove == null)
                {
                    throw new PacientesExceptions("El Paciente No Existe");
                }

                PacientesToRemove.Deleted = true;
                PacientesToRemove.DeletedDate = DateTime.Now;
                PacientesToRemove.UserDeleted = entity.UserDeleted;

                base.SaveChanged();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrió un error al eliminar el Paciente: " + ex.Message, ex);
            }

        }

        public override void Update(Pacientes entity)
        {

            try
            {
                Pacientes _pacienteActualizado = base.GetEntity(entity.Idpacientes);
                if (_pacienteActualizado is null)
                    throw new PacientesExceptions("El Paciente no existe.");

                _pacienteActualizado.Idpacientes = entity.Idpacientes;
                _pacienteActualizado.Nombre_paciente = entity.Nombre_paciente;
                _pacienteActualizado.Fecha_nacimiento = entity.Fecha_nacimiento;
                _pacienteActualizado.Direccion = entity.Direccion;
                _pacienteActualizado.Numero_telefono = entity.Numero_telefono;
                _pacienteActualizado.Alergias = entity.Alergias;
                _pacienteActualizado.Diagnostico = entity.Diagnostico;

                base.Update(_pacienteActualizado);
                base.SaveChanged();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrió un error actualizando el Paciente", ex.ToString());
            }

        }

        public PacientesModel GetPaciente(int? Idpaciente)
        {
            PacientesModel pacientesModel = new PacientesModel();

            try
            {
                pacientesModel = base.GetEntity(Idpaciente).ConvertToEntityPacientesToModel();
            }
            catch (Exception ex)
            {


                this._logger.LogError("Error Obteniendo el Paciente", ex.ToString());
            }

            return pacientesModel;
        }

        public List<PacientesModel> GetPacientes()
        {
            List<PacientesModel> _listaPacientes = new List<PacientesModel>();


            try
            {
                _listaPacientes = (from cu in base.GetEntities()
                                   where !cu.Deleted
                                   select new PacientesModel()
                                   {
                                       Idpacientes = cu.Idpacientes,
                                       Nombre_paciente = cu.Nombre_paciente,
                                       Fecha_nacimiento =  cu.Fecha_nacimiento,
                                       Direccion = cu.Direccion,
                                       Numero_telefono = cu.Numero_telefono,
                                       Alergias = cu.Alergias,
                                       Diagnostico = cu.Diagnostico

                                   }).ToList();

            }
            catch (Exception ex)
            {

                this._logger.LogError($"Error Obteniendo la lista de Pacientes:{ex.Message}",ex.ToString()); 
            }

            return _listaPacientes;

        }
    }
}

