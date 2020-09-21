using EFCORE.Exemplos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCORE.Exemplos.Mapeamentos
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTES");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(a => a.Telefone)
                .HasColumnType("CHAR(11)");

            builder.Property(a => a.CEP)
                .HasColumnType("CHAR(8)")
                .IsRequired();

            builder.Property(a => a.Estado)
                .HasColumnType("CHAR(2)")
                .IsRequired();

            builder.Property(a => a.Cidade)
                .HasMaxLength(60)
                .IsRequired();

            builder.HasIndex(x => x.Telefone).HasName("idx_cliente_telefone");
        }
    }
}
