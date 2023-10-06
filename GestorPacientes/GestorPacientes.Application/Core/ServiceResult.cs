using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Application.Core
{
    public class ServiceResult
    {
        /*ESTA CLASE LLEVARA EL CONTROL DE MI CRUD(AGREGAR,ELIMINAR,ACTUALIZAR, ETC)*/
        /*ES PARA SABER SI UNA OPERACION SE REALIZO BIEN O MAL*/

        public ServiceResult()
            {
                this.Success = true;
            }

            public bool Success { get; set; }
            public string Message { get; set; }
            public dynamic Data { get; set; }
        
    }
}
