using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void btnInserir_Click(object sender, EventArgs e)
        {

            grupoVeiculos.Nome = txtNome.Text;

            var resultadoValidacao = GravarRegistro(grupoVeiculos);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
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
