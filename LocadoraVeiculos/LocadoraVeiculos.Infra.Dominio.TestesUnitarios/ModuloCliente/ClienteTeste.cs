using LocadoraVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Dominio.TestesUnitarios.ModuloCliente
{
    [TestClass]
    public class ClienteTeste
    {

        [TestMethod]
        public void Campos_Nao_Devem_Ficar_Vazios()
        {

            Cliente cliente = new Cliente
            {



            };

            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            Assert.AreEqual("O campo nome não pode ficar vazio", resultadoValidacao.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo telefone não pode ficar vazio", resultadoValidacao.Errors[2].ErrorMessage);
            Assert.AreEqual("O campo email não pode ficar vazio", resultadoValidacao.Errors[4].ErrorMessage);
            Assert.AreEqual("O campo endereço não pode ficar vazio", resultadoValidacao.Errors[6].ErrorMessage);
            Assert.AreEqual("O campo CPF não pode ficar vazio", resultadoValidacao.Errors[8].ErrorMessage);
            Assert.AreEqual("O nome da CNH não pode ficar vazio", resultadoValidacao.Errors[10].ErrorMessage);
            Assert.AreEqual("O campo telefone não pode ficar vazio", resultadoValidacao.Errors[12].ErrorMessage);
            Assert.AreEqual("O campo de vencimento não pode ficar vazio", resultadoValidacao.Errors[13].ErrorMessage);

        }

        [TestMethod]
        public void Campos_Devem_Conter_Quantidade_Minima_De_Caracteres()
        {

            Cliente cliente = new Cliente
            {

                Nome = "Pa",
                Email = "Paulo@teste.com",
                Telefone = "1234567",
                Endereco = "123, rua 123, 123",
                CPF = "123.123.123-12",
                CnhNumero = 123,
                CnhNome = "Paulo",
                CnhVencimento = DateTime.Now.Date.AddMonths(6)

            };

            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            Assert.AreEqual("O Nome precisa ter mais do que três caracteres", resultadoValidacao.Errors[0].ErrorMessage);
            Assert.AreEqual("O telefone precisa deve ter 9 digitos", resultadoValidacao.Errors[1].ErrorMessage);

        }

        [TestMethod]
        public void Nome_Nao_Deve_Conter_Caracteres_Especiais()
        {

            Cliente cliente = new Cliente
            {

                Nome = "P@ulo!",
                Email = "Paulo@teste.com",
                Telefone = "1234567",
                Endereco = "123, rua 123, 123",
                CPF = "123.123.123-12",
                CnhNumero = 123,
                CnhNome = "Paulo",
                CnhVencimento = DateTime.Now.Date.AddMonths(6)

            };

            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            Assert.AreEqual("Não são permitidos caracteres especiais no nome", resultadoValidacao.Errors[0].ErrorMessage);

        }

        [TestMethod]
        public void Email_Nao_Deve_Ser_Invalido()
        {

            Cliente cliente = new Cliente
            {

                Nome = "Paulo",
                Email = "Paulo.com",
                Telefone = "123456789",
                Endereco = "123, rua 123, 123",
                CPF = "123.123.123-12",
                CnhNumero = 123,
                CnhNome = "Paulo",
                CnhVencimento = DateTime.Now.Date.AddMonths(6)

            };

            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            Assert.AreEqual("Formato de email inválido", resultadoValidacao.Errors[0].ErrorMessage);

        }

        [TestMethod]
        public void Nome_Da_Cnh_Deve_Ser_Igual_Ao_Do_Cliente()
        {

            Cliente cliente = new Cliente
            {

                Nome = "Paulo",
                Email = "Paulo@teste.com",
                Telefone = "123456789",
                Endereco = "123, rua 123, 123",
                CPF = "123.123.123-12",
                CnhNumero = 123,
                CnhNome = "Pedro",
                CnhVencimento = DateTime.Now.Date.AddMonths(6)

            };

            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            Assert.AreEqual("O nome da CNH precisa ser igual ao do cliente", resultadoValidacao.Errors[0].ErrorMessage);

        }

        [TestMethod]
        public void Cnh_Vencida_Nao_Deve_Ser_Aceita()
        {

            Cliente cliente = new Cliente
            {

                Nome = "Paulo",
                Email = "Paulo@teste.com",
                Telefone = "123456789",
                Endereco = "123, rua 123, 123",
                CPF = "123.123.123-12",
                CnhNumero = 123,
                CnhNome = "Paulo",
                CnhVencimento = DateTime.Now.Date

            };

            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            Assert.AreEqual("Impossivel cadastrar com documento vencido", resultadoValidacao.Errors[0].ErrorMessage);

        }

    }
}
