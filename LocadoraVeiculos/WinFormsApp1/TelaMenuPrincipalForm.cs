using LocadoraVeiculosForm.Compartilhado;
using LocadoraVeiculosForm.Compartilhado.ServiceLocator;
using LocadoraVeiculosForm.ModuloCliente;
using LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculosForm.ModuloFuncionario;
using LocadoraVeiculosForm.ModuloGrupoVeiculos;
using LocadoraVeiculosForm.ModuloPlanoCobranca;
using LocadoraVeiculosForm.ModuloTaxa;
using LocadoraVeiculosForm.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm
{
    public partial class TelaMenuPrincipalForm : Form
    {

        private ControladorBase _controlador;
        private IServiceLocator serviceLocator;


        public TelaMenuPrincipalForm(IServiceLocator serviceLocator)
        {
            InitializeComponent();

            this.serviceLocator = serviceLocator;

            var telaLoginForm = new TelaLoginForm();

            telaLoginForm.ShowDialog();

            while (telaLoginForm.DialogResult == DialogResult.Retry)
            {
                if (telaLoginForm.DialogResult == DialogResult.OK)
                    break;
                else if (telaLoginForm.DialogResult == DialogResult.Cancel)
                    Close();

                telaLoginForm.ShowDialog();
            }

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

        }

        public static TelaMenuPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }       

        private void btnInserir_Click(object sender, EventArgs e)
        {
            _controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            _controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            _controlador.Excluir();
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Visible = configuracao.InserirHabilitado;
            btnEditar.Visible = configuracao.EditarHabilitado;
            btnExcluir.Visible = configuracao.ExcluirHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
        }

        private void ConfigurarTelaPrincipal(ControladorBase controlador)
        {

            _controlador = controlador;

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = _controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = _controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void funcionariosMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorFuncionario>());
        }

        private void clientesMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void pessoaFísicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCliente>());
        }

        private void pessoaJurídicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorEmpresa>());
        }

        private void taxasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorTaxa>());
        }

        private void grupoDeVeiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorGupoVeiculos>());
        }

        private void planoCobrancaMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorPlanoCobranca>());
        }

        private void veiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorVeiculo>());
        }
    }
}
