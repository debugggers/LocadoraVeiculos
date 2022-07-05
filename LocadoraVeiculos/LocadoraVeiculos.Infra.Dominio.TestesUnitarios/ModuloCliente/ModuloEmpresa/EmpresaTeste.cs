using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Dominio.TestesUnitarios.ModuloCliente.ModuloEmpresa
{
    [TestClass]
    public class EmpresaTeste
    {

        [TestMethod]
        public void Campos_Nao_Devem_Ser_Vazios()
        {

            Empresa empresa = new Empresa
            {



            };

            ValidadorEmpresa validador = new ValidadorEmpresa();
            var resultadoValidacao = validador.Validate(empresa);

            Assert.AreEqual("O campo nome não pode ficar vazio", resultadoValidacao.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo telefone não pode ficar vazio", resultadoValidacao.Errors[2].ErrorMessage);
            Assert.AreEqual("O campo email não pode ficar vazio", resultadoValidacao.Errors[4].ErrorMessage);
            Assert.AreEqual("O campo endereço não pode ficar vazio", resultadoValidacao.Errors[6].ErrorMessage);
            Assert.AreEqual("O campo CNPJ não pode ficar vazio", resultadoValidacao.Errors[8].ErrorMessage);

        }

        [TestMethod]
        public void Campos_Devem_Conter_Quantidade_Minima_De_Caracteres()
        {

            Empresa empresa = new Empresa
            {

                Nome = "Em",
                Email = "EmpresaPaulo@teste.com",
                Telefone = "1234",
                Endereco = "123, rua 123, 123",
                CNPJ = "12.123.123/0001-12"

        };

            ValidadorEmpresa validador = new ValidadorEmpresa();
            var resultadoValidacao = validador.Validate(empresa);

            Assert.AreEqual("O Nome precia ter ao menos três caracteres", resultadoValidacao.Errors[0].ErrorMessage);
            Assert.AreEqual("O telefone precisa ter pelo menos 9 digitos", resultadoValidacao.Errors[1].ErrorMessage);

        }

        [TestMethod]
        public void Campos_Devem_Seguir_Padrao_Estabelecido()
        {

            Empresa empresa = new Empresa
            {

                Nome = "Empresa@@@",
                Email = "empresaemail",
                Telefone = "123456789",
                Endereco = "123, rua 123, 123",
                CNPJ = "12.123.123/0001-12"

            };

            ValidadorEmpresa validador = new ValidadorEmpresa();
            var resultadoValidacao = validador.Validate(empresa);

            Assert.AreEqual("Não são permitidos caracteres especiais no nome", resultadoValidacao.Errors[0].ErrorMessage);
            Assert.AreEqual("Formato de email inválido", resultadoValidacao.Errors[1].ErrorMessage);

        }

    }
}
