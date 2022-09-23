using LinearSistemas.CanaisVendas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinearSistemas.CanaisVendas.Infra.TypeConfiguration
{
    public class CanalVendaTypeConfiguration : IEntityTypeConfiguration<CanalVenda>
    {
        public void Configure(EntityTypeBuilder<CanalVenda> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

            //builder.Property(p => p.IdProduto)
            //    .HasColumnName("IdProduto")
            //    .HasColumnType("char(36)")
            //    .IsRequired();

            //builder.HasMany(c => c.Produtos)
            //    .WithMany(e => e.CanaisVendas);
                //.HasForeignKey(fk => fk.IdProduto)
                //.HasPrincipalKey(fpk => fpk.Id)
                //.OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
