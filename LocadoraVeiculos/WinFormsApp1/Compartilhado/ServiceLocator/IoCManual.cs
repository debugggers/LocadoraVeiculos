using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Aplicacao.ModuloDevolucao;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Infra.Orm.ModuloCliente;
using LocadoraVeiculos.Infra.Orm.ModuloCliente.ModuloEmpresa;
using LocadoraVeiculos.Infra.Orm.ModuloDevolucao;
using LocadoraVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraVeiculos.Infra.Orm.ModuloPlanoCobranca;
using LocadoraVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraVeiculos.Infra.Orm.ModuloVeiculo;
using LocadoraVeiculosForm.ModuloCliente;
using LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculosForm.ModuloDevolucao;
using LocadoraVeiculosForm.ModuloFuncionario;
using LocadoraVeiculosForm.ModuloGrupoVeiculos;
using LocadoraVeiculosForm.ModuloLocacao;
using LocadoraVeiculosForm.ModuloPlanoCobranca;
using LocadoraVeiculosForm.ModuloTaxa;
using LocadoraVeiculosForm.ModuloVeiculo;
using Microsoft.Extensions.Configuration;
using System;
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

            var repositorioEmpresa = new RepositorioEmpresaOrm(contextoDadosOrm);
            var servicoEmpresa = new ServicoEmpresa(repositorioEmpresa, contextoDadosOrm);
            controladores.Add(typeof(ControladorEmpresa).Name, new ControladorEmpresa(servicoEmpresa));

            var repositorioFuncionario = new RepositorioFuncionarioOrm(contextoDadosOrm);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, contextoDadosOrm);
            controladores.Add(typeof(ControladorFuncionario).Name, new ControladorFuncionario(servicoFuncionario));

            var repositorioTaxa = new RepositorioTaxaOrm(contextoDadosOrm);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa, contextoDadosOrm);
            controladores.Add(typeof(ControladorTaxa).Name, new ControladorTaxa(servicoTaxa));

            var repositorioGrupoVeiculos = new RepositorioGrupoVeiculoOrm(contextoDadosOrm);
            var servicoGrupoVeiculo = new ServicoGrupoVeiculos(repositorioGrupoVeiculos, contextoDadosOrm);
            controladores.Add(typeof(ControladorGupoVeiculos).Name, new ControladorGupoVeiculos(servicoGrupoVeiculo));

            var repositorioPlanoCobranca = new RepositorioPlanoCobrancaOrm(contextoDadosOrm);
            var servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobranca, contextoDadosOrm);
            controladores.Add(typeof(ControladorPlanoCobranca).Name, new ControladorPlanoCobranca(servicoPlanoCobranca, servicoGrupoVeiculo));

            var repositorioVeiculo = new RepositorioVeiculoOrm(contextoDadosOrm);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo, contextoDadosOrm);
            controladores.Add(typeof(ControladorVeiculo).Name, new ControladorVeiculo(servicoVeiculo, servicoGrupoVeiculo));

            var repositorioCliente = new RepositorioClienteOrm(contextoDadosOrm);
            var servicoCliente = new ServicoCliente(repositorioCliente, contextoDadosOrm);
            controladores.Add(typeof(ControladorCliente).Name, new ControladorCliente(servicoCliente, servicoEmpresa));

            //var repositorioLocacao = new RepositorioLocacaoOrm(contextoDadosOrm);
            //var servicoLocacao = new ServicoLocacao(repositorioLocacao, contextoDadosOrm);
            //controladores.Add(typeof(ControladorLocacao).Name, new ControladorLocacao(servicoLocacao, servicoFuncionario, servicoCliente,
            //        servicoGrupoVeiculo, servicoTaxa, servicoPlanoCobranca, servicoVeiculo));

            //var repositorioDevolucao = new RepositorioDevolucaoOrm(contextoDadosOrm);
            //var servicoDevolucao = new ServicoDevolucao(repositorioDevolucao, contextoDadosOrm);
            //controladores.Add(typeof(ControladorDevolucao).Name, new ControladorDevolucao(servicoDevolucao, servicoLocacao));
        }

        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return (T)controladores[nomeControlador];
        }
    }
}
