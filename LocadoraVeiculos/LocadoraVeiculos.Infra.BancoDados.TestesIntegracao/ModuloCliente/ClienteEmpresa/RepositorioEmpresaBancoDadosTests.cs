using LocadoraVeiculos.Aplicacao.ModuloCliente.ClienteEmpresa;
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
        private RepositorioEmpresaBancoDados repositorio;
        private ServicoEmpresa servico;

        public RepositorioEmpresaBancoDadosTests()
        {

            empresa = new Empresa();

            empresa.Nome = "EmpresaPaulo";
            empresa.Email = "EmpresaPaulo@teste.com";
            empresa.Telefone = "123456789";
            empresa.Endereco = "123, rua 123, 123";
            empresa.CNPJ = "12.123.123/0001-12";

            repositorio = new RepositorioEmpresaBancoDados();
            servico = new ServicoEmpresa(repositorio);

        }

        [TestCleanup()]
        public void Cleanup()
        {
            Db.ExecutarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT(TBCLIENTE, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM TBEMPRESA; DBCC CHECKIDENT (TBEMPRESA, RESEED, 0)");
        }

        [TestMethod]
        public void Deve_Inserir_Empresa()
        {

            servico.Inserir(empresa);

            var empresaEncontrada = repositorio.SelecionarPorId(empresa.Id);

            Assert.IsNotNull(empresaEncontrada);
            Assert.AreEqual(empresa, empresaEncontrada);

        }

        [TestMethod]
        public void Deve_Editar_Empresa()
        {

            servico.Inserir(empresa);

            empresa.Nome = "PedroEmpresa";
            empresa.Email = "EmpresaPedro@teste.com";
            empresa.Telefone = "987654321";
            empresa.Endereco = "321, rua 321, 321";
            empresa.CNPJ = "12.321.123/0001-12";
            servico.Editar(empresa);

            var empresaEncontrada = repositorio.SelecionarPorId(empresa.Id);

            Assert.IsNotNull(empresaEncontrada);
            Assert.AreEqual(empresa, empresaEncontrada);

        }

        [TestMethod]
        public void Deve_Excluir_Empresa()
        {

            servico.Inserir(empresa);

            repositorio.Excluir(empresa);

            var empresaEncontrada = repositorio.SelecionarPorId(empresa.Id);
            Assert.IsNull(empresaEncontrada);

        }

        [TestMethod]
        public void Deve_Selecionar_Empresa()
        {

            servico.Inserir(empresa);

            var empresaEncontrada = repositorio.SelecionarPorId(empresa.Id);

            Assert.IsNotNull(empresaEncontrada);
            Assert.AreEqual(empresa, empresaEncontrada);

        }
    }
}
