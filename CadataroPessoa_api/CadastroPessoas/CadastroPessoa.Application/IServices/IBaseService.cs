﻿using CadastroPessoa.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroPessoa.Application.IServices
{
    public interface IBaseService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> Add<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;
        void Delete(TEntity entity);
        Task<TEntity> Update(TEntity entity);

    }
}
