using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloPlanoCobranca
{
    public class ControladorPlanoCobranca : ControladorBase
    {
        private ListagemPlanoCobrancaControl _listagemPlanoCobranca;
        private ServicoPlanoCobranca _servicoPlanoCobranca;
        private ServicoGrupoVeiculos _servicoGrupoVeiculos;

        public ControladorPlanoCobranca(ServicoPlanoCobranca servicoPlanoCobranca, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            _listagemPlanoCobranca = new ListagemPlanoCobrancaControl();
            _servicoPlanoCobranca = servicoPlanoCobranca;
            _servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            TelaCadastroPlanoCobrancaForm tela = new TelaCadastroPlanoCobrancaForm(_servicoGrupoVeiculos);
            tela.PlanoCobranca = new PlanoCobranca();

            tela.GravarRegistro = _servicoPlanoCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanosCobranca();
        }

        public override void Editar()
        {
            var id = _listagemPlanoCobranca.ObtemIdPlanoCobrancaSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro", "Edição de planos de cobrança",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = _servicoPlanoCobranca.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Edição de planos de cobrança",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoCobrancaSelecionado = resultado.Value;

            var tela = new TelaCadastroPlanoCobrancaForm(_servicoGrupoVeiculos);

            tela.PlanoCobranca = planoCobrancaSelecionado;

            tela.GravarRegistro = _servicoPlanoCobranca.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarPlanosCobranca();
        }

        public override void Excluir()
        {
            var id = _listagemPlanoCobranca.ObtemIdPlanoCobrancaSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro", "Exclusão de planos de cobrança",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = _servicoPlanoCobranca.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message, "Exclusão de planos de cobrança",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoCobrancaSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o plano de cobrança?", "Exclusão de planos de cobrança",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = _servicoPlanoCobranca.Excluir(planoCobrancaSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarPlanosCobranca();
                else
                {
                    MessageBox.Show(resultadoSelecao.Errors[0].Message, "Exclusão de planos de cobrança",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override UserControl ObtemListagem()
        {
            if (_listagemPlanoCobranca == null)
                _listagemPlanoCobranca = new ListagemPlanoCobrancaControl();

            CarregarPlanosCobranca();

            return _listagemPlanoCobranca;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoCobranca();
        }

        private void CarregarPlanosCobranca()
        {
            var resultado = _servicoPlanoCobranca.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<PlanoCobranca> planosCobranca = resultado.Value;

                _listagemPlanoCobranca.AtualizarRegistros(planosCobranca);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {planosCobranca.Count} Plano(s) de Cobrança");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Seleção de Planos de Cobrança",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
