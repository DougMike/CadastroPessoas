using CadastroPessoa_api.Data.Models;
using CadastroPessoa_api.Infra.IRepository;
using CadastroPessoa_api.Services.IServices;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CadastroPessoa_api.Services.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public IEnumerable<Pessoa> GetAll() => _pessoaRepository.GetAll();

        public Pessoa GetById(Guid id) => _pessoaRepository.GetById(id);

        public Pessoa Add<TValidator>(Pessoa pessoa) where TValidator : AbstractValidator<Pessoa>
        {
            Validate(pessoa, Activator.CreateInstance<TValidator>());

            _pessoaRepository.Add(pessoa);
            return pessoa;
        }

        public Pessoa Update<TValidator>(Pessoa pessoa) where TValidator : AbstractValidator<Pessoa>
        {
            Validate(pessoa, Activator.CreateInstance<TValidator>());

            _pessoaRepository.Update(pessoa);
            return pessoa;
        }
        public void Delete(Pessoa entity) => _pessoaRepository.Delete(entity);

        private void Validate(Pessoa pessoa, AbstractValidator<Pessoa> validator)
        {
            if (pessoa == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(pessoa);
        }

        //public void Dispose() => _pessoaRepository.Dispose();
    }
}
