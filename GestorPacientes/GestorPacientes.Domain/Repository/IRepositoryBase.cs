using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GestorPacientes.Domain.Repository
{

    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void SaveChanged();
        TEntity GetPaciente_Id(int? id);
        List<TEntity> GetEntities();

        /*ESTE METODO ES PARA VERIFICAR SI EXISTE*/
        bool Exists(Expression<Func<TEntity, bool>> filter);
    }
}
