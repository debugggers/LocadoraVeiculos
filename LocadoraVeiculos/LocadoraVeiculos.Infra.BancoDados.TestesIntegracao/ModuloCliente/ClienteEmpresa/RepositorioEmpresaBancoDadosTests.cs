using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloCliente.ClienteEmpresa
{
    [TestClass]
    public class RepositorioEmpresaBancoDadosTests
    {

        private Empresa empresa;
        Cliente cliente;
        private RepositorioEmpresaBancoDados repositorio;
        private RepositorioClienteEmBancoDados repositorioCliente;

        public RepositorioEmpresaBancoDadosTests()
        {

            repositorioCliente = new RepositorioClienteEmBancoDados();

            string sql =
               @"DELETE FROM TBEMPRESA;
                  DBCC CHECKIDENT (TBEMPRESA, RESEED, 0)
                DELETE FROM TBCLIENTE;
                  DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)
                ";

            Db.ExecutarSql(sql);

            empresa = new Empresa();

            empresa.Nome = "EmpresaPaulo";
            empresa.Email = "EmpresaPaulo@teste.com";
            empresa.Telefone = "123456789";
            empresa.Endereco = "123, rua 123, 123";
            empresa.CNPJ = "12.123.123/0001-12";
            cliente = new Cliente
            {

                Nome = "Paulo",
                Email = "Paulo@teste.com",
                Telefone = "123456789",
                Endereco = "123, rua 123, 123",
                CPF = "123.123.123-12",
                CnhNumero = 123,
                CnhNome = "Paulo",
                CnhVencimento = DateTime.Now.Date.AddMonths(6),

            };

            empresa.Condutor = cliente;

            repositorio = new RepositorioEmpresaBancoDados();

        }

        [TestMethod]
        public void Deve_Inserir_Empresa()
        {

            repositorioCliente.Inserir(cliente);
            repositorio.Inserir(empresa);

            var empresaEncontrada = repositorio.SelecionarPorId(empresa.Id);

            Assert.IsNotNull(empresaEncontrada);
            Assert.AreEqual(empresa, empresaEncontrada);

        }

        [TestMethod]
        public void Deve_Editar_Empresa()
        {

            repositorioCliente.Inserir(cliente);
            repositorio.Inserir(empresa);

            empresa.Nome = "PedroEmpresa";
            empresa.Email = "EmpresaPedro@teste.com";
            empresa.Telefone = "987654321";
            empresa.Endereco = "321, rua 321, 321";
            empresa.CNPJ = "12.321.123/0001-12";
            empresa.Condutor = cliente;
            repositorio.Editar(empresa);

            var empresaEncontrada = repositorio.SelecionarPorId(empresa.Id);

            Assert.IsNotNull(empresaEncontrada);
            Assert.AreEqual(empresa, empresaEncontrada);

        }

        [TestMethod]
        public void Deve_Excluir_Empresa()
        {

            repositorioCliente.Inserir(cliente);

            repositorio.Inserir(empresa);

            repositorio.Excluir(empresa);

            var empresaEncontrada = repositorio.SelecionarPorId(empresa.Id);
            Assert.IsNull(empresaEncontrada);

        }

        [TestMethod]
        public void Deve_Selecionar_Empresa()
        {

            repositorioCliente.Inserir(cliente);

            repositorio.Inserir(empresa);

            var empresaEncontrada = repositorio.SelecionarPorId(empresa.Id);

            Assert.IsNotNull(empresaEncontrada);
            Assert.AreEqual(empresa, empresaEncontrada);

        }
    }
}
