using EFCORE.Exemplos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCORE.Exemplos.Mapeamentos
{
    public class PedidoItemMap : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PEDIDO_ITEMS");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Quantidade)
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(p => p.Valor)
                .IsRequired();

            builder.Property(p => p.Desconto)
                .IsRequired();


        }
    }
}
