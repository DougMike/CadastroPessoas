using CadastroPessoa_API.Models;
using System;
using System.Collections.Generic;

namespace CadastroPessoa_API.Infra.IRepository
{

    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
