using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private RepositorioEmpresaBancoDados _repositorioEmpresa;
        private ServicoCliente _servicoCliente;
        private ListagemClientesControl _listagem;

        public ControladorCliente(RepositorioEmpresaBancoDados repositorioEmpresa, ServicoCliente servicoCliente)
        {
            _repositorioEmpresa = repositorioEmpresa;
            _listagem = new ListagemClientesControl();
            _servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroClienteForm(_repositorioEmpresa);
            tela.Cliente = new Cliente();
            tela.GravarRegistro = _servicoCliente.Inserir;
            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override void Editar()
        {
            var id = _listagem.SelecionarIdCliente();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                    "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = _servicoCliente.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var clienteSelecionado = resultado.Value;

            var tela = new TelaCadastroClienteForm(_repositorioEmpresa);

            tela.Cliente = clienteSelecionado.Clone();

            tela.GravarRegistro = _servicoCliente.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarClientes();
        }

        public override void Excluir()
        {
            var id = _listagem.SelecionarIdCliente();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = _servicoCliente.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var clienteSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o cliente?", "Exclusão de Cliente",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = _servicoCliente.Excluir(clienteSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarClientes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarClientes()
        {
            var resultado = _servicoCliente.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Cliente> clientes = resultado.Value;

                _listagem.AtualizarRegistros(clientes);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {clientes.Count} cliente(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Carregar listagem",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            if (_listagem == null)
                _listagem = new ListagemClientesControl();

            CarregarClientes();

            return _listagem;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
        }
    }
}
