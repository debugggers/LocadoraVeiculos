using Autofac;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.BancoDados.ModuloFuncionario;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.BancoDados.ModuloPlanoCobranca;
using LocadoraVeiculos.BancoDados.ModuloTaxa;
using LocadoraVeiculos.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculosForm.ModuloCliente;
using LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculosForm.ModuloFuncionario;
using LocadoraVeiculosForm.ModuloGrupoVeiculos;
using LocadoraVeiculosForm.ModuloPlanoCobranca;
using LocadoraVeiculosForm.ModuloTaxa;
using LocadoraVeiculosForm.ModuloVeiculo;

namespace LocadoraVeiculosForm.Compartilhado.ServiceLocator
{
    public class IoCAutoFac : IServiceLocator
    {

        private readonly IContainer container;

        public IoCAutoFac()
        {

            var builder = new ContainerBuilder();

            builder.RegisterType<RepositorioClienteEmBancoDados>().As<IRepositorioCliente>();
            builder.RegisterType<ServicoCliente>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<RepositorioGrupoVeiculosEmBancoDados>().As<IRepositorioGrupoVeiculos>();
            builder.RegisterType<ServicoGrupoVeiculos>().AsSelf();
            builder.RegisterType<ControladorGupoVeiculos>().AsSelf();

            builder.RegisterType<RepositorioFuncionarioEmBancoDados>().As<IRepositorioFuncionario>();
            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            builder.RegisterType<RepositorioEmpresaBancoDados>().As<IRepositorioEmpresa>();
            builder.RegisterType<ServicoEmpresa>().AsSelf();
            builder.RegisterType<ControladorEmpresa>().AsSelf();

            builder.RegisterType<RepositorioTaxaEmBancoDados>().As<IRepositorioTaxa>();
            builder.RegisterType<ServicoTaxa>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();

            builder.RegisterType<RepositorioVeiculoEmBancoDados>().As<IRepositorioVeiculo>();
            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            builder.RegisterType<RepositorioPlanoCobrancaEmBancoDados>().As<IRepositorioPlanoCobranca>();
            builder.RegisterType<ServicoPlanoCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoCobranca>().AsSelf();

            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }

        public T GetGeneric<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}
