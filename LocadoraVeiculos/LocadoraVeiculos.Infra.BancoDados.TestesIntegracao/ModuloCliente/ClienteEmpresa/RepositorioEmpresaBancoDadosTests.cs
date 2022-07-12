using LocadoraVeiculos.Aplicacao.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloCliente.ClienteEmpresa
{
    [TestClass]
    public class RepositorioEmpresaBancoDadosTests
    {

        private Empresa _empresa;
        private RepositorioEmpresaBancoDados _repositorio;
        private ServicoEmpresa _servico;

        public RepositorioEmpresaBancoDadosTests()
        {
            _empresa = new Empresa
            {
                Nome = "EmpresaPaulo",
                Email = "EmpresaPaulo@teste.com",
                Telefone = "123456789",
                Endereco = "123, rua 123, 123",
                CNPJ = "12.123.123/0001-12"
            };

            _repositorio = new RepositorioEmpresaBancoDados();
            _servico = new ServicoEmpresa(_repositorio);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Db.ExecutarSql("DELETE FROM TBCLIENTE;");
            Db.ExecutarSql("DELETE FROM TBEMPRESA;");
        }

        [TestMethod]
        public void Deve_Inserir_Empresa()
        {
            _servico.Inserir(_empresa);

            var empresaEncontrada = _repositorio.SelecionarPorId(_empresa.Id);

            Assert.IsNotNull(empresaEncontrada);
            Assert.AreEqual(_empresa, empresaEncontrada);
        }

        [TestMethod]
        public void Deve_Editar_Empresa()
        {
            _servico.Inserir(_empresa);

            _empresa.Nome = "PedroEmpresa";
            _empresa.Email = "EmpresaPedro@teste.com";
            _empresa.Telefone = "987654321";
            _empresa.Endereco = "321, rua 321, 321";
            _empresa.CNPJ = "12.321.123/0001-12";
            _servico.Editar(_empresa);

            var empresaEncontrada = _repositorio.SelecionarPorId(_empresa.Id);

            Assert.IsNotNull(empresaEncontrada);
            Assert.AreEqual(_empresa, empresaEncontrada);
        }

        [TestMethod]
        public void Deve_Excluir_Empresa()
        {
            _servico.Inserir(_empresa);

            _repositorio.Excluir(_empresa);

            var empresaEncontrada = _repositorio.SelecionarPorId(_empresa.Id);
            Assert.IsNull(empresaEncontrada);
        }

        [TestMethod]
        public void Deve_Selecionar_Empresa()
        {
            _servico.Inserir(_empresa);

            var empresaEncontrada = _repositorio.SelecionarPorId(_empresa.Id);

            Assert.IsNotNull(empresaEncontrada);
            Assert.AreEqual(_empresa, empresaEncontrada);
        }
    }
}
