using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private ServicoLocacao _servicoLocacao;
        private ServicoCliente _servicoCliente;
        private ServicoGrupoVeiculos _servicoGrupoVeiculos;
        private ServicoTaxa _servicoTaxa;
        private ServicoVeiculo _servicoVeiculo;
        private ServicoPlanoCobranca _servicoPlanoCobranca;
        private ListagemLocacaoControl _listagemLocacao;

        public ControladorLocacao(ServicoLocacao servicoLocacao, ServicoCliente servicoCliente, ServicoGrupoVeiculos servicoGrupoVeiculos,
            ServicoTaxa servicoTaxa, ServicoVeiculo servicoVeiculo, ServicoPlanoCobranca servicoPlanoCobranca)
        {
            _listagemLocacao = new ListagemLocacaoControl();

            _servicoLocacao = servicoLocacao;
            _servicoCliente = servicoCliente;
            _servicoGrupoVeiculos = servicoGrupoVeiculos;
            _servicoTaxa = servicoTaxa;
            _servicoVeiculo = servicoVeiculo;
            _servicoPlanoCobranca = servicoPlanoCobranca;
        }


        public override void Inserir()
        {
            TelaCadastroLocacaoForm tela = new TelaCadastroLocacaoForm(_servicoLocacao, _servicoCliente,
                _servicoGrupoVeiculos, _servicoTaxa, _servicoVeiculo, _servicoPlanoCobranca);

            tela.Locacao = new Locacao();

            tela.GravarRegistro = _servicoLocacao.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarLocacoes();
        }

        public override void Editar()
        {
            var id = _listagemLocacao.ObtemIdLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro", "Edição de locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = _servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Edição de locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultado.Value;

            var tela = new TelaCadastroLocacaoForm(_servicoLocacao, _servicoCliente, _servicoGrupoVeiculos,
                _servicoTaxa, _servicoVeiculo, _servicoPlanoCobranca);

            tela.Locacao = locacaoSelecionada;

            tela.GravarRegistro = _servicoLocacao.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarLocacoes();
        }

        public override void Excluir()
        {
            var id = _listagemLocacao.ObtemIdLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro", "Exclusão de locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = _servicoLocacao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message, "Exclusão de funcionários",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Funcionário?", "Exclusão de Funcionários",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = _servicoLocacao.Excluir(locacaoSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacoes();
                else
                {
                    MessageBox.Show(resultadoSelecao.Errors[0].Message, "Exclusão de funcionários",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override UserControl ObtemListagem()
        {
            if (_listagemLocacao == null)
                _listagemLocacao = new ListagemLocacaoControl();

            CarregarLocacoes();

            return _listagemLocacao;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxLocacao();
        }

        private void CarregarLocacoes()
        {
            var resultado = _servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                _listagemLocacao.AtualizarRegistros(locacoes);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} Locação(ões)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Seleção de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
