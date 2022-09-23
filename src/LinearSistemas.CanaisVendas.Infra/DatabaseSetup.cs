using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Infra.Context;
using LinearSistemas.CanaisVendas.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinearSistemas.CanaisVendas.Infra
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<VendasContext>(options => options
                .UseNpgsql(configuration.GetConnectionString("VendaConnectionString")));

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICanalVendaRepository, CanalVendaRepository>();
        }
    }
}
