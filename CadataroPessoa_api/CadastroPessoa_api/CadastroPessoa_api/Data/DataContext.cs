using CadastroPessoa_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
