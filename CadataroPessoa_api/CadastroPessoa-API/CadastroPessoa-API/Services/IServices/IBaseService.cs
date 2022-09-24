using CadastroPessoa_API.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CadastroPessoa_API.Services.IServices
{
    public interface IBaseService<TEntity>: IDisposable where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        TEntity Add<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;
        TEntity Update<TValidator>(Guid id) where TValidator : AbstractValidator<TEntity>;
        void Delete(TEntity entity);
    }
}
