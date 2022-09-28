using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinearTestPartico.Infra.Data.TypeConfiguration.CanalVendaProduto
{
    public class CanalVendaProdutoTypeConfiguration : IEntityTypeConfiguration<LinearTestPratico.Dominio.CanalVendaProdutoRoot.CanalVendaProduto>
    {
        public void Configure(EntityTypeBuilder<LinearTestPratico.Dominio.CanalVendaProdutoRoot.CanalVendaProduto> builder)
        {
            builder.ToTable("CanalVendasProdutos");            
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("int(11)")
                .IsUnicode()
                .IsRequired();

            builder.HasOne(sc => sc.Produto)
                .WithMany(s => s.CanaisVendas)
                .HasForeignKey(sc => sc.ProdutoId);

            builder.HasOne(sc => sc.CanalVenda)
                .WithMany(s => s.CanaisVendas)
                .HasForeignKey(sc => sc.CanalVendaId);

            builder.Property(p => p.ProdutoId)
                .HasColumnName("ProdutoId")
                .HasColumnType("int(11)");

            builder.Property(p => p.CanalVendaId)
                .HasColumnName("CanalVendaId")
                .HasColumnType("int(11)");
        }
    }
}
