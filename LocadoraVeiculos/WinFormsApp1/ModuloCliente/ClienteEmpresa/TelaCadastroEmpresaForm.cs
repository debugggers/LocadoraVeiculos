using FluentResults;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa
{
    public partial class TelaCadastroEmpresaForm : Form
    {

        Empresa empresa;


        public TelaCadastroEmpresaForm()
        {
            InitializeComponent();
        }

        public Func<Empresa, Result<Empresa>> GravarRegistro { get; set; }

        public Empresa Empresa
        {
            get
            {
                return empresa;
            }
            set
            {
                empresa = value;
                txtNomeEmpresa.Text = empresa.Nome;
                txtEmailEmpresa.Text = empresa.Email;
                txtTelefoneEmpresa.Text = empresa.Telefone;
                txtCnpjEmpresa.Text = empresa.CNPJ;
                txtEnderecoEmpresa.Text = empresa.Endereco;

            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            empresa.Nome = txtNomeEmpresa.Text;
            empresa.Email = txtEmailEmpresa.Text;
            empresa.Telefone = txtTelefoneEmpresa.Text;
            empresa.Endereco = txtEnderecoEmpresa.Text;
            empresa.CNPJ = txtCnpjEmpresa.Text;

            var resultadoValidacao = GravarRegistro(empresa);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }

            }
        }

        private void TelaCadastroEmpresasForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroEmpresasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

    }
}
