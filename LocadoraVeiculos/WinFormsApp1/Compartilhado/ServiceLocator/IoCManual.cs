using LocadoraVeiculos.Aplicacao.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Infra.Orm.ModuloCliente.ModuloEmpresa;
using LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace LocadoraVeiculosForm.Compartilhado.ServiceLocator
{
    public class IoCManual : IServiceLocator
    {

        private Dictionary<string, ControladorBase> controladores;

        public IoCManual()
        {
            controladores = new Dictionary<string, ControladorBase>();

            ConfigurarControladores();
        }

        private void ConfigurarControladores()
        {

            var configuracao = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("ConfiguracaoAplicacao.json")
                 .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var contextoDadosOrm = new LocadoraVeiculosDbContext(connectionString);

            //var repositorioDisciplina = new RepositorioDisciplinaEmArquivo(contextoDados);
            var repositorioEmpresa = new RepositorioEmpresaOrm(contextoDadosOrm);
            var servicoEmpresa = new ServicoEmpresa(repositorioEmpresa, contextoDadosOrm);
            controladores.Add("ControladorEmpresa", new ControladorEmpresa(servicoEmpresa));

        }

        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return (T)controladores[nomeControlador];
        }
    }
}
