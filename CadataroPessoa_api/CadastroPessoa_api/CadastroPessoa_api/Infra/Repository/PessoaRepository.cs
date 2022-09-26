using CadastroPessoa_api.Data;
using CadastroPessoa_api.Data.Models;
using CadastroPessoa_api.Infra.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoa_api.Infra.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly DataContext _context;

        public PessoaRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Pessoa> GetAll()
        {
            return _context.Pessoas.ToList();
        }

        public Pessoa GetById(Guid id)
        {
            return _context.Pessoas.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Pessoa entity)
        {
            _context.Pessoas.Add(entity);
            _context.SaveChangesAsync();
        }

        public void Delete(Pessoa entity)
        {
            _context.Pessoas.Remove(entity);
            _context.SaveChangesAsync();
        }

        public void Update(Pessoa entity)
        {
            _context.Pessoas.Update(entity);
            _context.SaveChangesAsync();
        }

    }
}
