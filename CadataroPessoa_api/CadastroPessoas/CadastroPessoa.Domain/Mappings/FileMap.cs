using CadastroPessoa.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroPessoa.Domain.Mappings
{
    public class FileMap : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("Arquivos");

            builder.Property(f => f.Name)
                .IsRequired()
                .HasColumnType("varchar(100");

            builder.Property(f => f.Type)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(f => f.Size)
                .IsRequired()
                .HasColumnType("smallint");

        }
    }
}
