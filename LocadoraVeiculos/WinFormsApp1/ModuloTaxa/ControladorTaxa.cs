using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.BancoDados.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculosForm.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {

        private RepositorioTaxaEmBancoDados _repositorioTaxa;
        private ListagemTaxasControl _listagemTaxa;
        private ServicoTaxa _servicoTaxa;

        public ControladorTaxa(RepositorioTaxaEmBancoDados repositorio, ServicoTaxa servicoTaxa)
        {
            this._repositorioTaxa = repositorio;
            _listagemTaxa = new ListagemTaxasControl();
            _servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            TelaCadastroTaxaForm tela = new TelaCadastroTaxaForm(_servicoTaxa);
            tela.Taxa = new Taxa();

            tela.GravarRegistro = _servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Editar()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTaxaForm tela = new TelaCadastroTaxaForm(_servicoTaxa);

            tela.Taxa = taxaSelecionada;

            tela.GravarRegistro = _servicoTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Excluir()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a taxa?",
                "Exclusão de taxa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                _repositorioTaxa.Excluir(taxaSelecionada);
                CarregarTaxas();
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
            List<Taxa> taxas = _repositorioTaxa.SelecionarTodos();

            _listagemTaxa.AtualizarRegistros(taxas);
        }

        private Taxa ObtemTaxaSelecionada()
        {
            var id = _listagemTaxa.SelecionarIdTaxa();

            Taxa taxaSelecionada = _repositorioTaxa.SelecionarPorId(id);

            return taxaSelecionada;
        }
    }
}
