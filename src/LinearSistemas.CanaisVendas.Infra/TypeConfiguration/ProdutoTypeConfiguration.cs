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
    public class ProdutoTypeConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                //.HasIdentityOptions()
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            //builder.HasMany(c => c.CanaisVendas)
            //    .WithMany(e => e.Produtos);
        }
    }
}
