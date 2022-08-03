using LocadoraVeiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloLocacao
{
    public class MapeadorLocacaoOrm : IEntityTypeConfiguration<Locacao>
    {
        public DbSet<Locacao> Locacoes { get; set; }

        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TBLocacao");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.DataLocacao);
            builder.Property(x => x.DataPrevistaEntrega);
            builder.Property(x => x.ValorPrevisto);
            builder.Property(x => x.PlanosCobranca);

            builder.HasOne(x => x.Funcionario)
            .WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Cliente)
            .WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.GrupoVeiculos);

            builder.HasOne(x => x.Veiculo)
            .WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Taxas);
        }
    }
}
