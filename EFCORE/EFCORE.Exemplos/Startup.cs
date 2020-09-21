using EFCORE.Exemplos.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCORE.Exemplos
{
    public class Startup
    {
        private readonly string _ConnectionString = @"Server=den1.mssql4.gear.host;Database=thiagoteste;User Id = thiagoteste; Password=Tn3sc8k_MVx ~;";

        public void ConfigureServices(IServiceCollection services)
       => services.AddDbContext<ContextoEfCore>(opt => opt.UseSqlServer(_ConnectionString));
    }
}
