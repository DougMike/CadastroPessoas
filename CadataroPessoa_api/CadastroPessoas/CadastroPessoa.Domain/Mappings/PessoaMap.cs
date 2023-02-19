
using CadastroPessoa.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa.Domain.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder.Property(p => p.Sobrenome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Nacionalidade)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.CEP)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(p => p.Uf)
                .HasColumnType("varchar(2)")
                .IsRequired();

            builder.Property(p => p.Localidade)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Logradouro)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Telefone)
                .HasColumnType("varchar(20)")
                .IsRequired();
        }
    }
}
