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
        private ListagemGrupoveiculosControl _listagemGrupoVeiculos;
        private ServicoGrupoVeiculos _servicoGrupoVeiculos;


        public ControladorGupoVeiculos(ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
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
            var id = _listagemGrupoVeiculos.SelecionarIdGrupoVeiculos();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro",
                    "Edição de grupo de veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = _servicoGrupoVeiculos.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de grupo de veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupodeVeiculosSelecionado = resultado.Value;

            var tela = new TelaCadastroGupoVeiculosForm();

            tela.GrupoVeiculos = grupodeVeiculosSelecionado.Clone();

            tela.GravarRegistro = _servicoGrupoVeiculos.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarGrupoVeiculos();
        }

        public override void Excluir()
        {

            var id = _listagemGrupoVeiculos.SelecionarIdGrupoVeiculos();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro",
                    "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = _servicoGrupoVeiculos.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Grupo de veículos?", "Exclusão de Grupo de Veículos",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = _servicoGrupoVeiculos.Excluir(veiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarGrupoVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CarregarGrupoVeiculos()
        {
            
            var resultado = _servicoGrupoVeiculos.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<GrupoVeiculos> grupos = resultado.Value;

                _listagemGrupoVeiculos.AtualizarRegistros(grupos);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupos.Count} grupo(s) de veículos");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Carregar listagem",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
    }
}
