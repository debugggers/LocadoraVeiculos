using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloTaxa;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloTaxa
{
    [TestClass]

    public class RepositorioTaxaEmBancoDadosTest
    {
        private Taxa _taxa;
        private RepositorioTaxaEmBancoDados _repositorio;

        public RepositorioTaxaEmBancoDadosTest()
        {
            _taxa = new Taxa("Cadeira de bebe", 50.00m, TipoCalculoEnum.CalculoDiario);
            _repositorio = new RepositorioTaxaEmBancoDados();

            _repositorio.SetEnderecoBanco(EnderecoBancoConst.EnderecoBancoTeste);

            Db.SetEnderecoBanco(EnderecoBancoConst.EnderecoBancoTeste);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Db.ExecutarSql("DELETE FROM TBTAXA; DBCC CHECKIDENT (TBTAXA, RESEED, 0)");
        }

        [TestMethod]
        public void Deve_inserir_nova_taxa()
        {
            //action
            _repositorio.Inserir(_taxa);

            //assert
            var taxaEncontrada = _repositorio.SelecionarPorId(_taxa.Id);

            Assert.IsNotNull(taxaEncontrada);
            Assert.AreEqual(_taxa, taxaEncontrada);
        }

        [TestMethod]
        public void Deve_editar_informacoes_taxa()
        {
            //arrange
            _repositorio.Inserir(_taxa);

            //action
            _taxa.Descricao= "Lavacao";
            _taxa.Valor = 60.00m;
            _taxa.TipoCalculo = TipoCalculoEnum.CalculoFixo;
            _repositorio.Editar(_taxa);

            //assert
            var taxaEncontrada = _repositorio.SelecionarPorId(_taxa.Id);

            Assert.IsNotNull(taxaEncontrada);
            Assert.AreEqual(_taxa, taxaEncontrada);
        }

        [TestMethod]
        public void Deve_excluir_taxa()
        {
            //arrange
            _repositorio.Inserir(_taxa);

            //action
            _repositorio.Excluir(_taxa);

            //assert
            var taxaEncontrada = _repositorio.SelecionarPorId(_taxa.Id);

            Assert.IsNull(taxaEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_uma_taxa()
        {
            //arrange
            _repositorio.Inserir(_taxa);

            //action
            var taxaEncontrada = _repositorio.SelecionarPorId(_taxa.Id);

            //assert
            Assert.IsNotNull(taxaEncontrada);
            Assert.AreEqual(_taxa, taxaEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_todas_as_taxas()
        {
            //arrange
            var taxa1 = new Taxa("GPS", 35.00m, TipoCalculoEnum.CalculoDiario);
            var taxa2 = new Taxa("Cadeira de bebe", 50.00m, TipoCalculoEnum.CalculoDiario);
            var taxa3 = new Taxa("Lavacao", 65.00m, TipoCalculoEnum.CalculoFixo);

            _repositorio.Inserir(taxa1);
            _repositorio.Inserir(taxa2);
            _repositorio.Inserir(taxa3);

            //action
            var taxas = _repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(3, taxas.Count);
            Assert.AreEqual(taxa1, taxas[0]);
            Assert.AreEqual(taxa2, taxas[1]);
            Assert.AreEqual(taxa3, taxas[2]);
        }

        [TestMethod]
        public void Deve_retornar_true_quando_descricao_taxa_ja_existir()
        {
            //arrange
            _repositorio.Inserir(_taxa);

            //action
            //var taxaExiste = _repositorio.TaxaJaExiste("cadeira de bebe", 2);

            //assert
            //Assert.AreEqual(taxaExiste, true);
        }

        [TestMethod]
        public void Deve_retornar_false_quando_descricao_taxa_nao_existir()
        {
            //arrange
            _repositorio.Inserir(_taxa);

            //action
            //var taxaExiste = _repositorio.TaxaJaExiste("lavacao", 1);

            //assert
            //Assert.AreEqual(taxaExiste, false);
        }

        [TestMethod]
        public void Deve_inserir_somente_se_descricao_tiver_mais_que_2_caracteres()
        {
            //arrange
            var taxa = new Taxa("ha", 12.00m, TipoCalculoEnum.CalculoDiario); ;

            //action
            _repositorio.Inserir(taxa);

            //assert
            var taxaEncontrada = _repositorio.SelecionarPorId(taxa.Id);

            Assert.IsNull(taxaEncontrada);
            Assert.AreEqual(taxaEncontrada, null);
        }

        [TestMethod]
        public void Nao_deve_inserir_se_descricao_tiver_caracteres_especiais()
        {
            //arrange
            var taxa = new Taxa("c@deira d4 beb3", 12.00m, TipoCalculoEnum.CalculoDiario);

            //action
            _repositorio.Inserir(taxa);

            //assert
            var taxaEncontrada = _repositorio.SelecionarPorId(taxa.Id);

            Assert.IsNull(taxaEncontrada);
            Assert.AreEqual(taxaEncontrada, null);
        }
    }
}
