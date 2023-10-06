using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Infraestructure.Exceptios
{
    public class PacientesExceptions:Exception
    {
        /*Controlar las Excepciones del programa*/

        public PacientesExceptions(string message):base(message)
        {
            
        }

    }
}
