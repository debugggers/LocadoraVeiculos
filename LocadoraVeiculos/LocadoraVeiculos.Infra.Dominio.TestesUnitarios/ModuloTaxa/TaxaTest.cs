using LocadoraVeiculos.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace LocadoraVeiculos.Infra.Dominio.TestesUnitarios.ModuloTaxa
{
    [TestClass]
    public class TaxaTest
    {
        public TaxaTest()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
        }

        [TestMethod]
        public void Descricao_taxa_deve_ser_obrigatorio()
        {
            //arrange
            var taxa = new Taxa();

            var validador = new ValidadorTaxa();

            //action
            var resultado = validador.Validate(taxa);

            //assert
            Assert.AreEqual("'Descricao' não pode ser nulo.", resultado.Errors[0].ErrorMessage);
            Assert.AreEqual("'Descricao' deve ser informado.", resultado.Errors[1].ErrorMessage);
        }

        [TestMethod]
        public void Descricao_da_taxa_deve_ter_o_minimo_3_caracteres()
        {
            //arrange
            var taxa = new Taxa
            {
                Descricao = "Ha"
            };

            var validador = new ValidadorTaxa();

            //action
            var resultado = validador.Validate(taxa);

            //assert
            Assert.AreEqual("'Descricao' deve ter no mínimo 3 caracteres.", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Descricao_taxa_nao_deve_caracteres_especiais()
        {
            //arrange
            var taxa = new Taxa
            {
                Descricao = "T@ti"
            };

            var validador = new ValidadorTaxa();

            //action
            var resultado = validador.Validate(taxa);

            //assert
            Assert.AreEqual("Não são permitidos caracteres especiais.", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Valor_taxa_deve_ser_obrigatorio()
        {
            //arrange
            var taxa = new Taxa();

            var validador = new ValidadorTaxa();

            //action
            var resultado = validador.Validate(taxa);

            //assert
            Assert.AreEqual("'Valor' deve ser informado.", resultado.Errors[2].ErrorMessage);
        }

        [TestMethod]
        public void Tipo_de_calculo_da_taxa_deve_ser_obrigatorio()
        {
            //arrange
            var taxa = new Taxa();

            var validador = new ValidadorTaxa();

            //action
            var resultado = validador.Validate(taxa);

            //assert
            Assert.AreEqual("'Tipo Calculo' deve ser informado.", resultado.Errors[3].ErrorMessage);
        }
    }
}
