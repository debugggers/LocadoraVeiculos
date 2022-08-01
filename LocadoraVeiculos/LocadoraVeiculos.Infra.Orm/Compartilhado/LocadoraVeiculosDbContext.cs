using LocadoraVeiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LocadoraVeiculos.Infra.Orm.Compartilhado
{
    public class LocadoraVeiculosDbContext : DbContext, IContext
    {

        private string _connectionString;

        public LocadoraVeiculosDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void GravarDados()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            ILoggerFactory loggerFactory = LoggerFactory.Create((x) =>
            {
                x.AddSerilog(Log.Logger);
            });

            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dllComConfiguracoesOrm = typeof(LocadoraVeiculosDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);
        }
    }
}
