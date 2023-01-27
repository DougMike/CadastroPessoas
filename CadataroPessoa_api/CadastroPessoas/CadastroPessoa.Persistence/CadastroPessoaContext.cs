using CadastroPessoa.Domain.DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Persistence
{
    public class CadastroPessoaContext : DbContext
    {
        public CadastroPessoaContext(DbContextOptions<CadastroPessoaContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
