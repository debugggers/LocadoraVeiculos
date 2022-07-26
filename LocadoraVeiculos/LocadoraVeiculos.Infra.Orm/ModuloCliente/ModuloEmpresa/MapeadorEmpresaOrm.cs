using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloCliente.ModuloEmpresa
{
    public class MapeadorEmpresaOrm : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
