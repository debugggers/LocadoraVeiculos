using LocadoraVeiculos.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloFuncionario
{
    public class MapeadorFuncionarioOrm : IEntityTypeConfiguration<Funcionario>
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TBFuncionario");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).IsRequired().HasColumnType("Varchar(100)");
            builder.Property(x => x.Login).IsRequired().HasColumnType("Varchar(100)");
            builder.Property(x => x.Senha).IsRequired().HasColumnType("Varchar(100)");
            builder.Property(x => x.DataAdmissao).IsRequired();
            builder.Property(x => x.Salario).IsRequired();
            builder.Property(x => x.EhAdmin).IsRequired();

            builder.HasMany(x => x.Locacoes).WithOne(x => x.Funcionario).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
