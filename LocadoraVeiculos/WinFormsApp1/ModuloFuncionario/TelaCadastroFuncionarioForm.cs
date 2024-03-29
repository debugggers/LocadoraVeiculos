﻿using FluentResults;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloFuncionario
{
    public partial class TelaCadastroFuncionarioForm : Form
    {
        private Funcionario _funcionario;

        public TelaCadastroFuncionarioForm()
        {
            InitializeComponent();

            dtDataAdmissao.MaxDate = DateTime.Now.Date;
        }

        public Func<Funcionario, Result<Funcionario>> GravarRegistro { get; set; }

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
                    dtDataAdmissao.Value = DateTime.Now.Date;
                else
                    dtDataAdmissao.Value = _funcionario.DataAdmissao;
                checkBoxAdmin.Checked = _funcionario.EhAdmin;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            _funcionario.Nome = txtNome.Text;
            _funcionario.Login = txtLogin.Text;
            _funcionario.Senha = txtSenha.Text;

            decimal salario;

            if (decimal.TryParse(txtSalario.Text, out salario))
                _funcionario.Salario = salario;
            else
            {
                labelRodapeFuncionario.Text = "Campo salário está inválido.";
                DialogResult = DialogResult.None;
                return;
            }
            if (_funcionario.Salario < 0)
            {
                labelRodapeFuncionario.Text = "Valor deve ser maior que zero.";
                DialogResult = DialogResult.None;
                return;
            }

            _funcionario.DataAdmissao = Convert.ToDateTime(dtDataAdmissao.Text);
            _funcionario.EhAdmin = checkBoxAdmin.Checked;

            var resultadoValidacao = GravarRegistro(_funcionario);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Inserção de Funcionário", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    labelRodapeFuncionario.Text = erro;

                    DialogResult = DialogResult.None;
                }
            }
        }
    }
}
