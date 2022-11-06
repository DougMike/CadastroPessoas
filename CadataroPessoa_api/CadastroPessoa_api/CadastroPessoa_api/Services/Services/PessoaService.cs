using CadastroPessoa_api.Data;
using CadastroPessoa_api.Data.Models;
using CadastroPessoa_api.Infra.IRepository;
using CadastroPessoa_api.Services.IServices;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroPessoa_api.Services.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly DataContext _dataContext;

        public PessoaService(IPessoaRepository pessoaRepository,
            DataContext dataContext)
        {
            _pessoaRepository = pessoaRepository;
            _dataContext = dataContext;
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

            Pessoa pessoaExistente = _dataContext.Pessoas.Where(p => p.Email == pessoa.Email || p.Nome == pessoa.Nome).FirstOrDefault();
            if (pessoaExistente != null)
                return throw new Exception("Usuário já cadastrado");

            validator.ValidateAndThrow(pessoa);
        }
    }
}
