using CadastroPessoa_API.Data;
using CadastroPessoa_API.Infra.IRepository;
using CadastroPessoa_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroPessoa_API.Infra.Repository
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
            _context.SaveChanges();
        }

        public void Update(Pessoa entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(Pessoa entity)
        {
            _context.Pessoas.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
