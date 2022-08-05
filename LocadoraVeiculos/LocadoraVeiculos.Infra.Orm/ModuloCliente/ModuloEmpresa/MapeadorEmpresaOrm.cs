using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloCliente.ModuloEmpresa
{
    public class MapeadorEmpresaOrm : IEntityTypeConfiguration<Empresa>
    {
        public DbSet<Empresa> Empresas { get; set; }

        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("TBEmpresa");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("Varchar(20)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(x => x.CNPJ).HasColumnType("Varchar(20)").IsRequired();

            builder.HasMany(x => x.Clientes).WithOne(x => x.Empresa)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
