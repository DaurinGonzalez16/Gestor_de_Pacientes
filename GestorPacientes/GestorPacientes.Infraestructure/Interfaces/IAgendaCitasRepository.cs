using GestorPacientes.Domain.Entities;
using GestorPacientes.Domain.Repository;
using GestorPacientes.Infraestructure.Models;
using System;
using System.Collections.Generic;

namespace GestorPacientes.Infraestructure.Interfaces
{
    public interface IAgendaCitasRepository : IRepositoryBase<Agenda_Citas>
    {
        /*DEFINICION DE LOS METODOS PROPIOS DE AGENDA_CITAS*/
        AgendaCitaModel GetRegistro(int IdAgenda);
        List<AgendaCitaModel> GetRegistros();

    }
}
