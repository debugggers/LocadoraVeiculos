using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private ListagemFuncionariosControl _listagemFuncionarios;
        private ServicoFuncionario _servicoFuncionario;

        public ControladorFuncionario(ServicoFuncionario servicoFuncionario)
        {
            _listagemFuncionarios = new ListagemFuncionariosControl();
            _servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            if (GerenciadorUsuario.EhAdmin())
            {
                TelaCadastroFuncionarioForm tela = new TelaCadastroFuncionarioForm();
                tela.Funcionario = new Funcionario();

                tela.GravarRegistro = _servicoFuncionario.Inserir;

                DialogResult resultado = tela.ShowDialog();

                if (resultado == DialogResult.OK)
                    CarregarFuncionarios();
            }
            else
                MessageBox.Show("Somente usuários 'Admin' podem gerenciar funcionários.");
        }

        public override void Editar()
        {
            if (GerenciadorUsuario.EhAdmin())
            {
                var id = _listagemFuncionarios.ObtemIdFuncionarioSelecionado();

                if (id == Guid.Empty)
                {
                    MessageBox.Show("Selecione um funcionário primeiro", "Edição de funcionários",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var resultado = _servicoFuncionario.SelecionarPorId(id);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Edição de funcionários",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var funcionarioSelecionado = resultado.Value;

                var tela = new TelaCadastroFuncionarioForm();

                tela.Funcionario = funcionarioSelecionado.Clone();

                tela.GravarRegistro = _servicoFuncionario.Editar;

                if (tela.ShowDialog() == DialogResult.OK)
                    CarregarFuncionarios();

            }
            else
                MessageBox.Show("Somente usuários 'Admin' podem gerenciar funcionários.");
        }

        public override void Excluir()
        {
            if (GerenciadorUsuario.EhAdmin())
            {
                var id = _listagemFuncionarios.ObtemIdFuncionarioSelecionado();

                if (id == Guid.Empty)
                {
                    MessageBox.Show("Selecione um funcionário primeiro", "Exclusão de funcionários",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var resultadoSelecao = _servicoFuncionario.SelecionarPorId(id);

                if (resultadoSelecao.IsFailed)
                {
                    MessageBox.Show(resultadoSelecao.Errors[0].Message, "Exclusão de funcionários",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var funcionarioSelecionado = resultadoSelecao.Value;

                if (MessageBox.Show("Deseja realmente excluir o Funcionário?", "Exclusão de Funcionários",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var resultadoExclusao = _servicoFuncionario.Excluir(funcionarioSelecionado);

                    if (resultadoExclusao.IsSuccess)
                        CarregarFuncionarios();
                    else
                    {
                        MessageBox.Show(resultadoSelecao.Errors[0].Message, "Exclusão de funcionários",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Somente usuários 'Admin' podem gerenciar funcionários.");
        }

        public override UserControl ObtemListagem()
        {
            if (_listagemFuncionarios == null)
                _listagemFuncionarios = new ListagemFuncionariosControl();

            CarregarFuncionarios();

            return _listagemFuncionarios;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxFuncionario();
        }

        private void CarregarFuncionarios()
        {
            var resultado = _servicoFuncionario.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Funcionario> funcionarios = resultado.Value;

                _listagemFuncionarios.AtualizarRegistros(funcionarios);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} Funcionário(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Seleção de Funcionários",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
