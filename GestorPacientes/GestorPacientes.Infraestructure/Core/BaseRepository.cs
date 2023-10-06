using GestorPacientes.Domain.Entities;
using GestorPacientes.Domain.Repository;
using GestorPacientes.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GestorPacientes.Infraestructure.Core
{
    public class BaseRepository<TEntety> :IRepositoryBase<TEntety> where TEntety : class 
    {
        /*AQUI ESTARA LA IMPLEMENTACION DE LOS METODOS GENERICOS*/
        /*TODOS LOS METODOS DEBEN SER VIRTUALES POR SI QUIERO HACERLE UN OVERRIDE(SOBREESCRIBIRLO)*/

        private readonly GestorPacientesContext _Context;
        private readonly DbSet<TEntety> MySet;

        public BaseRepository(GestorPacientesContext context)
        {
            this._Context = context; 
            this.MySet = this._Context.Set<TEntety>(); 
        }

        public virtual void Add(TEntety entity)
        {
            this.MySet.Add(entity);
        }

        public virtual void Remove(TEntety entity)
        {
            this.MySet.Remove(entity);
        }

        public virtual void Update(TEntety entity)
        {
            this.MySet.Update(entity);
        }

        public virtual void SaveChanged()
        {
            this._Context.SaveChanges();
        }

        public virtual bool Exists(Expression<Func<TEntety, bool>> filter)
        {
            return this.MySet.Any(filter);
        }

        public virtual List<TEntety> GetEntities()
        {
            return this.MySet.ToList();
        }

        public virtual TEntety GetPaciente_Id(int? id)
        {
            return this.MySet.Find(id);        
        }

    }
}
