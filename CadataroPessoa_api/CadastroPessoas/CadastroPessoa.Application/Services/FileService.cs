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
    public class FileService : IFileService
    {
        private readonly CadastroPessoaContext _context;
        private readonly IFileRepository _fileRepository;
        public FileService(CadastroPessoaContext context,
            IFileRepository fileRepository)
        {
            _context = context;
            _fileRepository = fileRepository;
        }

        public Task<IEnumerable<File>> GetAllAsync() => _fileRepository.GetAllAsync();
        public Task<File> GetByIdAsync(Guid id) => _fileRepository.GetByIdAsync(id);

        public async Task<File> Add<TValidator>(File entity) where TValidator : AbstractValidator<File>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());

            await _fileRepository.Add(entity);
            return entity;

        }

        public void Delete(File entity) => _fileRepository.Delete(entity);

        public async Task<File> Update(File entity)
        {
            return await _fileRepository.Update(entity);
        }

        private void Validate(File file, AbstractValidator<File> validator)
        {
            if (file == null)
                throw new Exception("Registros não detectados!");

            File fileExistente = _context.Files.Where(f => f.Name == file.Name && f.Type == file.Type).FirstOrDefault();
            if (fileExistente!= null)
                throw new Exception("Arquivo já cadastrado");

            validator.ValidateAndThrow(file);
        }
    }
}
