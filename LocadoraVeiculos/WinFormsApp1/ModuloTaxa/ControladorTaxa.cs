using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {
        private ListagemTaxasControl _listagemTaxa;
        private ServicoTaxa _servicoTaxa;

        public ControladorTaxa(ServicoTaxa servicoTaxa)
        {
            _listagemTaxa = new ListagemTaxasControl();
            _servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            TelaCadastroTaxaForm tela = new TelaCadastroTaxaForm();
            tela.Taxa = new Taxa();

            tela.GravarRegistro = _servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();            
        }

        public override void Editar()
        {
            var id = _listagemTaxa.SelecionarIdTaxa();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro", "Edição de taxas",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = _servicoTaxa.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Edição de taxas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionada = resultado.Value;

            var tela = new TelaCadastroTaxaForm();

            tela.Taxa = taxaSelecionada.Clone();

            tela.GravarRegistro = _servicoTaxa.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarTaxas();

        }

        public override void Excluir()
        {
            var id = _listagemTaxa.SelecionarIdTaxa();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro", "Exclusão de taxas",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = _servicoTaxa.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message, "Exclusão de taxas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a Taxa?", "Exclusão de taxas",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = _servicoTaxa.Excluir(taxaSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarTaxas();
                else
                {
                    MessageBox.Show(resultadoSelecao.Errors[0].Message, "Exclusão de taxas",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            if (_listagemTaxa == null)
                _listagemTaxa = new ListagemTaxasControl();

            CarregarTaxas();

            return _listagemTaxa;
        }

        private void CarregarTaxas()
        {
            var resultado = _servicoTaxa.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Taxa> taxas = resultado.Value;

                _listagemTaxa.AtualizarRegistros(taxas);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} Taxa(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Seleção de taxas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
