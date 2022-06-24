using LocadoraVeiculos.BancoDados.ModuloFuncionario;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculosForm.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private RepositorioFuncionarioEmBancoDados _repositorioFuncionario;
        private ListagemFuncionariosControl _listagemFuncionarios;

        public ControladorFuncionario()
        {
            _repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            _listagemFuncionarios = new ListagemFuncionariosControl();
        }

        public override void Inserir()
        {
            if (GerenciadorUsuario.EhAdmin())
            {
                TelaCadastroFuncionarioForm tela = new TelaCadastroFuncionarioForm(_repositorioFuncionario);
                tela.Funcionario = new Funcionario();

                tela.GravarRegistro = _repositorioFuncionario.Inserir;

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
                Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

                if (funcionarioSelecionado == null)
                {
                    MessageBox.Show("Selecione um Funcionário primeiro",
                    "Edição de Funcinários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                TelaCadastroFuncionarioForm tela = new TelaCadastroFuncionarioForm(_repositorioFuncionario);

                tela.Funcionario = funcionarioSelecionado;

                tela.GravarRegistro = _repositorioFuncionario.Editar;

                DialogResult resultado = tela.ShowDialog();

                if (resultado == DialogResult.OK)
                    CarregarFuncionarios();
            }
            else
                MessageBox.Show("Somente usuários 'Admin' podem gerenciar funcionários.");
        }

        public override void Excluir()
        {
            if (GerenciadorUsuario.EhAdmin())
            {
                Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

                if (funcionarioSelecionado == null)
                {
                    MessageBox.Show("Selecione um Funcionário primeiro",
                    "Exclusão de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Funcionário?",
                    "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    _repositorioFuncionario.Excluir(funcionarioSelecionado);
                    CarregarFuncionarios();
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

        private Funcionario ObtemFuncionarioSelecionado()
        {
            var id = _listagemFuncionarios.ObtemIdFuncionarioSelecionado();

            return _repositorioFuncionario.SelecionarPorId(id);
        }

        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionarios = _repositorioFuncionario.SelecionarTodos();

            _listagemFuncionarios.AtualizarRegistros(funcionarios);

            TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} Disciplina(s)");
        }
    }
}
