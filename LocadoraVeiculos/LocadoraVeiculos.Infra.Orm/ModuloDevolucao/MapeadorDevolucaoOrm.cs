using LocadoraVeiculos.Dominio.ModuloDevolucao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloDevolucao
{
    public class MapeadorDevolucaoOrm : IEntityTypeConfiguration<Devolucao>
    {

        public DbSet<Devolucao> Devolucoes { get; set; }

        public void Configure(EntityTypeBuilder<Devolucao> builder)
        {
            builder.ToTable("TBDevolucao");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.Locacao)
                   .WithMany()
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.QuilometragemVeiculo).IsRequired();
            builder.Property(x => x.DataDevolucao).IsRequired();
            builder.Property(x => x.NivelDoTanque).IsRequired();
            builder.Property(x => x.ValorTotal).IsRequired();
            builder.HasMany(x => x.Taxas)
                .WithOne()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
