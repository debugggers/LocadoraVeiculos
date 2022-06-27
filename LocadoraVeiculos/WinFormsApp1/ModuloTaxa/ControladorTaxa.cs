using LocadoraVeiculos.BancoDados.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {

        private RepositorioTaxaEmBancoDados repositorio;
        private ListagemTaxasControl listagem;

        public ControladorTaxa(RepositorioTaxaEmBancoDados repositorio)
        {
            this.repositorio = repositorio;
            listagem = new ListagemTaxasControl();
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

            TelaCadastroTaxaForm tela = new TelaCadastroTaxaForm();

            tela.Taxa = taxaSelecionada;

            tela.GravarRegistro = repositorio.Editar;

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
                repositorio.Excluir(taxaSelecionada);
                CarregarTaxas();
            }
        }

        public override void Inserir()
        {
            TelaCadastroTaxaForm tela = new TelaCadastroTaxaForm();
            tela.Taxa = new Taxa();

            tela.GravarRegistro = repositorio.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            if (listagem == null)
                listagem = new ListagemTaxasControl();

            CarregarTaxas();

            return listagem;
        }

        private void CarregarTaxas()
        {
            List<Taxa> taxas = repositorio.SelecionarTodos();

            listagem.AtualizarRegistros(taxas);
        }

        private Taxa ObtemTaxaSelecionada()
        {
            int id = listagem.SelecionarNumeroTaxa();

            Taxa taxaSelecionada = repositorio.SelecionarPorId(id);

            return taxaSelecionada;
        }

    }
}
