using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculosForm.ModuloCliente;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculosForm
{
    public partial class TelaMenuPrincipalForm : Form
    {

        private ControladorCliente controlador;
        private RepositorioClienteEmBancoDados repositorio;

        public TelaMenuPrincipalForm()
        {
            InitializeComponent();
            controlador = new ControladorCliente(new RepositorioClienteEmBancoDados());
            repositorio = new RepositorioClienteEmBancoDados();
            Instancia = this;
        }

        public static TelaMenuPrincipalForm Instancia
        {
            get;
            private set;
        }



        private void clientesMenuItem_Click(object sender, EventArgs e)
        {

            ListagemClientesControl listagem = new ListagemClientesControl();

            var clientes = repositorio.SelecionarTodos();

            listagem.AtualizarRegistros(clientes);

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(listagem);

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {

            controlador.Inserir();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            controlador.Editar();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            controlador.Excluir();

        }
    }
}
