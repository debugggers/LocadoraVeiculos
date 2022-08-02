using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo
{
    public class MapeadorGrupoVeiculoOrm : IEntityTypeConfiguration<GrupoVeiculos>
    {

        public DbSet<GrupoVeiculos> Grupos { get; set; }

        public void Configure(EntityTypeBuilder<GrupoVeiculos> builder)
        {
            builder.ToTable("TBGrupoVeiculos");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).IsRequired().HasColumnType("Varchar(100)");

            builder.HasOne(x => x.PlanoCobranca).WithOne(x => x.GrupoVeiculos).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
