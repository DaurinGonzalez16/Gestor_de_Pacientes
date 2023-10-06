using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPacientes.Domain.Core
{
    public abstract class BaseEntity
    {

        /*Esta clase es para tener un control de los registros de nuestra tabla*/
        /*¿Porque una clase abstrata?
        Para pasarle las propiedades a las 2 tablas y no tener duplicidad
        de codigo*/

        public BaseEntity()
        {
            this.CreationDate = DateTime.Now;
            this.Deleted = false;
        }

        public DateTime? CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreationUser { get; set; }
        public int? UserMod { get; set; }
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }


      

    }
}
