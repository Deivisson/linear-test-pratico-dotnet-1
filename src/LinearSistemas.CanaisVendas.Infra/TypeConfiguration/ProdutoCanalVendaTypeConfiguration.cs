using LinearSistemas.CanaisVendas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSistemas.CanaisVendas.Infra.TypeConfiguration
{
    public class ProdutoCanalVendaTypeConfiguration : IEntityTypeConfiguration<ProdutoCanalVenda>
    {
        public void Configure(EntityTypeBuilder<ProdutoCanalVenda> builder)
        {
            builder.HasKey(pk => new { pk.ProdutoId, pk.CanalVendaId });

            builder.Property(p => p.ProdutoId)
                .HasColumnName("ProdutoId")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(c => c.Produto)
                .WithMany(c => c.CanaisVendas)
                .HasForeignKey(fk => fk.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //.HasPrincipalKey(fpk => fpk.Id)
            //.OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(p => p.CanalVendaId)
                .HasColumnName("CanalVendaId")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(c => c.CanalVenda)
                .WithMany(c => c.CanaisVendas)
                .HasForeignKey(fk => fk.CanalVendaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
