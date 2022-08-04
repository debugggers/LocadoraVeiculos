using FluentResults;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloDevolucao;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloDevolucao
{
    public partial class TelaCadastroDevolucaoForm : Form
    {

        Devolucao devolucao;
        private ServicoLocacao servicoLocacao;
        private ServicoPlanoCobranca servicoPlanoCobranca;
        private ServicoTaxa servicoTaxa;
        List<Locacao> locacoes;
        List<PlanoCobranca> planos;
        decimal totalLimpo = 0, totalComGasolina  = 0, totalComTaxa = 0;

        public TelaCadastroDevolucaoForm(ServicoLocacao servicoLocacao, ServicoPlanoCobranca servicoPlanoCobranca, ServicoTaxa servicoTaxa)
        {
            InitializeComponent();
            this.servicoTaxa = servicoTaxa;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
            planos = servicoPlanoCobranca.SelecionarTodos().Value;
            this.servicoLocacao = servicoLocacao;
            locacoes = servicoLocacao.SelecionarTodos().Value;
            InicializarComboBoxLocacoes(locacoes);
            InicializarComboBoxNivelTanque();
        }

        private void InicializarComboBoxNivelTanque()
        {

            
            comboBoxNivelTanque.Items.Add("Vazio");
            comboBoxNivelTanque.Items.Add("1/4");
            comboBoxNivelTanque.Items.Add("1/2");
            comboBoxNivelTanque.Items.Add("3/4");
            comboBoxNivelTanque.Items.Add("Cheio");
            comboBoxNivelTanque.SelectedIndex = 0;
        }

        public Func<Devolucao, Result<Devolucao>> GravarRegistro { get; set; }

        public Devolucao Devolucao
        {
            get
            {
                return devolucao;
            }
            set
            {
                devolucao = value;
                if(devolucao.Locacao != null)
                {

                    //txtFuncionario.Text = devolucao.Locacao.Funcionario.Nome;
                    if (devolucao.Locacao.Cliente.Empresa == null)
                        txtCliente.Text = devolucao.Locacao.Cliente.Nome;
                    else
                        txtCliente.Text = devolucao.Locacao.Cliente.Empresa.Nome;
                    txtGrupoVeiculos.Text = devolucao.Locacao.GrupoVeiculos.Nome;
                    txtPlaca.Text = devolucao.Locacao.Veiculo.Placa;
                    txtDataLocacao.Text = devolucao.Locacao.DataLocacao.ToShortDateString();
                    txtDataDevolucaoPrevista.Text = devolucao.Locacao.DataPrevistaEntrega.ToShortDateString();
                    txtPlanoCobranca.Text = devolucao.Locacao.PlanosCobranca.ToString();

                }
                comboBoxLocacoes.SelectedItem = devolucao.Locacao; 
                labelTotal.Text = devolucao.ValorTotal.ToString();

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            foreach (var item in locacoes)
            {
                if (item.Id.Equals(comboBoxLocacoes.SelectedItem))
                    devolucao.Locacao = item;
            }
            devolucao.QuilometragemVeiculo = Convert.ToInt32(txtQuilometragem.Text);
            devolucao.DataDevolucao = dateTimePickerDevolucao.Value;
            totalLimpo = devolucao.CalcularTotal(planos);
            totalComTaxa = devolucao.CalcularTaxas();
            totalComGasolina = devolucao.CalcularCombustivel();
            devolucao.ValorTotal = totalLimpo + totalComGasolina + totalComTaxa;
            devolucao.Locacao.Veiculo.EstaDisponivel = true;

            var resultadoValidacao = GravarRegistro(devolucao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                    labelRodapeDevolucao.Text = erro;

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void InicializarComboBoxLocacoes(List<Locacao> locacoes)
        {
            foreach (var l in locacoes)
            {

                comboBoxLocacoes.Items.Add(l.Id);

            }
        }

        private void comboBoxLocacoes_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (var item in locacoes)
            {

                if (item.Id.Equals(comboBoxLocacoes.SelectedItem))
                    devolucao.Locacao = item;

            }

            //txtFuncionario.Text = devolucao.Locacao.Funcionario.Nome;
            if (devolucao.Locacao.Cliente.Empresa == null)
                txtCliente.Text = devolucao.Locacao.Cliente.Nome;
            else
                txtCliente.Text = devolucao.Locacao.Cliente.Empresa.Nome;
            txtGrupoVeiculos.Text = devolucao.Locacao.GrupoVeiculos.Nome;
            txtPlaca.Text = $"{devolucao.Locacao.Veiculo.Placa}  - {devolucao.Locacao.Veiculo.Modelo}";
            txtDataLocacao.Text = devolucao.Locacao.DataLocacao.ToShortDateString();
            txtDataDevolucaoPrevista.Text = devolucao.Locacao.DataPrevistaEntrega.ToShortDateString();
            txtPlanoCobranca.Text = devolucao.Locacao.PlanosCobranca.ToString();
            totalComTaxa = devolucao.CalcularTaxas();
            labelTotal.Text = devolucao.Locacao.ValorPrevisto.ToString();

        }

        private void dateTimePickerDevolucao_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTaxas_Click(object sender, EventArgs e)
        {
            devolucao.Taxas = new List<Taxa>();
            TelaCadastroTaxasAdicionaisForm tela = new TelaCadastroTaxasAdicionaisForm(devolucao, servicoTaxa);
            tela.Show();

        }

        private void btnAddTaxas_Click(object sender, EventArgs e)
        {

            totalComTaxa = devolucao.CalcularTaxas();
            labelTotal.Text = (totalLimpo + totalComGasolina + totalComTaxa).ToString();

        }

        private void txtQuilometragem_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxNivelTanque_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(devolucao != null)
            {

                switch (comboBoxNivelTanque.SelectedItem.ToString())
                {

                    case "Vazio":
                        devolucao.NivelDoTanque = 0m;
                        break;
                    case "1/4":
                        devolucao.NivelDoTanque = 1 / 4m;
                        break;
                    case "1/2":
                        devolucao.NivelDoTanque = 1 / 2m;
                        break;
                    case "3/4":
                        devolucao.NivelDoTanque = 3 / 4m;
                        break;
                    case "Cheio":
                        devolucao.NivelDoTanque = 1m;
                        break;
                }

                totalComGasolina = devolucao.CalcularCombustivel();
                labelTotal.Text = (totalLimpo + totalComGasolina + totalComTaxa).ToString();

            }
            
        }

        private void Calcular_Click(object sender, EventArgs e)
        {

            if(txtQuilometragem.Text == "")
            {

                TelaMenuPrincipalForm.Instancia.AtualizarRodape("A data de devolução e a quiloemtragem precisam ser inseridos!");

                labelRodapeDevolucao.Text = "A data de devolução e a quiloemtragem precisam ser inseridos!";

                DialogResult = DialogResult.None;

            }
            else
            {

                comboBoxNivelTanque.Enabled = true;

                devolucao.QuilometragemVeiculo = Convert.ToInt32(txtQuilometragem.Text);

                devolucao.DataDevolucao = dateTimePickerDevolucao.Value;

                totalLimpo = devolucao.CalcularTotal(planos);

                labelTotal.Text = (totalLimpo + totalComGasolina + totalComTaxa).ToString();

            }
        }
    }
}
