using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloGrupoVeiculos
{
    public class ControladorGupoVeiculos : ControladorBase
    {
        private RepositorioGrupoVeiculosEmBancoDados repositorio;
        private ListagemGrupoveiculosControl listagem;


        public ControladorGupoVeiculos(RepositorioGrupoVeiculosEmBancoDados repositorio)
        {
            this.repositorio = repositorio;
            listagem = new ListagemGrupoveiculosControl();
        }

        public override void Editar()
        {
            GrupoVeiculos grupoVeiculoSelecionada = ObtemGrupoveiculoSelecionada();

            if (grupoVeiculoSelecionada == null)
            {
                MessageBox.Show("Selecione um grupo de veiculo primeiro",
                "Edição de Grupo de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroGupoVeiculosForm tela = new TelaCadastroGupoVeiculosForm();

            tela.GrupoVeiculos = grupoVeiculoSelecionada;

            //tela.GravarRegistro = repositorio.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoVeiculos();
            }
        }

        private GrupoVeiculos ObtemGrupoveiculoSelecionada()
        {
            int id = listagem.SelecionarNumeroGrupoVeiculos();

            GrupoVeiculos grupoVeiculosSelecionado = repositorio.SelecionarPorId(id);

            return grupoVeiculosSelecionado;
        }

        public override void Excluir()
        {
            GrupoVeiculos grupoVeiculoSelecionada = ObtemGrupoveiculoSelecionada();

            if (grupoVeiculoSelecionada == null)
            {
                MessageBox.Show("Selecione um Grupo de Veiculos primeiro",
                "Edição de Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir um Grupo de Veiculos?",
                "Exclusão de Grupo de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorio.Excluir(grupoVeiculoSelecionada);
                CarregarGrupoVeiculos();
            }
        }

        public override void Inserir()
        {
            TelaCadastroGupoVeiculosForm tela = new TelaCadastroGupoVeiculosForm();

            tela.GrupoVeiculos = new GrupoVeiculos();

            //tela.GravarRegistro = repositorio.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoVeiculos();
            }
        }
        public override UserControl ObtemListagem()
        {
            if (listagem == null)
                listagem = new ListagemGrupoveiculosControl();

            CarregarGrupoVeiculos();

            return listagem;
        }

        private void CarregarGrupoVeiculos()
        {
            List<GrupoVeiculos> grupoVeiculos = repositorio.SelecionarTodos();

            listagem.AtualizarRegistros(grupoVeiculos);
        }

       

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoVeiculos();
        }
    }
}
