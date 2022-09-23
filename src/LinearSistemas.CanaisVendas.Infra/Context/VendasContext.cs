using LinearSistemas.CanaisVendas.Domain.Models;
using LinearSistemas.CanaisVendas.Infra.TypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace LinearSistemas.CanaisVendas.Infra.Context
{
    public class VendasContext : DbContext
    {
        public VendasContext(DbContextOptions<VendasContext> options) : base(options) 
        {
        }

        public DbSet<Produto> Produtos {  get; set; }
        public DbSet<CanalVenda> CanaisVendas { get; set; }

        public DbSet<ProdutoCanalVenda> ProdutoCanaisVendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CanalVendaTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoCanalVendaTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
