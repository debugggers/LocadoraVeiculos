using LocadoraVeiculos.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloTaxa
{
    public class MapeadorTaxaOrm : IEntityTypeConfiguration<Taxa>
    {
        public DbSet<Taxa> Taxas { get; set; }

        public void Configure(EntityTypeBuilder<Taxa> builder)
        {
            builder.ToTable("TBTaxa");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Descricao).IsRequired().HasColumnType("Varchar(100)");
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.TipoCalculo).HasConversion<int>().IsRequired();

            builder.HasMany(x => x.Locacoes);
        }
    }
}
