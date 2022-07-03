using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculosForm.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {

        private ServicoVeiculo servico;
        private ListagemVeiculosControl listagem;
        private RepositorioVeiculoEmBancoDados repositorio;
        private RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos;

        public ControladorVeiculo(RepositorioVeiculoEmBancoDados repositorio, RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos, ServicoVeiculo servico)
        {

            listagem = new ListagemVeiculosControl();
            this.repositorio = repositorio;
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
            this.servico = servico;
        }
        public override void Editar()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                "Edição de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroVeiculosForm tela = new TelaCadastroVeiculosForm(repositorioGrupoVeiculos);

            tela.Veiculo = veiculoSelecionado;

            tela.GravarRegistro = servico.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                "Exclusão de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o veiculo?",
                "Exclusão de veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorio.Excluir(veiculoSelecionado);
                CarregarVeiculos();
            }
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroVeiculosForm(repositorioGrupoVeiculos);
            tela.Veiculo = new Veiculo();
            tela.GravarRegistro = servico.Inserir;
            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        private Veiculo ObtemVeiculoSelecionado()
        {
            int id = listagem.SelecionarNumeroVeiculo();

            Veiculo veiculoSelecionado = repositorio.SelecionarPorId(id);

            return veiculoSelecionado;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            if (listagem == null)
                listagem = new ListagemVeiculosControl();

            CarregarVeiculos();

            return listagem;
        }

        private void CarregarVeiculos()
        {
            List<Veiculo> veiculos = repositorio.SelecionarTodos();

            listagem.AtualizarRegistros(veiculos);
        }
    }
}
