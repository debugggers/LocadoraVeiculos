using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloTaxa
{
    public partial class TelaCadastroTaxaForm : Form
    {

        Taxa taxa;
        RepositorioTaxaEmBancoDados repositorio;
        public TelaCadastroTaxaForm()
        {
            InitializeComponent();
            repositorio = new RepositorioTaxaEmBancoDados();
        }

        public Func<Taxa, ValidationResult> GravarRegistro { get; set; }

        public Taxa Taxa
        {
            get { return taxa;}
            set
            {
                taxa = value;
                txtDescricao.Text = taxa.Descricao;
                txtValor.Text = taxa.Valor.ToString();
                comboBoxTipoCalculo.SelectedIndex = (int)taxa.TipoCalculo;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            taxa.Descricao = txtDescricao.Text;

            decimal valor;

            if (decimal.TryParse(txtValor.Text, out valor))
                taxa.Valor = valor;
            if (taxa.Valor < 0)
            {
                labelRodapeTaxa.Text = "Valor deve ser maior que zero.";
                DialogResult = DialogResult.None;
                return;
            }
            else
            {
                labelRodapeTaxa.Text = "Campo valor está inválido.";
                DialogResult = DialogResult.None;
                return;
            }
            taxa.TipoCalculo = (TipoCalculoEnum)comboBoxTipoCalculo.SelectedIndex;

            if (!repositorio.VerificarSeExiste(taxa))
            {

                MessageBox.Show("Taxa ou dados já inseridos",
               "Taxa de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            var resultadoValidacao = GravarRegistro(taxa);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                labelRodapeTaxa.Text = erro;

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroTaxasForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroTaasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
