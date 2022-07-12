using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloGrupoVeiculos
{
    [TestClass]

    public class RepositorioGrupoVeiculosEmBancoDadosTest
    {
        private GrupoVeiculos _grupoVeiculos;
        private RepositorioGrupoVeiculosEmBancoDados _repositorioGrupoVeiculos;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;

        public RepositorioGrupoVeiculosEmBancoDadosTest()
        {
            _grupoVeiculos = new GrupoVeiculos("Uber");
            _repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
            servicoGrupoVeiculos = new ServicoGrupoVeiculos(_repositorioGrupoVeiculos);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULO;");
        }
       
        [TestMethod]
        public void Deve_inserir_novo_grupo_veiculos()
        {
            //action
            servicoGrupoVeiculos.Inserir(_grupoVeiculos);
       
            //assert
            var grupoVeiculosEncontrado = _repositorioGrupoVeiculos.SelecionarPorId(_grupoVeiculos.Id);
       
            Assert.IsNotNull(grupoVeiculosEncontrado);
            Assert.AreEqual(_grupoVeiculos, grupoVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_grupoVeiculos()
        {
            //arrange
            servicoGrupoVeiculos.Inserir(_grupoVeiculos);

            //action
            _grupoVeiculos.Nome = "Suv";
            servicoGrupoVeiculos.Editar(_grupoVeiculos);

            //assert
            var grupoVeiculosEncontrado = _repositorioGrupoVeiculos.SelecionarPorId(_grupoVeiculos.Id);

            Assert.IsNotNull(grupoVeiculosEncontrado);
            Assert.AreEqual(_grupoVeiculos, grupoVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_grupoVeiculo()
        {
            //arrange
            servicoGrupoVeiculos.Inserir(_grupoVeiculos);

            //action
            _repositorioGrupoVeiculos.Excluir(_grupoVeiculos);

            //assert
            var grupoVeiculosEncontrado = _repositorioGrupoVeiculos.SelecionarPorId(_grupoVeiculos.Id);

            Assert.IsNull(grupoVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_grupoVeiculos()
        {
            //arrange
            servicoGrupoVeiculos.Inserir(_grupoVeiculos);

            //action
            var grupoVeiculosEncontrado = _repositorioGrupoVeiculos.SelecionarPorId(_grupoVeiculos.Id);

            //assert
            Assert.IsNotNull(grupoVeiculosEncontrado);
            Assert.AreEqual(_grupoVeiculos, grupoVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_grupoVeiculos()
        {
            //arrange
            var grupoVeiculos1 = new GrupoVeiculos("Suv");
            var grupoVeiculos2 = new GrupoVeiculos("Popular");
            var grupoVeiculos3 = new GrupoVeiculos("Esportivo");

            servicoGrupoVeiculos.Inserir(grupoVeiculos1);
            servicoGrupoVeiculos.Inserir(grupoVeiculos2);
            servicoGrupoVeiculos.Inserir(grupoVeiculos3);

            //action
            var grupoVeiculos = _repositorioGrupoVeiculos.SelecionarTodos();

            //assert
            Assert.AreEqual(3, grupoVeiculos.Count);
            Assert.AreEqual(grupoVeiculos1, grupoVeiculos[0]);
            Assert.AreEqual(grupoVeiculos2, grupoVeiculos[1]);
            Assert.AreEqual(grupoVeiculos3, grupoVeiculos[2]);
        }

        [TestMethod]
        public void Deve_retornar_true_quando_grupoVeiculos_ja_existir()
        {
            //arrange
            servicoGrupoVeiculos.Inserir(_grupoVeiculos);

            //action
            var grupoVeiculosExiste = _repositorioGrupoVeiculos.SelecionarGrupoVeiculosPorNome("Uber");

            //assert
            Assert.AreEqual(grupoVeiculosExiste, _grupoVeiculos);
        }

        [TestMethod]
        public void Deve_inserir_somente_se_nome_tiver_mais_que_3_caracteres()
        {
            //arrange
            var grupoVeiculos = new GrupoVeiculos("Ha");

            //action
            servicoGrupoVeiculos.Inserir(grupoVeiculos);

            //assert
            var grupoVeiculosEncontrado = _repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);

            Assert.IsNull(grupoVeiculosEncontrado);
            Assert.AreEqual(grupoVeiculosEncontrado, null);
        }

        [TestMethod]
        public void Nao_deve_inserir_se_nome_tiver_caracteres_especiais()
        {
            //arrange
            var grupoVeiculos = new GrupoVeiculos("Eco4@sdv");

            //action
            servicoGrupoVeiculos.Inserir(grupoVeiculos);

            //assert
            var grupoVeiculosEncontrado = _repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);

            Assert.IsNull(grupoVeiculosEncontrado);
            Assert.AreEqual(grupoVeiculosEncontrado, null);
        }
    }
}
