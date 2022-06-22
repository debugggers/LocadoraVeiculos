using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloCliente
{
    [TestClass]

    public class RepositorioClienteEmBancoDadosTest
    {

        private Cliente cliente;
        private CNH cnh;
        private RepositorioClienteEmBancoDados repositorio;

        public RepositorioClienteEmBancoDadosTest()
        {

            cliente = new Cliente();

            cliente.Nome = "Paulo";
            cliente.Email = "Paulo@teste.com";
            cliente.Telefone = "123456789";
            cliente.Endereco = "123, rua 123, 123";
            cliente.CPF = "1234567890";

            cnh = new CNH();

            cnh.Numero = 123;
            cnh.Nome = "Paulo";
            cnh.Vencimento = DateTime.Now.Date;

            cliente.Cnh = cnh;

            repositorio = new RepositorioClienteEmBancoDados();

        }

        [TestMethod]
        public void Deve_Inserir_Cliente()
        {

            //action
            repositorio.Inserir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente.Id, clienteEncontrado.Id);

        }
    }
}
