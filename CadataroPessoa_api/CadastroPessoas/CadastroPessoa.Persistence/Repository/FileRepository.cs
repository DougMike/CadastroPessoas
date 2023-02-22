using CadastroPessoa.Domain.DTO;
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
        public async Task<IEnumerable<File>> GetAllAsync()
        {
            var files = await _context.Files
                .AsNoTracking()
                .ToListAsync();

            return files;
        }

        public async Task<File> GetByIdAsync(Guid id)
        {
            var file = await _context.Files
                .Where(f => f.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return file;
        }
        public async Task<File> Add(File entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<File> Update(File entity)
        {
            _context.Files.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
        public void Delete(File entity)
        {
            _context.Files.Remove(entity);
            _context.SaveChangesAsync();
        }


    }
}
