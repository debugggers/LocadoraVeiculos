using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace LocadoraVeiculos.Infra.Dominio.TestesUnitarios.ModuloVeiculo
{
    [TestClass]
    public class VeiculoTeste
    {
        [TestMethod]
        public void Campos_Nao_Devem_Ficar_Vazios()
        {
            Veiculo veiculo = new Veiculo();

            ValidadorVeiculo validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            Assert.AreEqual("O campo modelo não pode ficar vazio", resultadoValidacao.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo marca não pode ficar vazio", resultadoValidacao.Errors[2].ErrorMessage);
            Assert.AreEqual("O campo placa não pode ficar vazio", resultadoValidacao.Errors[4].ErrorMessage);
            Assert.AreEqual("O campo cor não pode ficar vazio", resultadoValidacao.Errors[7].ErrorMessage);
            Assert.AreEqual("O campo ano não pode ficar vazio", resultadoValidacao.Errors[8].ErrorMessage);
            Assert.AreEqual("O campo quilometragem não pode ficar vazio", resultadoValidacao.Errors[9].ErrorMessage);
            Assert.AreEqual("O campo capacidade do tanque não pode ficar vazio", resultadoValidacao.Errors[10].ErrorMessage);
            Assert.AreEqual("O campo foto não pode ficar vazio", resultadoValidacao.Errors[11].ErrorMessage);
            Assert.AreEqual("O campo grupo de veiculos não pode ficar vazio", resultadoValidacao.Errors[13].ErrorMessage);

        }

        [TestMethod]
        public void Campos_Devem_Contem_Quantidade_Minima_De_Caracteres()
        {
            GrupoVeiculos grupo = new GrupoVeiculos
            {
                Nome = "Grupo"
            };

            Veiculo veiculo = new Veiculo
            {
                Marca = "Fo",
                Placa = "abc12",
                Modelo = "Ra",
                Cor = "Azul",
                Ano = 2017,
                CapacidadeTanque = 200,
                QuilometragemPercorrida = 1,
                TipoCombustivel = 0,
                //Foto = new Bitmap(@"C:\Users\paulo\Downloads\download.jpg"),
                GrupoVeiculos = grupo
            };

            ValidadorVeiculo validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            Assert.AreEqual("O modelo precisa ter pelo menos três caracteres", resultadoValidacao.Errors[0].ErrorMessage);
            Assert.AreEqual("A marca precisa ter pelo menos três caracteres", resultadoValidacao.Errors[1].ErrorMessage);
            Assert.AreEqual("A placa precisa ter pelo menos 6 caracteres", resultadoValidacao.Errors[2].ErrorMessage);
        }

        [TestMethod]
        public void Campos_Nao_Podem_Conter_Caracteres_Especiais()
        {
            GrupoVeiculos grupo = new GrupoVeiculos
            {
                Nome = "Grupo"
            };

            Veiculo veiculo = new Veiculo
            {
                Marca = "Ford",
                Placa = "@@@@@@@@@",
                Modelo = "Ranger",
                Cor = "Azul#",
                Ano = 2017,
                CapacidadeTanque = 200,
                QuilometragemPercorrida = 1,
                TipoCombustivel = 0,
                //Foto = new Bitmap(@"C:\Users\paulo\Downloads\download.jpg"),
                GrupoVeiculos = grupo
            };

            ValidadorVeiculo validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            Assert.AreEqual("Não são permitidos caracteres especiais na placa", resultadoValidacao.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo cor não pode ter caracteres especiais", resultadoValidacao.Errors[1].ErrorMessage);
        }

        [TestMethod]
        public void Quilometragem_Nao_Pode_Ser_Negativa()
        {
            GrupoVeiculos grupo = new GrupoVeiculos
            {
                Nome = "Grupo"
            };

            Veiculo veiculo = new Veiculo
            {
                Marca = "Ford",
                Placa = "abc123",
                Modelo = "Ranger",
                Cor = "Azul",
                Ano = 2017,
                CapacidadeTanque = 200,
                QuilometragemPercorrida = -100,
                TipoCombustivel = 0,
                //Foto = new Bitmap(@"C:\Users\paulo\Downloads\download.jpg"),
                GrupoVeiculos = grupo
            };

            ValidadorVeiculo validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            Assert.AreEqual("A quilometragem percorrida não pode ser vazia", resultadoValidacao.Errors[0].ErrorMessage);
        }
    }
}
