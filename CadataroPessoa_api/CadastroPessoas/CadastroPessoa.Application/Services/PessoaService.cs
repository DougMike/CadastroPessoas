using CadastroPessoa.Application.IServices;
using CadastroPessoa.Domain.DTO;
using CadastroPessoa.Persistence;
using CadastroPessoa.Persistence.IRepository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoa.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly CadastroPessoaContext _context;

        public PessoaService(IPessoaRepository pessoaRepository,
            CadastroPessoaContext context)
        {
            _pessoaRepository = pessoaRepository;
            _context = context;
        }
        public async Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            try
            {
                var pessoas = await _pessoaRepository.GetAllAsync();
                return pessoas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Task<Pessoa> GetByIdAsync(Guid id) => _pessoaRepository.GetByIdAsync(id);

        public async Task<Pessoa> Add<TValidator>(Pessoa pessoa) where TValidator : AbstractValidator<Pessoa>
        {
            Validate(pessoa, Activator.CreateInstance<TValidator>());

            await _pessoaRepository.Add(pessoa);
            return pessoa;
        }

        public async Task<Pessoa> Update(Pessoa entity)
        {
            //Validate(pessoa, Activator.CreateInstance<TValidator>());

            return await _pessoaRepository.Update(entity);
        }
        public void Delete(Pessoa entity) => _pessoaRepository.Delete(entity);

        private void Validate(Pessoa pessoa, AbstractValidator<Pessoa> validator)
        {
            if (pessoa == null)
                throw new Exception("Registros não detectados!");

            Pessoa pessoaExistente = _context.Pessoas.Where(p => p.Email == pessoa.Email || p.Nome == pessoa.Nome).FirstOrDefault();
            if (pessoaExistente != null)
                throw new Exception("Usuário já cadastrado");

            validator.ValidateAndThrow(pessoa);
        }
    }
}
