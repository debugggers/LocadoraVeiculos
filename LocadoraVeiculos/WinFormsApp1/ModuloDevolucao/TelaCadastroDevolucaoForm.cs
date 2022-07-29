using FluentResults;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloDevolucao;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloDevolucao
{
    public partial class TelaCadastroDevolucaoForm : Form
    {

        Devolucao devolucao;
        private ServicoLocacao servicoLocacao;
        List<Locacao> locacoes;

        public TelaCadastroDevolucaoForm(ServicoLocacao servicoLocacao)
        {
            InitializeComponent();
            this.servicoLocacao = servicoLocacao;
            locacoes = servicoLocacao.SelecionarTodos().Value;
            InicializarComboBoxLocacoes(locacoes);
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
                txtQuilometragem.Text = devolucao.QuilometragemVeiculo.ToString();
                if (devolucao.DataDevolucao == DateTime.MinValue)
                    dateTimePickerDevolucao.Value = DateTime.Now.Date;
                else
                    dateTimePickerDevolucao.Value = devolucao.DataDevolucao;
                comboBoxNivelTanque.SelectedItem = devolucao.NivelDoTanque;
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
            string nivelTanque = comboBoxNivelTanque.SelectedItem.ToString();
            switch (nivelTanque)
            {

                case "Vazio":
                    devolucao.NivelDoTanque = 0m;
                        break;
                case "1/4":
                    devolucao.NivelDoTanque = 1/4m;
                    break;
                case "1/2":
                    devolucao.NivelDoTanque = 1/2m;
                    break;
                case "3/4":
                    devolucao.NivelDoTanque = 3/4m;
                    break;
                case "Cheio":
                    devolucao.NivelDoTanque = 1m;
                    break;
            }

            //devolucao.ValorTotal = devolucao.CalcularTotal();

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
            labelTotal.Text =  devolucao.Locacao.ValorPrevisto.ToString();

        }

        private void dateTimePickerDevolucao_ValueChanged(object sender, EventArgs e)
        {



        }
    }
}
