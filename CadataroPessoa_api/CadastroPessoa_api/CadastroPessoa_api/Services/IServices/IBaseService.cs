using CadastroPessoa_api.Data.DomainObj;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CadastroPessoa_api.Services.IServices
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        TEntity Add<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;
        void Delete(TEntity entity);
        TEntity Update<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;

    }
}
