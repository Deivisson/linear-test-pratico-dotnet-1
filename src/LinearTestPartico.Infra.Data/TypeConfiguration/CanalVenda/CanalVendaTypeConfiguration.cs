using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinearTestPartico.Infra.Data.TypeConfiguration.CanalVenda
{
    public class CanalVendaTypeConfiguration : IEntityTypeConfiguration<LinearTestPratico.Dominio.CanalVendaRoot.CanalVenda>
    {
        public void Configure(EntityTypeBuilder<LinearTestPratico.Dominio.CanalVendaRoot.CanalVenda> builder)
        {
            builder.ToTable("CanalVendas");
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("int(11)")
                .IsUnicode()
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(36)")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
