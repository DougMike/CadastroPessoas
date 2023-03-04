using AutoMapper;
using CadastroPessoa.Application.DTO;
using CadastroPessoa.Application.IServices;
using CadastroPessoa.Domain.Entities;
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
        private readonly IMapper _mapper;

        public PessoaService(IPessoaRepository pessoaRepository,
            CadastroPessoaContext context,
            IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PessoaDTO>> GetAllAsync()
        {

            try
            {
                var pessoas = _mapper.Map<IEnumerable<PessoaDTO>>(await _pessoaRepository.GetAllAsync());

                return pessoas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<PessoaDTO> GetByIdAsync(Guid id)
        {
            return _mapper.Map<PessoaDTO>(await _pessoaRepository.GetByIdAsync(id));
        }

        public async Task<PessoaDTO> Add<TValidator>(PessoaDTO pessoa) where TValidator : AbstractValidator<PessoaDTO>
        {
            Validate(pessoa, Activator.CreateInstance<TValidator>());

            await _pessoaRepository.Add(_mapper.Map<Pessoa>(pessoa));
            return pessoa;
        }

        public async Task<PessoaDTO> Update(PessoaDTO entity)
        {
            var pessoa = _mapper.Map<Pessoa>(entity);
            return _mapper.Map<PessoaDTO>(await _pessoaRepository.Update(pessoa));
        }
        public void Delete(PessoaDTO entity)
        {
            var pessoa = _mapper.Map<Pessoa>(entity);
            _pessoaRepository.Delete(pessoa);
        }

        private void Validate(PessoaDTO pessoa, AbstractValidator<PessoaDTO> validator)
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
