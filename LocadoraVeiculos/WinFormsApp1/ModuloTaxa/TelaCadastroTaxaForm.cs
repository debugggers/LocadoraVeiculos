using FluentResults;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloTaxa
{
    public partial class TelaCadastroTaxaForm : Form
    {
        private Taxa taxa;

        public TelaCadastroTaxaForm()
        {
            InitializeComponent();
            CarregarTipoCalculo();
        }

        public Func<Taxa, Result<Taxa>> GravarRegistro { get; set; }

        public Taxa Taxa
        {
            get { return taxa; }
            set
            {
                taxa = value;
                txtDescricao.Text = taxa.Descricao;
                txtValor.Text = taxa.Valor.ToString();
                comboBoxTipoCalculo.SelectedItem = taxa.TipoCalculo;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            taxa.Descricao = txtDescricao.Text;

            decimal valor;

            if (decimal.TryParse(txtValor.Text, out valor))
                taxa.Valor = valor;
            else
            {
                labelRodapeTaxa.Text = "Campo valor está inválido.";
                DialogResult = DialogResult.None;
                return;
            }
            if (taxa.Valor < 0)
            {
                labelRodapeTaxa.Text = "Valor deve ser maior que zero.";
                DialogResult = DialogResult.None;
                return;
            }

            taxa.TipoCalculo = (TipoCalculoEnum)comboBoxTipoCalculo.SelectedItem;

            var resultadoValidacao = GravarRegistro(taxa);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Inserção de Taxa",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    DialogResult = DialogResult.None;
                }
                else
                {
                    labelRodapeTaxa.Text = erro;

                    DialogResult = DialogResult.None;
                }
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

        private void CarregarTipoCalculo()
        {
            var tipoCalculo = Enum.GetValues(typeof(TipoCalculoEnum));

            foreach (var item in tipoCalculo)
            {
                comboBoxTipoCalculo.Items.Add(item);
            }
        }
    }
}
