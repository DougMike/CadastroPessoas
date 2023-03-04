using CadastroPessoa.Domain.Entities;
using CadastroPessoa.Domain.Entities.Map;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Persistence
{
    public class CadastroPessoaContext : DbContext
    {
        public CadastroPessoaContext(DbContextOptions<CadastroPessoaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<FileImport> Files { get; set; }
    }
}
