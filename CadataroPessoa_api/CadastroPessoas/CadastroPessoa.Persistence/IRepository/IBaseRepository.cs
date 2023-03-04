using CadastroPessoa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroPessoa.Persistence.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
