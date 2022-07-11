using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private ServicoVeiculo _servico;
        private ListagemVeiculosControl _listagem;
        private RepositorioVeiculoEmBancoDados _repositorio;
        private RepositorioGrupoVeiculosEmBancoDados _repositorioGrupoVeiculos;

        public ControladorVeiculo(RepositorioVeiculoEmBancoDados repositorio, RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos, ServicoVeiculo servico)
        {
            _listagem = new ListagemVeiculosControl();
            _repositorio = repositorio;
            _repositorioGrupoVeiculos = repositorioGrupoVeiculos;
            _servico = servico;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroVeiculosForm(_repositorioGrupoVeiculos);
            tela.Veiculo = new Veiculo();
            tela.GravarRegistro = _servico.Inserir;
            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
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

            TelaCadastroVeiculosForm tela = new TelaCadastroVeiculosForm(_repositorioGrupoVeiculos);

            tela.Veiculo = veiculoSelecionado;

            tela.GravarRegistro = _servico.Editar;

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
                try
                {
                    _repositorio.Excluir(veiculoSelecionado);
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message,
                        "Exclusão de veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                
                CarregarVeiculos();
            }
        }

        private Veiculo ObtemVeiculoSelecionado()
        {
            var id = _listagem.SelecionarNumeroVeiculo();

            Veiculo veiculoSelecionado = _repositorio.SelecionarPorId(id);

            return veiculoSelecionado;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            if (_listagem == null)
                _listagem = new ListagemVeiculosControl();

            CarregarVeiculos();

            return _listagem;
        }

        private void CarregarVeiculos()
        {
            List<Veiculo> veiculos = _repositorio.SelecionarTodos();

            _listagem.AtualizarRegistros(veiculos);
        }
    }
}
