using LocadoraVeiculos.Aplicacao.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloCliente.ClienteEmpresa
{
    [TestClass]
    public class RepositorioEmpresaBancoDadosTests
    {
        private Empresa _empresa;
        private RepositorioEmpresaBancoDados _repositorioEmpresa;
        private ServicoEmpresa _servicoEmpresa;

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

            _repositorioEmpresa = new RepositorioEmpresaBancoDados();
            _servicoEmpresa = new ServicoEmpresa(_repositorioEmpresa);
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
            _servicoEmpresa.Inserir(_empresa);

            var empresaEncontrada = _repositorioEmpresa.SelecionarPorId(_empresa.Id);

            Assert.IsNotNull(empresaEncontrada);
            Assert.AreEqual(_empresa, empresaEncontrada);
        }

        [TestMethod]
        public void Deve_Editar_Empresa()
        {
            _servicoEmpresa.Inserir(_empresa);

            _empresa.Nome = "PedroEmpresa";
            _empresa.Email = "EmpresaPedro@teste.com";
            _empresa.Telefone = "987654321";
            _empresa.Endereco = "321, rua 321, 321";
            _empresa.CNPJ = "12.321.123/0001-12";
            _servicoEmpresa.Editar(_empresa);

            var empresaEncontrada = _repositorioEmpresa.SelecionarPorId(_empresa.Id);

            Assert.IsNotNull(empresaEncontrada);
            Assert.AreEqual(_empresa, empresaEncontrada);
        }

        [TestMethod]
        public void Deve_Excluir_Empresa()
        {
            _servicoEmpresa.Inserir(_empresa);

            _repositorioEmpresa.Excluir(_empresa);

            var empresaEncontrada = _repositorioEmpresa.SelecionarPorId(_empresa.Id);
            Assert.IsNull(empresaEncontrada);
        }

        [TestMethod]
        public void Deve_Selecionar_Empresa()
        {
            _servicoEmpresa.Inserir(_empresa);

            var empresaEncontrada = _repositorioEmpresa.SelecionarPorId(_empresa.Id);

            Assert.IsNotNull(empresaEncontrada);
            Assert.AreEqual(_empresa, empresaEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_todas_Empresas()
        {
            //arrange
            var empresa1 = new Empresa("Tatiane", "tati@email.com", "49991846942", "Rua 123", 
                "01.011.011/0001-01");
            var empresa2 = new Empresa("Thiago", "thi@email.com", "49999537888", "Rua 456",
                "01.011.011/0001-02");
            var empresa3 = new Empresa("Paulo", "paulo@email.com", "49999999999", "Rua 789",
                "01.011.011/0001-03");

            _servicoEmpresa.Inserir(empresa1);
            _servicoEmpresa.Inserir(empresa2);
            _servicoEmpresa.Inserir(empresa3);

            //action
            var empresas = _repositorioEmpresa.SelecionarTodos();

            //assert
            Assert.AreEqual(3, empresas.Count);
            Assert.AreEqual(empresa1, empresas[0]);
            Assert.AreEqual(empresa2, empresas[1]);
            Assert.AreEqual(empresa3, empresas[2]);
        }
    }
}
