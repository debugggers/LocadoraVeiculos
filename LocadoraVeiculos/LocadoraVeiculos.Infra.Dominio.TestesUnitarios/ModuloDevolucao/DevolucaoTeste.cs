using LocadoraVeiculos.Dominio.ModuloDevolucao;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
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

            Locacao locacao = new Locacao();

            Veiculo veiculo = new Veiculo();

            veiculo.QuilometragemPercorrida = 500;

            locacao.Veiculo = veiculo;

            devolucao.Locacao = locacao;

            ValidadorDevolucao validador = new ValidadorDevolucao();

            var resultadoValidacao = validador.Validate(devolucao);

            Assert.AreEqual("O campo quilometragem não pode ficar vazio", resultadoValidacao.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo data de devolução não pode ficar vazio", resultadoValidacao.Errors[2].ErrorMessage);

        }

        [TestMethod]
        public void Campo_Quilometragem_Deve_Ser_Maior_Do_Que_A_Anterior()
        {
            Devolucao devolucao = new Devolucao();

            Locacao locacao = new Locacao();

            Veiculo veiculo = new Veiculo();

            veiculo.QuilometragemPercorrida = 500;

            locacao.Veiculo = veiculo;

            devolucao.Locacao = locacao;

            devolucao.QuilometragemVeiculo = 250;

            ValidadorDevolucao validador = new ValidadorDevolucao();

            var resultadoValidacao = validador.Validate(devolucao);

            Assert.AreEqual("A quilometragem atual deve ser maior do que a anterior a locação", resultadoValidacao.Errors[0].ErrorMessage);
        }
    }
}
