using CadastroPessoa_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Pessoa> Pessoas { get; set; }

    }
}
