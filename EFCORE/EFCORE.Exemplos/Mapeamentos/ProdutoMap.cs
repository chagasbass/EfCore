using EFCORE.Exemplos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCORE.Exemplos.Mapeamentos
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTOS");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Descricao)
               .HasColumnType("VARCHAR(60)")
               .IsRequired();

            builder.Property(p => p.CodigoDeBarras)
                .HasColumnType("VARCHAR(14)")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(p => p.Valor)
                .IsRequired();

            builder.Property(p => p.TipoProduto)
                .HasConversion<string>();
        }
    }
}
