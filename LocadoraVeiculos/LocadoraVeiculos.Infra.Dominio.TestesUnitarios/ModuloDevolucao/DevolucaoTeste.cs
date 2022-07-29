using LocadoraVeiculos.Dominio.ModuloDevolucao;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Infra.Dominio.TestesUnitarios.ModuloDevolucao
{
    [TestClass]
    public class DevolucaoTeste
    {

        [TestMethod]
        public void Campos_Nao_Devem_Ficar_Vazios()
        {
            Devolucao devolucao = new Devolucao();

            ValidadorDevolucao validador = new ValidadorDevolucao();

            var resultadoValidacao = validador.Validate(devolucao);

            Assert.AreEqual("O campo locação não pode ficar vazio", resultadoValidacao.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo quilometragem não pode ficar vazio", resultadoValidacao.Errors[2].ErrorMessage);
            Assert.AreEqual("O campo data de devolução não pode ficar vazio", resultadoValidacao.Errors[4].ErrorMessage);
            Assert.AreEqual("O campo nivel do tanque não pode ficar vazio", resultadoValidacao.Errors[5].ErrorMessage);

        }

        [TestMethod]
        public void Campo_Quilometragem_Deve_Ser_Maior_Do_Que_0()
        {
            Devolucao devolucao = new Devolucao();

            devolucao.QuilometragemVeiculo = -10;

            ValidadorDevolucao validador = new ValidadorDevolucao();

            var resultadoValidacao = validador.Validate(devolucao);

            Assert.AreEqual("A quilometragem deve ser maior do que 0", resultadoValidacao.Errors[2].ErrorMessage);

        }
    }
}
