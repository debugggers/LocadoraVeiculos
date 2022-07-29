using LocadoraVeiculos.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloCliente
{
    public class MapeadorClienteOrm : IEntityTypeConfiguration<Cliente>
    {

        public DbSet<Cliente> Clientes { get; set; }

        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TBCliente");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("Varchar(20)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(x => x.CPF).HasColumnType("Varchar(20)").IsRequired();
            builder.Property(x => x.CnhNome).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(x => x.CnhNumero).IsRequired();
            builder.Property(x => x.CnhVencimento).IsRequired();
            builder.HasOne(x => x.Empresa)
                .WithMany()
                .IsRequired(false)
                .HasForeignKey(x => x.EmpresaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
