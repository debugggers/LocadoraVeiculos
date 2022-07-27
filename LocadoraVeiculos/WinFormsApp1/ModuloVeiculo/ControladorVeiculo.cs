using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
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
        private ServicoGrupoVeiculos _servicoGrupoVeiculos;

        public ControladorVeiculo(ServicoVeiculo servico, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            _listagem = new ListagemVeiculosControl();
            _servico = servico;
            _servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroVeiculosForm(_servicoGrupoVeiculos);
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
            var id = _listagem.SelecionarNumeroVeiculo();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                    "Edição de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = _servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultado.Value;

            var tela = new TelaCadastroVeiculosForm(_servicoGrupoVeiculos);

            tela.Veiculo = veiculoSelecionado;

            tela.GravarRegistro = _servico.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            var id = _listagem.SelecionarNumeroVeiculo();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                    "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = _servico.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o veículo?", "Exclusão de Veículo",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = _servico.Excluir(veiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            var resultado = _servico.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Veiculo> veiculos = resultado.Value;

                _listagem.AtualizarRegistros(veiculos);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veículo(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Carregar listagem",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
