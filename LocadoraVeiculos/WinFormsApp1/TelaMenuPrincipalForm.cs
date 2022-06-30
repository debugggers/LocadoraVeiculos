using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.BancoDados.ModuloFuncionario;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.BancoDados.ModuloTaxa;
using LocadoraVeiculosForm.Compartilhado;
using LocadoraVeiculosForm.ModuloCliente;
using LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculosForm.ModuloFuncionario;
using LocadoraVeiculosForm.ModuloGrupoVeiculos;
using LocadoraVeiculosForm.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm
{
    public partial class TelaMenuPrincipalForm : Form
    {

        private ControladorBase _controlador;
        private Dictionary<string, ControladorBase> controladores;

        private RepositorioClienteEmBancoDados _repositorioClientes;

        public TelaMenuPrincipalForm()
        {
            InitializeComponent();

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

            if (telaLoginForm.DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show(this, "Aplicação será encerrada!");
                Close();
            }

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

            InicializarControladores();
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

        private void clientesMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void funcionariosMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
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

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            _controlador = controladores[tipo];

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

        private void InicializarControladores()
        {
            var repositorioClientes = new RepositorioClienteEmBancoDados();
            var repositorioEmpresa = new RepositorioEmpresaBancoDados();
            var repositorioTaxa = new RepositorioTaxaEmBancoDados();
            var repositorioGrupoveiculos = new RepositorioGrupoVeiculosEmBancoDados();
            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();

            var servicoCliente = new ServicoCliente(repositorioClientes);
            var servicoEmpresa = new ServicoEmpresa(repositorioEmpresa);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            var servicoGrupoVeiculos = new ServicoGrupoVeiculos();
            var servicoTaxa = new ServicoTaxa();

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Funcionário", new ControladorFuncionario(repositorioFuncionario, servicoFuncionario));
            controladores.Add("Pessoa física", new ControladorCliente(repositorioClientes, servicoCliente));
            controladores.Add("Pessoa jurídica", new ControladorEmpresa(repositorioEmpresa, repositorioClientes, servicoEmpresa));
            //controladores.Add("Taxas", new ControladorTaxa(repositorioTaxa));
            //controladores.Add("Grupo de veiculos", new ControladorGupoVeiculos(repositorioGrupoveiculos));
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pessoaFísicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);

        }

        private void pessoaJurídicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);

        }

        private void taxasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);

        }

        private void grupoDeVeiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);

        }
    }
}
