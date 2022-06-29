using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloGrupoVeiculos
{
    public partial class TelaCadastroGupoVeiculosForm : Form
    {
        GrupoVeiculos grupoVeiculos;
        RepositorioGrupoVeiculosEmBancoDados repositorio;
        public TelaCadastroGupoVeiculosForm()
        {
            InitializeComponent();
            repositorio = new RepositorioGrupoVeiculosEmBancoDados();
        }

        public Func<GrupoVeiculos, ValidationResult> GravarRegistro { get; set; }

        public GrupoVeiculos GrupoVeiculos
        {
            get
            {
                return grupoVeiculos;
            }

            set
            {
                grupoVeiculos = value;
                txtNome.Text = grupoVeiculos.Nome;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            grupoVeiculos.Nome = txtNome.Text;

            if (repositorio.GrupoVeiculosJaExiste(grupoVeiculos.Nome))
            {
                MessageBox.Show("Grupo de veiculos já existente, não é possível adicionar.",
                    "Cadastro de grupo de veiculos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }
            else
            {
                var resultadoValidacao = GravarRegistro(grupoVeiculos);

                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void TelaCadastroGrupoVeiculosForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroGrupoVeiculosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

    }
}
