using LocadoraVeiculos.Dominio.ModuloLocacao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Dominio.TestesUnitarios.ModuloLocacao
{
    [TestClass]
    public class LocacaoTeste
    {

        public LocacaoTeste()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
        }

        [TestMethod]
        public void Valor_Previsto_nao_deve_ser_nulo()
        {
            //arrange
            var locacao = new Locacao();

            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Valor Previsto' deve ser informado.", resultado.Errors[7].ErrorMessage);
        }

        [TestMethod]
        public void Data_Locacao_nao_deve_ser_nula()
        {
            //arrange
            var locacao = new Locacao();
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Data Locacao' deve ser informado.", resultado.Errors[5].ErrorMessage);
        }

        [TestMethod]
        public void Data_Prevista_Entrega_nao_deve_ser_nula()
        {
            //arrange
            var locacao = new Locacao();
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Data Prevista Entrega' deve ser informado.", resultado.Errors[6].ErrorMessage);
        }
    }
}
