using LocadoraVeiculos.Dominio.ModuloLocacao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

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
        public void Cliente_Locacao_nao_deve_ser_vazio_ou_nulo()
        {
            //arrange
            var locacao = new Locacao();
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Cliente' deve ser informado.", resultado.Errors[0].ErrorMessage);
            Assert.AreEqual("'Cliente' não pode ser nulo.", resultado.Errors[1].ErrorMessage);
        }

        [TestMethod]
        public void Grupo_Veiculos_Locacao_nao_deve_ser_vazio_ou_nulo()
        {
            //arrange
            var locacao = new Locacao();
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Grupo Veiculos' deve ser informado.", resultado.Errors[2].ErrorMessage);
            Assert.AreEqual("'Grupo Veiculos' não pode ser nulo.", resultado.Errors[3].ErrorMessage);
        }

        [TestMethod]
        public void Veiculo_Locacao_nao_deve_ser_vazio_ou_nulo()
        {
            //arrange
            var locacao = new Locacao();
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Veiculo' deve ser informado.", resultado.Errors[4].ErrorMessage);
            Assert.AreEqual("'Veiculo' não pode ser nulo.", resultado.Errors[5].ErrorMessage);
        }

        [TestMethod]
        public void Data_Locacao_nao_deve_ser_vazio_ou_nulo()
        {
            //arrange
            var locacao = new Locacao();
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Data Locacao' deve ser informado.", resultado.Errors[6].ErrorMessage);
        }

        [TestMethod]
        public void Data_Prevista_Entrega_nao_deve_ser_vazio_ou_nulo()
        {
            //arrange
            var locacao = new Locacao();
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Data Prevista Entrega' deve ser informado.", resultado.Errors[7].ErrorMessage);
        }

        [TestMethod]
        public void Data_Prevista_Entrega_deve_ser_maior_que_Data_Locacao()
        {
            //arrange
            var locacao = new Locacao
            {
                DataLocacao = DateTime.Now,
                DataPrevistaEntrega = DateTime.Now.AddDays(-1)
            };

            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Data Prevista Entrega' deve ser maior que 'Data Locacao'", resultado.Errors[6].ErrorMessage);
        }

        [TestMethod]
        public void Data_Prevista_Entrega_deve_ser_ate_30_dias_apos_Data_Locacao()
        {
            //arrange
            var locacao = new Locacao
            {
                DataLocacao = DateTime.Now,
                DataPrevistaEntrega = DateTime.Now.AddDays(31)
            };

            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Data Prevista Entrega' deve ser menor que 30 dias", resultado.Errors[6].ErrorMessage);
        }
    }
}
