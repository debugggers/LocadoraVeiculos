using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDadosTests
    {

        private Veiculo veiculo;
        private GrupoVeiculos grupo;
        private RepositorioVeiculoEmBancoDados repositorio;
        private ServicoVeiculo servico;
        private ServicoGrupoVeiculos servicoGrupo;
        private RepositorioGrupoVeiculosEmBancoDados repositorioGrupo;

        public RepositorioVeiculoEmBancoDadosTests()
        {

            repositorioGrupo = new RepositorioGrupoVeiculosEmBancoDados();
            servicoGrupo = new ServicoGrupoVeiculos(repositorioGrupo);

            grupo = new GrupoVeiculos
            {

                Nome = "Grupo"

            };

            veiculo = new Veiculo
            {

                Marca = "Ford",
                Placa = "abc123",
                Modelo = "Ranger",
                Cor = "Azul",
                Ano = 2017,
                CapacidadeTanque = 200,
                QuilometragemPercorrida = 1,
                TipoCombustivel = 0,
                Foto = new Bitmap(@"C:\Users\paulo\Downloads\download.jpg"),
                GrupoVeiculo = grupo

            };

            repositorio = new RepositorioVeiculoEmBancoDados();
            servico = new ServicoVeiculo(repositorio);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Db.ExecutarSql("DELETE FROM TBVEICULO; DBCC CHECKIDENT(TBVEICULO, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM TBPLANOCOBRANCA; DBCC CHECKIDENT(TBPLANOCOBRANCA, RESEED, 0)");
            Db.ExecutarSql(" DELETE FROM TBGRUPOVEICULO; DBCC CHECKIDENT(TBGRUPOVEICULO, RESEED, 0)");
        }

        [TestMethod]
        public void Deve_Inserir_Veiculo()
        {

            servicoGrupo.Inserir(grupo);
            servico.Inserir(veiculo);

            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(veiculoEncontrado);
            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(veiculo.Id, veiculoEncontrado.Id);
            Assert.AreEqual(veiculo.Marca, veiculoEncontrado.Marca);
            Assert.AreEqual(veiculo.Modelo, veiculoEncontrado.Modelo);
            Assert.AreEqual(veiculo.Placa, veiculoEncontrado.Placa);
            Assert.AreEqual(veiculo.GrupoVeiculo, veiculoEncontrado.GrupoVeiculo);
            Assert.AreEqual(veiculo.CapacidadeTanque, veiculoEncontrado.CapacidadeTanque);
            Assert.AreEqual(veiculo.Ano, veiculoEncontrado.Ano);
            Assert.AreEqual(veiculo.Cor, veiculoEncontrado.Cor);
            Assert.AreEqual(veiculo.QuilometragemPercorrida, veiculoEncontrado.QuilometragemPercorrida);
            Assert.AreEqual(veiculo.TipoCombustivel, veiculoEncontrado.TipoCombustivel);

        }

        [TestMethod]
        public void Deve_Editar_Veiculo()
        {

            servicoGrupo.Inserir(grupo);
            servico.Inserir(veiculo);

            veiculo.Marca = "drof";
            veiculo.Placa = "123abc";
            veiculo.Modelo = "regnar";
            veiculo.Cor = "vermelho";
            veiculo.Ano = 2016;
            veiculo.CapacidadeTanque = 250;
            veiculo.QuilometragemPercorrida = 150;
            veiculo.TipoCombustivel = CombustivelEnum.Etanol;
            veiculo.Foto = new Bitmap(@"C:\Users\paulo\Downloads\download.jpg");

            servico.Editar(veiculo);

            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(veiculoEncontrado);
            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(veiculo.Id, veiculoEncontrado.Id);
            Assert.AreEqual(veiculo.Marca, veiculoEncontrado.Marca);
            Assert.AreEqual(veiculo.Modelo, veiculoEncontrado.Modelo);
            Assert.AreEqual(veiculo.Placa, veiculoEncontrado.Placa);
            Assert.AreEqual(veiculo.GrupoVeiculo, veiculoEncontrado.GrupoVeiculo);
            Assert.AreEqual(veiculo.CapacidadeTanque, veiculoEncontrado.CapacidadeTanque);
            Assert.AreEqual(veiculo.Ano, veiculoEncontrado.Ano);
            Assert.AreEqual(veiculo.Cor, veiculoEncontrado.Cor);
            Assert.AreEqual(veiculo.QuilometragemPercorrida, veiculoEncontrado.QuilometragemPercorrida);
            Assert.AreEqual(veiculo.TipoCombustivel, veiculoEncontrado.TipoCombustivel);

        }

        [TestMethod]
        public void Deve_Excluir_Veiculo()
        {

            servicoGrupo.Inserir(grupo);
            servico.Inserir(veiculo);

            repositorio.Excluir(veiculo);

            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            Assert.IsNull(veiculoEncontrado);

        }

        [TestMethod]
        public void Deve_Selecionar_Veiculo()
        {

            servicoGrupo.Inserir(grupo);
            servico.Inserir(veiculo);

            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(veiculo.Id, veiculoEncontrado.Id);
            Assert.AreEqual(veiculo.Marca, veiculoEncontrado.Marca);
            Assert.AreEqual(veiculo.Modelo, veiculoEncontrado.Modelo);
            Assert.AreEqual(veiculo.Placa, veiculoEncontrado.Placa);
            Assert.AreEqual(veiculo.GrupoVeiculo, veiculoEncontrado.GrupoVeiculo);
            Assert.AreEqual(veiculo.CapacidadeTanque, veiculoEncontrado.CapacidadeTanque);
            Assert.AreEqual(veiculo.Ano, veiculoEncontrado.Ano);
            Assert.AreEqual(veiculo.Cor, veiculoEncontrado.Cor);
            Assert.AreEqual(veiculo.QuilometragemPercorrida, veiculoEncontrado.QuilometragemPercorrida);
            Assert.AreEqual(veiculo.TipoCombustivel, veiculoEncontrado.TipoCombustivel);

        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Veiculos()
        {

            servicoGrupo.Inserir(grupo);
            servico.Inserir(veiculo);

            Veiculo veiculo1 = new Veiculo
            {

                Marca = "drof",
                Placa = "123abc",
                Modelo = "regnar",
                Cor = "vermelho",
                Ano = 2018,
                CapacidadeTanque = 250,
                QuilometragemPercorrida = 150,
                TipoCombustivel = 0,
                Foto = new Bitmap(@"C:\Users\paulo\Downloads\download.jpg"),
                GrupoVeiculo = grupo

            };

            servico.Inserir(veiculo1);

            var veiculosEncontrados = repositorio.SelecionarTodos();

            Assert.AreEqual(2, veiculosEncontrados.Count);
            Assert.AreEqual(veiculo.Id, veiculosEncontrados[0].Id);
            Assert.AreEqual(veiculo.Marca, veiculosEncontrados[0].Marca);
            Assert.AreEqual(veiculo.Modelo, veiculosEncontrados[0].Modelo);
            Assert.AreEqual(veiculo.Placa, veiculosEncontrados[0].Placa);
            Assert.AreEqual(veiculo.GrupoVeiculo, veiculosEncontrados[0].GrupoVeiculo);
            Assert.AreEqual(veiculo.CapacidadeTanque, veiculosEncontrados[0].CapacidadeTanque);
            Assert.AreEqual(veiculo.Ano, veiculosEncontrados[0].Ano);
            Assert.AreEqual(veiculo.Cor, veiculosEncontrados[0].Cor);
            Assert.AreEqual(veiculo.QuilometragemPercorrida, veiculosEncontrados[0].QuilometragemPercorrida);
            Assert.AreEqual(veiculo.TipoCombustivel, veiculosEncontrados[0].TipoCombustivel);

            Assert.AreEqual(veiculo1.Id, veiculosEncontrados[1].Id);
            Assert.AreEqual(veiculo1.Marca, veiculosEncontrados[1].Marca);
            Assert.AreEqual(veiculo1.Modelo, veiculosEncontrados[1].Modelo);
            Assert.AreEqual(veiculo1.Placa, veiculosEncontrados[1].Placa);
            Assert.AreEqual(veiculo1.GrupoVeiculo, veiculosEncontrados[1].GrupoVeiculo);
            Assert.AreEqual(veiculo1.CapacidadeTanque, veiculosEncontrados[1].CapacidadeTanque);
            Assert.AreEqual(veiculo1.Ano, veiculosEncontrados[1].Ano);
            Assert.AreEqual(veiculo1.Cor, veiculosEncontrados[1].Cor);
            Assert.AreEqual(veiculo1.QuilometragemPercorrida, veiculosEncontrados[1].QuilometragemPercorrida);
            Assert.AreEqual(veiculo1.TipoCombustivel, veiculosEncontrados[1].TipoCombustivel);

        }
    }
}
