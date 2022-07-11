using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.BancoDados.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloPlanoCobranca
{
    [TestClass]

    public class RepositorioPlanoCobrancaEmBancoDadosTest
    {
        private PlanoCobranca _planoCobranca;
        private GrupoVeiculos _grupoVeiculos;
        private RepositorioPlanoCobrancaEmBancoDados _repositorioPlanoCobranca;
        private RepositorioGrupoVeiculosEmBancoDados _repositorioGrupoVeiculos;
        private ServicoPlanoCobranca _servicoPlanoCobranca;

        public RepositorioPlanoCobrancaEmBancoDadosTest()
        {
            _repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
            _grupoVeiculos = new GrupoVeiculos("Uber");
            _repositorioGrupoVeiculos.Inserir(_grupoVeiculos);

            _planoCobranca = new PlanoCobranca(_grupoVeiculos, _grupoVeiculos.Id, 50.00m, 5.00m, 100.00m, 50.00m, 3.00m, 54667);
            _repositorioPlanoCobranca = new RepositorioPlanoCobrancaEmBancoDados();
            _servicoPlanoCobranca = new ServicoPlanoCobranca(_repositorioPlanoCobranca);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Db.ExecutarSql("DELETE FROM TBVEICULO; DBCC CHECKIDENT(TBVEICULO, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM TBPLANOCOBRANCA; DBCC CHECKIDENT (TBPLANOCOBRANCA, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULO; DBCC CHECKIDENT (TBGRUPOVEICULO, RESEED, 0)");
        }

        [TestMethod]
        public void Deve_inserir_novo_plano_cobranca()
        {
            //action
            _servicoPlanoCobranca.Inserir(_planoCobranca);

            //assert
            var planoCobrancaEncontrado = _repositorioPlanoCobranca.SelecionarPorId(_planoCobranca.Id);

            Assert.IsNotNull(planoCobrancaEncontrado);
            Assert.AreEqual(_planoCobranca, planoCobrancaEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_plano_cobranca()
        {
            //arrange
            _servicoPlanoCobranca.Inserir(_planoCobranca);

            //action
            _planoCobranca.GrupoVeiculos = _grupoVeiculos;
            _planoCobranca.IdGrupoVeiculos = _grupoVeiculos.Id;
            _planoCobranca.ValorDiario_Diario = 60.00m;
            _planoCobranca.ValorPorKm_Diario = 6.00m;
            _planoCobranca.ValorDiario_Livre = 70.00m;
            _planoCobranca.ValorDiario_Controlado = 60.00m;
            _planoCobranca.ValorPorKm_Controlado = 7.00m;
            _planoCobranca.ControleKm = 6431;

            _servicoPlanoCobranca.Editar(_planoCobranca);

            //assert
            var taxaEncontrada = _repositorioPlanoCobranca.SelecionarPorId(_planoCobranca.Id);

            Assert.IsNotNull(taxaEncontrada);
            Assert.AreEqual(_planoCobranca, taxaEncontrada);
        }

        [TestMethod]
        public void Deve_excluir_plano_cobranca()
        {
            //arrange
            _servicoPlanoCobranca.Inserir(_planoCobranca);

            //action
            _repositorioPlanoCobranca.Excluir(_planoCobranca);

            //assert
            var taxaEncontrada = _repositorioPlanoCobranca.SelecionarPorId(_planoCobranca.Id);

            Assert.IsNull(taxaEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_plano_cobranca()
        {
            //arrange
            _servicoPlanoCobranca.Inserir(_planoCobranca);

            //action
            var taxaEncontrada = _repositorioPlanoCobranca.SelecionarPorId(_planoCobranca.Id);

            //assert
            Assert.IsNotNull(taxaEncontrada);
            Assert.AreEqual(_planoCobranca, taxaEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_todas_os_planos_cobranca()
        {
            //arrange
            var planoCobranca1 = new PlanoCobranca(_grupoVeiculos, _grupoVeiculos.Id, 60.00m, 6.00m, 600.00m, 60.00m, 6.00m, 64667);
            var planoCobranca2 = new PlanoCobranca(_grupoVeiculos, _grupoVeiculos.Id, 70.00m, 7.00m, 700.00m, 70.00m, 7.00m, 74667);
            var planoCobranca3 = new PlanoCobranca(_grupoVeiculos, _grupoVeiculos.Id, 80.00m, 8.00m, 800.00m, 80.00m, 8.00m, 84667);

            _servicoPlanoCobranca.Inserir(planoCobranca1);
            _servicoPlanoCobranca.Inserir(planoCobranca2);
            _servicoPlanoCobranca.Inserir(planoCobranca3);

            //action
            var planosCobranca = _repositorioPlanoCobranca.SelecionarTodos();

            //assert
            Assert.AreEqual(3, planosCobranca.Count);
            Assert.AreEqual(planoCobranca1, planosCobranca[0]);
            Assert.AreEqual(planoCobranca2, planosCobranca[1]);
            Assert.AreEqual(planoCobranca3, planosCobranca[2]);
        }
    }
}
