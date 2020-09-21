using EFCORE.Exemplos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace EFCORE.Exemplos.Mapeamentos
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("PEDIDOS");

            builder.HasKey(p => p.Id);

            //datetime now como default
            builder.Property(p => p.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();

            //mapeamento de enum como string
            builder.Property(p => p.StatusPedido).HasConversion<string>();
            builder.Property(p => p.TipoFrete).HasConversion<int>();

            builder.Property(p => p.Observacao)
                .HasColumnType("VARCHAR(512)");

            //relacionamento MUITOS para UM
            builder.HasMany(x => x.Itens)
                .WithOne(p => p.Pedido)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
