using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {

        private RepositorioClienteEmBancoDados repositorio;
        private ServicoCliente servicoCliente;
        private ListagemClientesControl listagem;

        public ControladorCliente(RepositorioClienteEmBancoDados repositorio, ServicoCliente servicoCliente)
        {

            this.repositorio = repositorio;
            listagem = new ListagemClientesControl();
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();
            tela.Cliente = new Cliente();
            
            //tela.GravarRegistro = servicoCliente.Inserir;

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
                "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

            tela.Cliente = clienteSelecionado;
            
            //tela.GravarRegistro = repositorio.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
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
                repositorio.Excluir(cleienteSelecionado);
                CarregarClientes();
            }

        }

        private void CarregarClientes()
        {
            List<Cliente> clientes = repositorio.SelecionarTodos();

            listagem.AtualizarRegistros(clientes);
        }

        public override UserControl ObtemListagem()
        {
            if (listagem == null)
                listagem = new ListagemClientesControl();

            CarregarClientes();

            return listagem;
        }

        private Cliente ObtemClienteSelecionado()
        {
            int id = listagem.SelecionarNumeroCliente();

            Cliente clienteSelecionado = repositorio.SelecionarPorId(id);

            return clienteSelecionado;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
        }

    }
}
