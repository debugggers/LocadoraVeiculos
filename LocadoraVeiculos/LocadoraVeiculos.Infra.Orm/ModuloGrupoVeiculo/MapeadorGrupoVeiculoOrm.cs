using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo
{
    public class MapeadorGrupoVeiculoOrm : IEntityTypeConfiguration<GrupoVeiculos>
    {
        public void Configure(EntityTypeBuilder<GrupoVeiculos> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
