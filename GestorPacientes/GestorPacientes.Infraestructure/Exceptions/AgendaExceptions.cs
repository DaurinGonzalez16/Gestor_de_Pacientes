using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Infraestructure.Exceptions
{
    public class AgendaExceptions : Exception
    {
        public AgendaExceptions(string message):base(message) { }
    }
}
