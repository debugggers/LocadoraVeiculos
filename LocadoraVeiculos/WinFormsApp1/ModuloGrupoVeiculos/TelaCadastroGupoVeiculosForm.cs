using FluentResults;
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
        public TelaCadastroGupoVeiculosForm()
        {
            InitializeComponent();
        }

        public Func<GrupoVeiculos, Result<GrupoVeiculos>> GravarRegistro { get; set; }

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

            var resultadoValidacao = GravarRegistro(grupoVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
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
