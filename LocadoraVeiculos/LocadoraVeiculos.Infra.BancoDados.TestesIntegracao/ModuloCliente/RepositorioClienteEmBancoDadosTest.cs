using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloCliente
{
    [TestClass]

    public class RepositorioClienteEmBancoDadosTest
    {
        private Cliente cliente;
        private RepositorioClienteEmBancoDados repositorio;
        private ServicoCliente servico;

        public RepositorioClienteEmBancoDadosTest()
        {
            cliente = new Cliente();

            cliente.Nome = "Paulo";
            cliente.Email = "Paulo@teste.com";
            cliente.Telefone = "123456789";
            cliente.Endereco = "123, rua 123, 123";
            cliente.CPF = "123.123.123-12";
            cliente.CnhNumero = 123;
            cliente.CnhNome = "Paulo";
            cliente.CnhVencimento = DateTime.Now.Date.AddMonths(6);

            repositorio = new RepositorioClienteEmBancoDados();
            servico = new ServicoCliente(repositorio);
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
            servico.Inserir(cliente);

            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_Editar_Cliente()
        {
            servico.Inserir(cliente);

            cliente.Nome = "Pedro";
            cliente.Email = "Pedro@teste.com";
            cliente.Telefone = "987654321";
            cliente.Endereco = "321, rua 321, 321";
            cliente.CPF = "321.123.123-12";
            cliente.CnhNumero = 321;
            cliente.CnhNome = "Pedro";
            cliente.CnhVencimento = DateTime.Now.Date.AddMonths(6);
            servico.Editar(cliente);

            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_Excluir_Cliente()
        {
            servico.Inserir(cliente);

            repositorio.Excluir(cliente);

            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);
            Assert.IsNull(clienteEncontrado);
        }

        [TestMethod]
        public void Deve_Selecionar_Cliente()
        {
            servico.Inserir(cliente);

            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

    }
}
