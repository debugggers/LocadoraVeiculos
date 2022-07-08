using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
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
        private RepositorioGrupoVeiculosEmBancoDados _repositorioGrupoVeiculos;
        private ListagemGrupoveiculosControl _listagemGrupoVeiculos;
        private ServicoGrupoVeiculos _servicoGrupoVeiculos;


        public ControladorGupoVeiculos(RepositorioGrupoVeiculosEmBancoDados repositorio, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            _repositorioGrupoVeiculos = repositorio;
            _listagemGrupoVeiculos = new ListagemGrupoveiculosControl();
            _servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            TelaCadastroGupoVeiculosForm tela = new TelaCadastroGupoVeiculosForm();

            tela.GrupoVeiculos = new GrupoVeiculos();

            tela.GravarRegistro = _servicoGrupoVeiculos.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoVeiculos();
            }
        }

        public override void Editar()
        {
            GrupoVeiculos grupoVeiculoSelecionada = ObtemGrupoveiculoSelecionado();

            if (grupoVeiculoSelecionada == null)
            {
                MessageBox.Show("Selecione um grupo de veiculo primeiro",
                "Edição de Grupo de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroGupoVeiculosForm tela = new TelaCadastroGupoVeiculosForm();

            tela.GrupoVeiculos = grupoVeiculoSelecionada;

            tela.GravarRegistro = _servicoGrupoVeiculos.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoVeiculos();
            }
        }

        public override void Excluir()
        {
            GrupoVeiculos grupoVeiculoSelecionada = ObtemGrupoveiculoSelecionado();

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
                try
                {
                    _repositorioGrupoVeiculos.Excluir(grupoVeiculoSelecionada);
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message,
                        "Exclusão de grupo de veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                
                CarregarGrupoVeiculos();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (_listagemGrupoVeiculos == null)
                _listagemGrupoVeiculos = new ListagemGrupoveiculosControl();

            CarregarGrupoVeiculos();

            return _listagemGrupoVeiculos;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoVeiculos();
        }

        private GrupoVeiculos ObtemGrupoveiculoSelecionado()
        {
            int id = _listagemGrupoVeiculos.SelecionarNumeroGrupoVeiculos();

            GrupoVeiculos grupoVeiculosSelecionado = _repositorioGrupoVeiculos.SelecionarPorId(id);

            return grupoVeiculosSelecionado;
        }

        private void CarregarGrupoVeiculos()
        {
            List<GrupoVeiculos> grupoVeiculos = _repositorioGrupoVeiculos.SelecionarTodos();

            _listagemGrupoVeiculos.AtualizarRegistros(grupoVeiculos);
        }        
    }
}
