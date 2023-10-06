using GestorPacientes.Application.Core;
using GestorPacientes.Application.Dtos.Agenda_Citas;
using GestorPacientes.Application.Dtos.Pacientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Application.Contract
{
    public interface IAgendaCitaService : IBaseService<AgendaCitaAddDto,AgendaCitaUpdateDto,AgendaCitaRemoveDto>
    {
    }
}
