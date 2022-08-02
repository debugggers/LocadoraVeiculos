using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public DbSet<PlanoCobranca> PlanoCobrancas { get; set; }

        public void Configure(EntityTypeBuilder<PlanoCobranca> builder)
        {
            builder.ToTable("TBPlanoCobranca");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.ValorDiario_Diario).IsRequired();
            builder.Property(x => x.ValorPorKm_Diario).IsRequired();
            builder.Property(x => x.ValorDiario_Livre).IsRequired();
            builder.Property(x => x.ValorDiario_Controlado).IsRequired();
            builder.Property(x => x.ValorPorKm_Controlado).IsRequired();
            builder.Property(x => x.ControleKm).IsRequired();

            builder.HasOne(x => x.GrupoVeiculos).WithOne(x => x.PlanoCobranca);
        }
    }
}
