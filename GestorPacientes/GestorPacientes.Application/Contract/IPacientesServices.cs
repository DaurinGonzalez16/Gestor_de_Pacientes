using GestorPacientes.Application.Core;
using GestorPacientes.Application.Dtos.Pacientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Application.Contract
{
    public interface IPacientesServices : IBaseService<PacientesAddDto, PacientesUpdateDto, PacientesRemoveDto>
    {
    }
}
