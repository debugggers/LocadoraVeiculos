using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculosForm.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private RepositorioClienteEmBancoDados _repositorio;
        private RepositorioEmpresaBancoDados _repositorioEmpresa;
        private ServicoCliente _servicoCliente;
        private ListagemClientesControl _listagem;

        public ControladorCliente(RepositorioClienteEmBancoDados repositorio, RepositorioEmpresaBancoDados repositorioEmpresa, ServicoCliente servicoCliente)
        {
            _repositorio = repositorio;
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
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm(_repositorioEmpresa);

            tela.Cliente = clienteSelecionado;

            tela.GravarRegistro = _servicoCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarClientes();
        }

        public override void Excluir()
        {
            Cliente cleienteSelecionado = ObtemClienteSelecionado();

            if (cleienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Exclusão de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Cliente?",
                "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                _repositorio.Excluir(cleienteSelecionado);
                CarregarClientes();
            }
        }

        private void CarregarClientes()
        {
            List<Cliente> clientes = _repositorio.SelecionarTodos();

            _listagem.AtualizarRegistros(clientes);
        }

        public override UserControl ObtemListagem()
        {
            if (_listagem == null)
                _listagem = new ListagemClientesControl();

            CarregarClientes();

            return _listagem;
        }

        private Cliente ObtemClienteSelecionado()
        {
            var id = _listagem.SelecionarIdCliente();

            Cliente clienteSelecionado = _repositorio.SelecionarPorId(id);

            return clienteSelecionado;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
        }
    }
}
