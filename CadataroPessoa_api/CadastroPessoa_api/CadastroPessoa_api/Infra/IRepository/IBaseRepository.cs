using CadastroPessoa_api.Data.DomainObj;
using CadastroPessoa_api.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroPessoa_api.Infra.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        void Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
