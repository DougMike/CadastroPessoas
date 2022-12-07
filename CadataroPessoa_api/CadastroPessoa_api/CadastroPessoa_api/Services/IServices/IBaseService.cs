using CadastroPessoa_api.Data.DomainObj;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroPessoa_api.Services.IServices
{
    public interface IBaseService<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        TEntity Add<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;
        void Delete(TEntity entity);
        Task<TEntity> Update(TEntity entity);

    }
}
