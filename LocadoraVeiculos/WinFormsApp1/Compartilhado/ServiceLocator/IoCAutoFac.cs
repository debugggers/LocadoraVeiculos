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
using LocadoraVeiculosForm.ModuloCliente;
using LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculosForm.ModuloFuncionario;
using LocadoraVeiculosForm.ModuloGrupoVeiculos;
using LocadoraVeiculosForm.ModuloPlanoCobranca;
using LocadoraVeiculosForm.ModuloTaxa;
using LocadoraVeiculosForm.ModuloVeiculo;
using System;

namespace LocadoraVeiculosForm.Compartilhado.ServiceLocator
{
    public class IoCAutoFac : IServiceLocator
    {

        private readonly IContainer container;

        public IoCAutoFac()
        {

            var builder = new ContainerBuilder();

            builder.RegisterType<RepositorioClienteEmBancoDados>().AsSelf();
            builder.RegisterType<ServicoCliente>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<RepositorioGrupoVeiculosEmBancoDados>().AsSelf();
            builder.RegisterType<ServicoGrupoVeiculos>().AsSelf();
            builder.RegisterType<ControladorGupoVeiculos>().AsSelf();

            builder.RegisterType<RepositorioFuncionarioEmBancoDados>().AsSelf();
            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            builder.RegisterType<RepositorioEmpresaBancoDados>().AsSelf();
            builder.RegisterType<ServicoEmpresa>().AsSelf();
            builder.RegisterType<ControladorEmpresa>().AsSelf();

            builder.RegisterType<RepositorioTaxaEmBancoDados>().AsSelf();
            builder.RegisterType<ServicoTaxa>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();

            builder.RegisterType<RepositorioVeiculoEmBancoDados>().AsSelf();
            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            builder.RegisterType<RepositorioPlanoCobrancaEmBancoDados>().AsSelf();
            builder.RegisterType<ServicoPlanoCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoCobranca>().AsSelf();

            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}
