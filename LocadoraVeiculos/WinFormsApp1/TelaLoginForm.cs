using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.BancoDados.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculosForm.ModuloCliente;
using LocadoraVeiculosForm.ModuloFuncionario;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculosForm
{
    public partial class TelaLoginForm : Form
    {
        private ControladorCliente controladorCliente;
        private ControladorFuncionario controladorFuncionario;

        private RepositorioClienteEmBancoDados repositorioCliente;
        private RepositorioFuncionarioEmBancoDados repositorioFuncionario;

        public TelaLoginForm()
        {
            InitializeComponent();



        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Funcionario usuario = new Funcionario();

            if (txtLogin.Text == "1")
            {
                usuario = new Funcionario();
            }
            else
            {
                usuario = null;
            }

            if (usuario == null)
            {
                MessageBox.Show("Usuário inválido");
                DialogResult = DialogResult.Retry;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
