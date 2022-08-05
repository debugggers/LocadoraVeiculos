using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloLogin;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.Orm.ModuloFuncionario;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculosForm
{
    public partial class TelaLoginForm : Form
    {
        private ServicoLogin _servicoLogin;

        public TelaLoginForm(ServicoLogin servicoLogin)
        {
            InitializeComponent();
            _servicoLogin = servicoLogin;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "admin" && txtSenha.Text == "admin")
            {
                GerenciadorUsuario.Set(new Funcionario { Id = Guid.Empty, Nome = "Admin", EhAdmin = true });
                DialogResult = DialogResult.OK;
            }
            else
            {
                var usuario = _servicoLogin.SelecionarFuncionarioPorLoginSenha(txtLogin.Text, txtSenha.Text);

                if (usuario == null)
                {
                    MessageBox.Show("Usuário inválido");
                    DialogResult = DialogResult.Retry;
                }
                else
                {
                    GerenciadorUsuario.Set(usuario);
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
