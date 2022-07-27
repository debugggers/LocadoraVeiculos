using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloVeiculo
{
    public class MapeadorVeiculoOrm : IEntityTypeConfiguration<Veiculo>
    {

        public DbSet<Veiculo> Veiculos { get; set; }

        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TBVeiculo");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Modelo).IsRequired().HasColumnType("Varchar(100)");
            builder.Property(x => x.Placa).IsRequired().HasColumnType("Varchar(10)");
            builder.Property(x => x.Marca).IsRequired().HasColumnType("Varchar(100)");
            builder.Property(x => x.Cor).IsRequired().HasColumnType("Varchar(100)");
            builder.Property(x => x.TipoCombustivel).IsRequired().HasConversion<int>();
            builder.Property(x => x.CapacidadeTanque).IsRequired();
            builder.Property(x => x.Ano).IsRequired();
            builder.Property(x => x.QuilometragemPercorrida).IsRequired();
            builder.HasOne(x => x.GrupoVeiculo);
            builder.Property(x => x.Foto).HasColumnType("Varbinary(max)").IsRequired();
        }
    }
}
