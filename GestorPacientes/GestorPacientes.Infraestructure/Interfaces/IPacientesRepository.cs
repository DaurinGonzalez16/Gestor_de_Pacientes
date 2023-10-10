using GestorPacientes.Domain.Entities;
using GestorPacientes.Domain.Repository;
using GestorPacientes.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Infraestructure.Interfaces
{
    public interface IPacientesRepository: IRepositoryBase<Pacientes>
    {
        /*DEFINICION DE LOS METODOS PROPIOS DE PACIENTES*/
        PacientesModel GetPaciente(int Idpaciente);
        List<PacientesModel> GetPacientes();
    }
}
