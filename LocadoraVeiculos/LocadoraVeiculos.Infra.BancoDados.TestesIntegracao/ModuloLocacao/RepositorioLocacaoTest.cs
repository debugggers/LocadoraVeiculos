using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Infra.Orm.ModuloLocacao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloLocacao
{
    [TestClass]
    public class RepositorioLocacaoTest
    {
        private Locacao _locacao;
        private RepositorioLocacaoOrm _repositorioLocacao;
        private ServicoLocacao _servicoLocacao;
        private LocadoraVeiculosDbContext _dbContext;
        private IContext _contexto;

        public RepositorioLocacaoTest()
        {
            _locacao = new Locacao
            {
                Funcionario = new Funcionario("Tatiane", "tatimossi", "1234567", DateTime.Now.Date, 12000m, true),
                FuncionarioId = new Guid(),
                Cliente = new Cliente("Thiago", "thi@email.com", "49999537888", "Rua 123", "04954080932", 123456789, "Thiago", new DateTime(2060, 07, 07)),
                ClienteId = new Guid(),
                GrupoVeiculos = new GrupoVeiculos("SUV"),
                GrupoVeiculosId = new Guid(),
                Taxas = new List<Taxa>(),
                PlanosCobranca = PlanoCobrancaEnum.Livre,
                Veiculo = new Veiculo
                {
                    Marca = "Peugeot",
                    Placa = "QJG0D76",
                    Modelo = "3008",
                    Cor = "Branca",
                    Ano = 2019,
                    CapacidadeTanque = 55,
                    QuilometragemPercorrida = 45,
                    TipoCombustivel = 0,
                    Foto = new byte[10],
                    GrupoVeiculo = _locacao.GrupoVeiculos
                },
                VeiculoId = new Guid(),
                DataLocacao = DateTime.Now.Date,
                DataPrevistaEntrega = DateTime.Now.AddDays(1).Date,
                ValorPrevisto = 500m
            };

            _repositorioLocacao = new RepositorioLocacaoOrm(_dbContext);
            _servicoLocacao = new ServicoLocacao(_repositorioLocacao, _contexto);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Db.ExecutarSql("DELETE FROM TBLOCACAO");
        }

        [TestMethod]
        public void Deve_inserir_nova_locacao()
        {
            //action
            _servicoLocacao.Inserir(_locacao);

            //assert
            var locacaoEncontrada = _repositorioLocacao.SelecionarPorId(_locacao.Id);

            Assert.IsNotNull(locacaoEncontrada);
            Assert.AreEqual(_locacao, locacaoEncontrada);
        }
    }
}
