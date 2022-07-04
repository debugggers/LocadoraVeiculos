using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace LocadoraVeiculos.Infra.Dominio.TestesUnitarios.ModuloPlanoCobranca
{
    [TestClass]
    public class PlanoCobrancaTest
    {
        public PlanoCobrancaTest()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
        }

        [TestMethod]
        public void ValorDiario_Diario_deve_ser_obrigatorio()
        {
            //arrange
            var planoCobranca = new PlanoCobranca();

            var validador = new ValidadorPlanoCobranca();

            //action
            var resultado = validador.Validate(planoCobranca);

            //assert
            Assert.AreEqual("'Valor Diario_ Diario' deve ser informado.", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void ValorPorKm_Diario_deve_ser_obrigatorio()
        {
            //arrange
            var planoCobranca = new PlanoCobranca();

            var validador = new ValidadorPlanoCobranca();

            //action
            var resultado = validador.Validate(planoCobranca);

            //assert
            Assert.AreEqual("'Valor Por Km_ Diario' deve ser informado.", resultado.Errors[1].ErrorMessage);
        }

        [TestMethod]
        public void ValorDiario_Livre_deve_ser_obrigatorio()
        {
            //arrange
            var planoCobranca = new PlanoCobranca();

            var validador = new ValidadorPlanoCobranca();

            //action
            var resultado = validador.Validate(planoCobranca);

            //assert
            Assert.AreEqual("'Valor Diario_ Livre' deve ser informado.", resultado.Errors[2].ErrorMessage);
        }

        [TestMethod]
        public void ValorDiario_Controlado_deve_ser_obrigatorio()
        {
            //arrange
            var planoCobranca = new PlanoCobranca();

            var validador = new ValidadorPlanoCobranca();

            //action
            var resultado = validador.Validate(planoCobranca);

            //assert
            Assert.AreEqual("'Valor Diario_ Controlado' deve ser informado.", resultado.Errors[3].ErrorMessage);
        }

        [TestMethod]
        public void ValorPorKm_Controlado_deve_ser_obrigatorio()
        {
            //arrange
            var planoCobranca = new PlanoCobranca();

            var validador = new ValidadorPlanoCobranca();

            //action
            var resultado = validador.Validate(planoCobranca);

            //assert
            Assert.AreEqual("'Valor Por Km_ Controlado' deve ser informado.", resultado.Errors[4].ErrorMessage);
        }

        [TestMethod]
        public void Controle_de_Km_deve_ser_obrigatorio()
        {
            //arrange
            var planoCobranca = new PlanoCobranca();

            var validador = new ValidadorPlanoCobranca();

            //action
            var resultado = validador.Validate(planoCobranca);

            //assert
            Assert.AreEqual("'Controle Km' deve ser informado.", resultado.Errors[5].ErrorMessage);
        }
    }
}
