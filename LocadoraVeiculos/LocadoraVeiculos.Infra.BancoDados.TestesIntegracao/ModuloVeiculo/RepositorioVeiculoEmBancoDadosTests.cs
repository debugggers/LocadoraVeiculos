using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.BancoDados.TestesIntegracao.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDadosTests
    {

        private Veiculo veiculo;
        private RepositorioVeiculoEmBancoDados repositorio;
        private ServicoVeiculo servico;

        public RepositorioVeiculoEmBancoDadosTests()
        {
            

            repositorio = new RepositorioVeiculoEmBancoDados();
            servico = new ServicoVeiculo(repositorio);

            repositorio.SetEnderecoBanco(EnderecoBancoConst.EnderecoBancoTeste);

            Db.SetEnderecoBanco(EnderecoBancoConst.EnderecoBancoTeste);
        }

    }
}
