using Microsoft.EntityFrameworkCore;

namespace LinearTestPartico.Infra.Data.TypeConfiguration.Produto
{
    public class ProdutoTypeConfiguration : IEntityTypeConfiguration<LinearTestPratico.Dominio.ProdutoRoot.Produto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LinearTestPratico.Dominio.ProdutoRoot.Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("int(11)")
                .IsUnicode()
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
