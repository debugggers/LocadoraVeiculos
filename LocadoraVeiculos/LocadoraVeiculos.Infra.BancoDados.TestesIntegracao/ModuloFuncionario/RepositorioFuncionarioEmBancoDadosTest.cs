using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloFuncionario
{
    [TestClass]

    public class RepositorioFuncionarioEmBancoDadosTest
    {
        private Funcionario _funcionario;
        private RepositorioFuncionarioEmBancoDados _repositorio;

        public RepositorioFuncionarioEmBancoDadosTest()
        {
            _funcionario = new Funcionario("Tatiane Mossi", "tatimossi", "12345", new DateTime(2022,02,02), 2000.00m, true);
            _repositorio = new RepositorioFuncionarioEmBancoDados();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT (TBFUNCIONARIO, RESEED, 0)");
        }

        [TestMethod]
        public void Deve_inserir_novo_funcionario()
        {
            //action
            _repositorio.Inserir(_funcionario);

            //assert
            var funcionarioEncontrado = _repositorio.SelecionarPorId(_funcionario.Id);

            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(_funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_funcionario()
        {
            //arrange
            _repositorio.Inserir(_funcionario);

            //action
            _funcionario.Nome = "Thiago Souza";
            _funcionario.Login = "thiagosouza";
            _funcionario.Senha = "13579";
            _funcionario.DataAdmissao = new DateTime(2022, 02, 02);
            _funcionario.Salario = 5500.00m;
            _funcionario.EhAdmin = false;
            _repositorio.Editar(_funcionario);

            //assert
            var funcionarioEncontrado = _repositorio.SelecionarPorId(_funcionario.Id);

            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(_funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange
            _repositorio.Inserir(_funcionario);

            //action
            _repositorio.Excluir(_funcionario);

            //assert
            var funcionarioEncontrado = _repositorio.SelecionarPorId(_funcionario.Id);

            Assert.IsNull(funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_funcionario()
        {
            //arrange
            _repositorio.Inserir(_funcionario);

            //action
            var funcionarioEncontrado = _repositorio.SelecionarPorId(_funcionario.Id);

            //assert
            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(_funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_funcionarios()
        {
            //arrange
            var funcionario1 = new Funcionario("Thiago Souza", "thiagosouza", "12345", new DateTime(2022, 02, 03), 3000.00m, false);
            var funcionario2 = new Funcionario("Rosimeri Morais", "merimorais", "13579", new DateTime(2022, 02, 04), 4000.00m, true);
            var funcionario3 = new Funcionario("Ademir Jaco Mossi", "milamossi", "24680", new DateTime(2022, 02, 05), 5000.00m, false);

            var repositorio = new RepositorioFuncionarioEmBancoDados();

            repositorio.Inserir(funcionario1);
            repositorio.Inserir(funcionario2);
            repositorio.Inserir(funcionario3);

            //action
            var funcionarios = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(3, funcionarios.Count);
            Assert.AreEqual(funcionario1, funcionarios[0]);
            Assert.AreEqual(funcionario2, funcionarios[1]);
            Assert.AreEqual(funcionario3, funcionarios[2]);
        }

        [TestMethod]
        public void Deve_retornar_true_quando_funcionario_ja_existir()
        {
            //arrange
            _repositorio.Inserir(_funcionario);

            //action
            var funcionarioExiste = _repositorio.FuncionarioJaExiste("Tatiane Mossi");

            //assert
            Assert.AreEqual(funcionarioExiste, true);
        }

        [TestMethod]
        public void Deve_retornar_false_quando_funcionario_nao_existir()
        {
            //arrange
            _repositorio.Inserir(_funcionario);

            //action
            var funcionarioExiste = _repositorio.FuncionarioJaExiste("Thiago Souza");

            //assert
            Assert.AreEqual(funcionarioExiste, false);
        }

        [TestMethod]
        public void Deve_inserir_somente_se_nome_tiver_mais_que_2_caracteres()
        {
            //arrange
            var funcionario = new Funcionario("Ha", "tatimossi", "12345", new DateTime(2022, 06, 24), 2200.00m, false);

            //action
            _repositorio.Inserir(funcionario);

            //assert
            var funcionarioEncontrado = _repositorio.SelecionarPorId(funcionario.Id);

            Assert.IsNull(funcionarioEncontrado);
            Assert.AreEqual(funcionarioEncontrado, null);
        }

        [TestMethod]
        public void Nao_deve_inserir_se_nome_tiver_caracteres_especiais()
        {
            //arrange
            var funcionario = new Funcionario("T@ti4ne", "tatimossi", "12345", new DateTime(2022, 06, 24), 2200.00m, false);

            //action
            _repositorio.Inserir(funcionario);

            //assert
            var funcionarioEncontrado = _repositorio.SelecionarPorId(funcionario.Id);

            Assert.IsNull(funcionarioEncontrado);
            Assert.AreEqual(funcionarioEncontrado, null);
        }
    }
}
