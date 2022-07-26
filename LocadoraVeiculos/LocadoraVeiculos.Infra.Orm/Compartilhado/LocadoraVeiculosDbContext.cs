using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LocadoraVeiculos.Infra.Orm.Compartilhado
{
    public class LocadoraVeiculosDbContext : DbContext, IContext
    {

        private string connectionString;

        public LocadoraVeiculosDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void GravarDados()
        {
            SaveChanges();
        }

        //public DbSet<Cliente> Clientes { get; set; }

        //public DbSet<Empresa> Empresas { get; set; }

        //public DbSet<GrupoVeiculos> Grupos { get; set; }

        //public DbSet<PlanoCobranca> PlanoCobrancas { get; set; }

        //public DbSet<Taxa> Taxas { get; set; }

        //public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(connectionString);

            ILoggerFactory loggerFactory = LoggerFactory.Create((x) =>
            {
                x.AddSerilog(Log.Logger);
            });

            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Cliente>(entidade =>
            //{

            //    entidade.ToTable("TBCliente");
            //    entidade.Property(x => x.Id).ValueGeneratedNever();
            //    entidade.Property(x => x.Nome).HasColumnType("Varchar(100)").IsRequired();
            //    entidade.Property(x => x.Email).HasColumnType("Varchar(100)").IsRequired();
            //    entidade.Property(x => x.Telefone).HasColumnType("Varchar(20)").IsRequired();
            //    entidade.Property(x => x.Endereco).HasColumnType("Varchar(100)").IsRequired();
            //    entidade.Property(x => x.CPF).HasColumnType("Varchar(20)").IsRequired();
            //    entidade.Property(x => x.CnhNome).HasColumnType("Varchar(100)").IsRequired();
            //    entidade.Property(x => x.CnhNumero).IsRequired();
            //    entidade.Property(x => x.CnhVencimento).IsRequired();
            //    entidade.HasOne(x => x.Empresa);

            //});

            //modelBuilder.Entity<Empresa>(entidade =>
            //{

            //    entidade.ToTable("TBEmpresa");
            //    entidade.Property(x => x.Id).ValueGeneratedNever();
            //    entidade.Property(x => x.Nome).HasColumnType("Varchar(100)").IsRequired();
            //    entidade.Property(x => x.Email).HasColumnType("Varchar(100)").IsRequired();
            //    entidade.Property(x => x.Telefone).HasColumnType("Varchar(20)").IsRequired();
            //    entidade.Property(x => x.Endereco).HasColumnType("Varchar(100)").IsRequired();
            //    entidade.Property(x => x.CNPJ).HasColumnType("Varchar(20)").IsRequired();

            //});


            //modelBuilder.Entity<GrupoVeiculos>(entidade =>
            //{

            //    entidade.ToTable("TBGrupoVeiculos");
            //    entidade.Property(x => x.Id).ValueGeneratedNever();
            //    entidade.Property(x => x.Nome).IsRequired().HasColumnType("Varchar(100)");

            //});


            //modelBuilder.Entity<PlanoCobranca>(entidade =>
            //{

            //    entidade.ToTable("TBPlanoCobranca");
            //    entidade.Property(x => x.Id).ValueGeneratedNever();
            //    entidade.Property(x => x.ValorDiario_Diario).IsRequired();
            //    entidade.Property(x => x.ValorPorKm_Diario).IsRequired();
            //    entidade.Property(x => x.ValorDiario_Livre).IsRequired();
            //    entidade.Property(x => x.ValorDiario_Controlado).IsRequired();
            //    entidade.Property(x => x.ValorPorKm_Controlado).IsRequired();
            //    entidade.Property(x => x.ControleKm).IsRequired();
            //    entidade.HasOne(x => x.GrupoVeiculos);

            //});

            //modelBuilder.Entity<Taxa>(entidade =>
            //{

            //    entidade.ToTable("TBTaxa");
            //    entidade.Property(x => x.Id).ValueGeneratedNever();
            //    entidade.Property(x => x.Descricao).IsRequired().HasColumnType("Varchar(100)");
            //    entidade.Property(x => x.Valor).IsRequired();
            //    entidade.Property(x => x.TipoCalculo).HasConversion<int>().IsRequired();


            //});

            //modelBuilder.Entity<Veiculo>(entidade =>
            //{

            //    entidade.ToTable("TBVeiculo");
            //    entidade.Property(x => x.Id).ValueGeneratedNever();
            //    entidade.Property(x => x.Modelo).IsRequired().HasColumnType("Varchar(100)");
            //    entidade.Property(x => x.Placa).IsRequired().HasColumnType("Varchar(10)");
            //    entidade.Property(x => x.Marca).IsRequired().HasColumnType("Varchar(100)");
            //    entidade.Property(x => x.Cor).IsRequired().HasColumnType("Varchar(100)");
            //    entidade.Property(x => x.TipoCombustivel).IsRequired().HasConversion<int>();
            //    entidade.Property(x => x.CapacidadeTanque).IsRequired();
            //    entidade.Property(x => x.Ano).IsRequired();
            //    entidade.Property(x => x.QuilometragemPercorrida).IsRequired();
            //    entidade.HasOne(x => x.GrupoVeiculo);
            //    entidade.Property(x => x.Foto).HasColumnType("Varbinary(max)").IsRequired();


            //});

            var dllComConfiguracoesOrm = typeof(LocadoraVeiculosDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);

        }
    }
}
