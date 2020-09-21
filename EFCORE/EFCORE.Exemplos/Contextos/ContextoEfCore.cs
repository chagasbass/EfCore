using EFCORE.Exemplos.Entidades;
using EFCORE.Exemplos.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCORE.Exemplos.Contextos
{
    public class ContextoEfCore : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p =>p.AddConsole());

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }

        public ContextoEfCore(DbContextOptions<ContextoEfCore> options)
          : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Server=den1.mssql4.gear.host;Database=thiagoteste;User Id=thiagoteste;Password=Tn3sc8k_MVx~;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Aplicando a configuração pela instancia das classes de mapeamento 
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new PedidoItemMap());
            #endregion


            #region Procurando no assembly todas as classes
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoEfCore).Assembly);
            #endregion
        }

    }
}
