using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Infra.Dominio.TestesUnitarios.ModuloGrupoVeiculos
{
    [TestClass]
    public class GrupoVeiculosTestes
    {

        [TestMethod]
        public void Campos_Nao_Devem_Ficar_Vazios()
        {

            GrupoVeiculos grupo = new GrupoVeiculos
            {



            };

            ValidadorGrupoVeiculos validador = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validador.Validate(grupo);

            Assert.AreEqual("O campo nome não pode ficar vazio", resultadoValidacao.Errors[0].ErrorMessage);

        }

        [TestMethod]
        public void Campos_Devem_Ter_Quantidade_Minima_De_Caracteres()
        {

            GrupoVeiculos grupo = new GrupoVeiculos
            {

                Nome = "ab"

            };

            ValidadorGrupoVeiculos validador = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validador.Validate(grupo);

            Assert.AreEqual("O campo nome precisa ter pelo menos três caracteres", resultadoValidacao.Errors[0].ErrorMessage);

        }

        [TestMethod]
        public void Campos_Nao_Devem_Conter_Caracteres_Especiais()
        {

            GrupoVeiculos grupo = new GrupoVeiculos
            {

                Nome = "ab@@"

            };

            ValidadorGrupoVeiculos validador = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validador.Validate(grupo);

            Assert.AreEqual("Não são permitidos caracteres especiais.", resultadoValidacao.Errors[0].ErrorMessage);

        }
    }
}
