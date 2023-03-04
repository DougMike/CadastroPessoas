using CadastroPessoa.Domain.Entities;
using CadastroPessoa.Persistence.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoa.Persistence.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly CadastroPessoaContext _context;
        public FileRepository(CadastroPessoaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FileImport>> GetAllAsync()
        {
            var files = await _context.Files
                .AsNoTracking()
                .ToListAsync();

            return files;
        }

        public async Task<FileImport> GetByIdAsync(Guid id)
        {
            var file = await _context.Files
                .Where(f => f.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return file;
        }
        public async Task<FileImport> Add(FileImport entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<FileImport> Update(FileImport entity)
        {
            _context.Files.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
        public void Delete(FileImport entity)
        {
            _context.Files.Remove(entity);
            _context.SaveChangesAsync();
        }
    }
}
