using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDadosTest
    {
        private Cliente _cliente;
        private RepositorioClienteEmBancoDados _repositorioCliente;
        private ServicoCliente _servicoCliente;

        public RepositorioClienteEmBancoDadosTest()
        {
            _cliente = new Cliente();

            _cliente.Nome = "Paulo";
            _cliente.Email = "Paulo@teste.com";
            _cliente.Telefone = "123456789";
            _cliente.Endereco = "123, rua 123, 123";
            _cliente.CPF = "123.123.123-12";
            _cliente.CnhNumero = 123;
            _cliente.CnhNome = "Paulo";
            _cliente.CnhVencimento = DateTime.Now.Date.AddMonths(6);

            _repositorioCliente = new RepositorioClienteEmBancoDados();
            _servicoCliente = new ServicoCliente(_repositorioCliente);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Db.ExecutarSql("DELETE FROM TBCLIENTE;");
            Db.ExecutarSql("DELETE FROM TBEMPRESA;");
        }

        [TestMethod]
        public void Deve_Inserir_Cliente()
        {
            _servicoCliente.Inserir(_cliente);

            var clienteEncontrado = _repositorioCliente.SelecionarPorId(_cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(_cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_Editar_Cliente()
        {
            _servicoCliente.Inserir(_cliente);

            _cliente.Nome = "Pedro";
            _cliente.Email = "Pedro@teste.com";
            _cliente.Telefone = "987654321";
            _cliente.Endereco = "321, rua 321, 321";
            _cliente.CPF = "321.123.123-12";
            _cliente.CnhNumero = 321;
            _cliente.CnhNome = "Pedro";
            _cliente.CnhVencimento = DateTime.Now.Date.AddMonths(6);
            _servicoCliente.Editar(_cliente);

            var clienteEncontrado = _repositorioCliente.SelecionarPorId(_cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(_cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_Excluir_Cliente()
        {
            _servicoCliente.Inserir(_cliente);

            _repositorioCliente.Excluir(_cliente);

            var clienteEncontrado = _repositorioCliente.SelecionarPorId(_cliente.Id);
            Assert.IsNull(clienteEncontrado);
        }

        [TestMethod]
        public void Deve_Selecionar_Cliente()
        {
            _servicoCliente.Inserir(_cliente);

            var clienteEncontrado = _repositorioCliente.SelecionarPorId(_cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(_cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_Clientes()
        {
            //arrange
            var cliente1 = new Cliente("Tatiane", "tati@email.com", "49991846942", "Rua 123",
                "001.001.001-01", 12345678, "Tatiane", new DateTime(2025, 07, 07));
            var cliente2 = new Cliente("Thiago", "thi@email.com", "49999537888", "Rua 456",
                "002.002.002-02", 89012345, "Thiago", new DateTime(2025, 08, 08));
            var cliente3 = new Cliente("Paulo", "paulo@email.com", "49999999999", "Rua 789",
                "003.003.003-03", 356689023, "Paulo", new DateTime(2025, 07, 07));

            _servicoCliente.Inserir(cliente1);
            _servicoCliente.Inserir(cliente2);
            _servicoCliente.Inserir(cliente3);

            //action
            var clientes = _repositorioCliente.SelecionarTodos();

            //assert
            Assert.AreEqual(3, clientes.Count);
            Assert.AreEqual(cliente1, clientes[0]);
            Assert.AreEqual(cliente2, clientes[1]);
            Assert.AreEqual(cliente3, clientes[2]);
        }
    }
}
