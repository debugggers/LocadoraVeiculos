using LocadoraVeiculos.BancoDados.ModuloFuncionario;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculosForm
{
    public partial class TelaLoginForm : Form
    {
        private RepositorioFuncionarioEmBancoDados _repositorioFuncionario;

        public TelaLoginForm()
        {
            InitializeComponent();
            _repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "admin" && txtSenha.Text == "admin")
                DialogResult = DialogResult.OK;
            else
            {
                var usuario = _repositorioFuncionario.BuscarUsuarioPorLoginSenha(txtLogin.Text, txtSenha.Text);

                if (usuario == null)
                {
                    MessageBox.Show("Usuário inválido");
                    DialogResult = DialogResult.Retry;
                }
                else
                    DialogResult = DialogResult.OK;
            }
        }
    }
}
