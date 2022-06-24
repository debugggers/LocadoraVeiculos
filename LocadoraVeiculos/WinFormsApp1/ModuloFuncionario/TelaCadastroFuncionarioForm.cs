using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloFuncionario
{
    public partial class TelaCadastroFuncionarioForm : Form
    {
        private Funcionario _funcionario;
        private RepositorioFuncionarioEmBancoDados _repositorioFuncionario;


        public TelaCadastroFuncionarioForm(RepositorioFuncionarioEmBancoDados repositorioFuncionario)
        {
            InitializeComponent();

            _repositorioFuncionario = repositorioFuncionario;
        }


        public Func<Funcionario, ValidationResult> GravarRegistro { get; set; }

        public Funcionario Funcionario
        {
            get { return _funcionario; }
            set
            {
                _funcionario = value;

                txtId.Text = _funcionario.Id.ToString();
                txtNome.Text = _funcionario.Nome;
                txtLogin.Text = _funcionario.Login;
                txtSenha.Text = _funcionario.Senha;
                txtSalario.Text = _funcionario.Salario.ToString();
                if (_funcionario.DataAdmissao == DateTime.MinValue)
                    dtDataAdmissao.Value = DateTime.Now;
                else
                    dtDataAdmissao.Value = _funcionario.DataAdmissao;
                checkBoxAdmin.Checked = _funcionario.EhAdmin;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            _funcionario.Nome = txtNome.Text;
            _funcionario.Login = txtLogin.Text;
            _funcionario.Senha = txtSenha.Text;
            _funcionario.Salario = Convert.ToDecimal(txtSalario.Text);
            _funcionario.DataAdmissao = Convert.ToDateTime(dtDataAdmissao.Text);
            _funcionario.EhAdmin = checkBoxAdmin.Checked;

            if (_repositorioFuncionario.FuncionarioJaExiste(_funcionario.Nome, _funcionario.Id))
            {
                MessageBox.Show("Já existe um funcionário com este nome.",
                    "Inserindo Funcionário",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }
            else
            {
                var resultadoValidacao = GravarRegistro(_funcionario);

                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    labelRodapeFuncionario.Text = erro;

                    DialogResult = DialogResult.None;
                }
            }
        }
    }
}
