using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloGrupoVeiculos
{
    [TestClass]

    public class RepositorioGrupoVeiculosEmBancoDadosTest
    {
        private GrupoVeiculos _grupoVeiculos;
        private RepositorioGrupoVeiculosEmBancoDados _repositorio;

        public RepositorioGrupoVeiculosEmBancoDadosTest()
        {
            _grupoVeiculos = new GrupoVeiculos("Uber");
            _repositorio = new RepositorioGrupoVeiculosEmBancoDados();

            _repositorio.SetEnderecoBanco(EnderecoBancoConst.EnderecoBancoTeste);

            Db.SetEnderecoBanco(EnderecoBancoConst.EnderecoBancoTeste);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULO; DBCC CHECKIDENT (TBGRUPOVEICULO, RESEED, 0)");
        }
       
        [TestMethod]
        public void Deve_inserir_novo_grupo_veiculos()
        {
            //action
            _repositorio.Inserir(_grupoVeiculos);
       
            //assert
            var grupoVeiculosEncontrado = _repositorio.SelecionarPorId(_grupoVeiculos.Id);
       
            Assert.IsNotNull(grupoVeiculosEncontrado);
            Assert.AreEqual(_grupoVeiculos, grupoVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_grupoVeiculos()
        {
            //arrange
            _repositorio.Inserir(_grupoVeiculos);

            //action
            _grupoVeiculos.Nome = "Suv";
            _repositorio.Editar(_grupoVeiculos);

            //assert
            var grupoVeiculosEncontrado = _repositorio.SelecionarPorId(_grupoVeiculos.Id);

            Assert.IsNotNull(grupoVeiculosEncontrado);
            Assert.AreEqual(_grupoVeiculos, grupoVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_grupoVeiculo()
        {
            //arrange
            _repositorio.Inserir(_grupoVeiculos);

            //action
            _repositorio.Excluir(_grupoVeiculos);

            //assert
            var grupoVeiculosEncontrado = _repositorio.SelecionarPorId(_grupoVeiculos.Id);

            Assert.IsNull(grupoVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_grupoVeiculos()
        {
            //arrange
            _repositorio.Inserir(_grupoVeiculos);

            //action
            var grupoVeiculosEncontrado = _repositorio.SelecionarPorId(_grupoVeiculos.Id);

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

            _repositorio.Inserir(grupoVeiculos1);
            _repositorio.Inserir(grupoVeiculos2);
            _repositorio.Inserir(grupoVeiculos3);

            //action
            var grupoVeiculos = _repositorio.SelecionarTodos();

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
            _repositorio.Inserir(_grupoVeiculos);

            //action
            //var grupoVeiculosExiste = _repositorio.GrupoVeiculosJaExiste("Uber");

            ////assert
            //Assert.AreEqual(grupoVeiculosExiste, true);
        }

        [TestMethod]
        public void Deve_retornar_false_quando_funcionario_nao_existir()
        {
            //arrange
            _repositorio.Inserir(_grupoVeiculos);

            //action
            //var grupoVeiculosExiste = _repositorio.GrupoVeiculosJaExiste("Sedan");

            ////assert
            //Assert.AreEqual(grupoVeiculosExiste, false);
        }

        [TestMethod]
        public void Deve_inserir_somente_se_nome_tiver_mais_que_3_caracteres()
        {
            //arrange
            var grupoVeiculos = new GrupoVeiculos("Ha");

            //action
            _repositorio.Inserir(grupoVeiculos);

            //assert
            var grupoVeiculosEncontrado = _repositorio.SelecionarPorId(grupoVeiculos.Id);

            Assert.IsNull(grupoVeiculosEncontrado);
            Assert.AreEqual(grupoVeiculosEncontrado, null);
        }

        [TestMethod]
        public void Nao_deve_inserir_se_nome_tiver_caracteres_especiais()
        {
            //arrange
            var grupoVeiculos = new GrupoVeiculos("Eco4@sdv");

            //action
            _repositorio.Inserir(grupoVeiculos);

            //assert
            var grupoVeiculosEncontrado = _repositorio.SelecionarPorId(grupoVeiculos.Id);

            Assert.IsNull(grupoVeiculosEncontrado);
            Assert.AreEqual(grupoVeiculosEncontrado, null);
        }

    }
}
