using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloCliente
{
    public class ControladorCliente
    {

        private RepositorioClienteEmBancoDados repositorio;
        private ListagemClientesControl listagem;

        public ControladorCliente(RepositorioClienteEmBancoDados repositorio)
        {

            this.repositorio = repositorio;
            listagem = new ListagemClientesControl();

        }

        public void Inserir()
        {

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();
            tela.Cliente = new Cliente();

            tela.GravarRegistro = repositorio.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }

        }

        public void Editar()
        {

            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

            tela.GravarRegistro = repositorio.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public void Excluir()
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

        public UserControl ObtemListagem()
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

    }
}
