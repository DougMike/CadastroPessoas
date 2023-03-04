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

        public Task<IEnumerable<FileImport>> GetAllAsync() => _fileRepository.GetAllAsync();
        public Task<FileImport> GetByIdAsync(Guid id) => _fileRepository.GetByIdAsync(id);

        public async Task<FileImport> Add<TValidator>(FileImport entity) where TValidator : AbstractValidator<FileImport>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());

            await _fileRepository.Add(entity);
            return entity;

        }

        public void Delete(FileImport entity) => _fileRepository.Delete(entity);

        public async Task<FileImport> Update(FileImport entity)
        {
            return await _fileRepository.Update(entity);
        }

        private void Validate(FileImport file, AbstractValidator<FileImport> validator)
        {
            if (file == null)
                throw new Exception("Registros não detectados!");

            FileImport fileExistente = _context.Files.Where(f => f.Name == file.Name && f.Type == file.Type).FirstOrDefault();
            if (fileExistente!= null)
                throw new Exception("Arquivo já cadastrado");

            validator.ValidateAndThrow(file);
        }
    }
}
