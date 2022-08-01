using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.Compartilhado
{
    public static class MigradorBancoDeDados
    {
        public static void AtualizarBancoDados()
        {
            var configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("ConfiguracaoAplicacao.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var db = new LocadoraVeiculosDbContext(connectionString);

            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
                db.Database.Migrate();
        }
    }
}
