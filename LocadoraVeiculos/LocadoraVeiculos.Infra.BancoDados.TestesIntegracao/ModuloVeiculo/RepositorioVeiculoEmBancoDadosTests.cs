using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDadosTests
    {

        private Veiculo _veiculo;
        private GrupoVeiculos _grupoVeiculos;
        private RepositorioVeiculoEmBancoDados _repositorioVeiculo;
        private ServicoVeiculo _servicoVeiculo;
        private ServicoGrupoVeiculos _servicoGrupoVeiculos;
        private RepositorioGrupoVeiculosEmBancoDados _repositorioGrupoVeiculos;
        IContext context;

        public RepositorioVeiculoEmBancoDadosTests()
        {
            _repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
            _servicoGrupoVeiculos = new ServicoGrupoVeiculos(_repositorioGrupoVeiculos, context);

            _grupoVeiculos = new GrupoVeiculos
            {
                Nome = "Grupo"
            };

            _veiculo = new Veiculo
            {
                Marca = "Ford",
                Placa = "abc123",
                Modelo = "Ranger",
                Cor = "Azul",
                Ano = 2017,
                CapacidadeTanque = 200,
                QuilometragemPercorrida = 1,
                TipoCombustivel = 0,
                Foto = new byte[10],
                GrupoVeiculo = _grupoVeiculos
            };

            _repositorioVeiculo = new RepositorioVeiculoEmBancoDados();
            _servicoVeiculo = new ServicoVeiculo(_repositorioVeiculo, context);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Db.ExecutarSql("DELETE FROM TBVEICULO;");
            Db.ExecutarSql("DELETE FROM TBPLANOCOBRANCA;");
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULO;");
        }

        [TestMethod]
        public void Deve_Inserir_Veiculo()
        {
            _servicoGrupoVeiculos.Inserir(_grupoVeiculos);
            _servicoVeiculo.Inserir(_veiculo);

            var veiculoEncontrado = _repositorioVeiculo.SelecionarPorId(_veiculo.Id);

            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(_veiculo.Marca, veiculoEncontrado.Marca);
            Assert.AreEqual(_veiculo.Modelo, veiculoEncontrado.Modelo);
            Assert.AreEqual(_veiculo.Placa, veiculoEncontrado.Placa);
            Assert.AreEqual(_veiculo.GrupoVeiculo, veiculoEncontrado.GrupoVeiculo);
            Assert.AreEqual(_veiculo.CapacidadeTanque, veiculoEncontrado.CapacidadeTanque);
            Assert.AreEqual(_veiculo.Ano, veiculoEncontrado.Ano);
            Assert.AreEqual(_veiculo.Cor, veiculoEncontrado.Cor);
            Assert.AreEqual(_veiculo.QuilometragemPercorrida, veiculoEncontrado.QuilometragemPercorrida);
            Assert.AreEqual(_veiculo.TipoCombustivel, veiculoEncontrado.TipoCombustivel);
        }

        [TestMethod]
        public void Deve_Editar_Veiculo()
        {
            _servicoGrupoVeiculos.Inserir(_grupoVeiculos);
            _servicoVeiculo.Inserir(_veiculo);

            _veiculo.Marca = "drof";
            _veiculo.Placa = "123abc";
            _veiculo.Modelo = "regnar";
            _veiculo.Cor = "vermelho";
            _veiculo.Ano = 2016;
            _veiculo.CapacidadeTanque = 250;
            _veiculo.QuilometragemPercorrida = 150;
            _veiculo.TipoCombustivel = CombustivelEnum.Etanol;

            _servicoVeiculo.Editar(_veiculo);

            var veiculoEncontrado = _repositorioVeiculo.SelecionarPorId(_veiculo.Id);

            Assert.IsNotNull(veiculoEncontrado);
            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(_veiculo.Id, veiculoEncontrado.Id);
            Assert.AreEqual(_veiculo.Marca, veiculoEncontrado.Marca);
            Assert.AreEqual(_veiculo.Modelo, veiculoEncontrado.Modelo);
            Assert.AreEqual(_veiculo.Placa, veiculoEncontrado.Placa);
            Assert.AreEqual(_veiculo.GrupoVeiculo, veiculoEncontrado.GrupoVeiculo);
            Assert.AreEqual(_veiculo.CapacidadeTanque, veiculoEncontrado.CapacidadeTanque);
            Assert.AreEqual(_veiculo.Ano, veiculoEncontrado.Ano);
            Assert.AreEqual(_veiculo.Cor, veiculoEncontrado.Cor);
            Assert.AreEqual(_veiculo.QuilometragemPercorrida, veiculoEncontrado.QuilometragemPercorrida);
            Assert.AreEqual(_veiculo.TipoCombustivel, veiculoEncontrado.TipoCombustivel);
        }

        [TestMethod]
        public void Deve_Excluir_Veiculo()
        {
            _servicoGrupoVeiculos.Inserir(_grupoVeiculos);
            _servicoVeiculo.Inserir(_veiculo);

            _repositorioVeiculo.Excluir(_veiculo);

            var veiculoEncontrado = _repositorioVeiculo.SelecionarPorId(_veiculo.Id);

            Assert.IsNull(veiculoEncontrado);
        }

        [TestMethod]
        public void Deve_Selecionar_Veiculo()
        {
            _servicoGrupoVeiculos.Inserir(_grupoVeiculos);
            _servicoVeiculo.Inserir(_veiculo);

            var veiculoEncontrado = _repositorioVeiculo.SelecionarPorId(_veiculo.Id);

            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(_veiculo.Id, veiculoEncontrado.Id);
            Assert.AreEqual(_veiculo.Marca, veiculoEncontrado.Marca);
            Assert.AreEqual(_veiculo.Modelo, veiculoEncontrado.Modelo);
            Assert.AreEqual(_veiculo.Placa, veiculoEncontrado.Placa);
            Assert.AreEqual(_veiculo.GrupoVeiculo, veiculoEncontrado.GrupoVeiculo);
            Assert.AreEqual(_veiculo.CapacidadeTanque, veiculoEncontrado.CapacidadeTanque);
            Assert.AreEqual(_veiculo.Ano, veiculoEncontrado.Ano);
            Assert.AreEqual(_veiculo.Cor, veiculoEncontrado.Cor);
            Assert.AreEqual(_veiculo.QuilometragemPercorrida, veiculoEncontrado.QuilometragemPercorrida);
            Assert.AreEqual(_veiculo.TipoCombustivel, veiculoEncontrado.TipoCombustivel);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Veiculos()
        {
            _servicoGrupoVeiculos.Inserir(_grupoVeiculos);
            _servicoVeiculo.Inserir(_veiculo);

            Veiculo veiculo1 = new Veiculo
            {
                Marca = "drof",
                Placa = "123abc",
                Modelo = "regnar",
                Cor = "vermelho",
                Ano = 2018,
                CapacidadeTanque = 250,
                QuilometragemPercorrida = 150,
                TipoCombustivel = 0,
                Foto = new byte[10],
                GrupoVeiculo = _grupoVeiculos
            };

            _servicoVeiculo.Inserir(veiculo1);

            var veiculosEncontrados = _repositorioVeiculo.SelecionarTodos();

            Assert.AreEqual(2, veiculosEncontrados.Count);
            Assert.AreEqual(_veiculo.Id, veiculosEncontrados[0].Id);
            Assert.AreEqual(veiculo1.Id, veiculosEncontrados[1].Id);
        }
    }
}
