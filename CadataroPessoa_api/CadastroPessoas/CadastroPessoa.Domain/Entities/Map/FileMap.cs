using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroPessoa.Domain.Entities.Map
{
    public class FileMap : IEntityTypeConfiguration<FileImport>
    {
        public void Configure(EntityTypeBuilder<FileImport> builder)
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
