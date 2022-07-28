using FluentResults;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        private Locacao _locacao;

        private List<Cliente> _clientes;
        private ServicoCliente _servicoCliente;

        private List<GrupoVeiculos> _gruposVeiculos;
        private ServicoGrupoVeiculos _servicoGrupoVeiculos;

        private List<Taxa> _taxas;
        private ServicoTaxa _servicoTaxa;

        private List<Veiculo> _veiculos;
        private ServicoVeiculo _servicoVeiculo;

        public TelaCadastroLocacaoForm(ServicoCliente servicoCliente, ServicoGrupoVeiculos servicoGrupoVeiculos,
            ServicoPlanoCobranca servicoPlanoCobranca, ServicoTaxa servicoTaxa, ServicoVeiculo servicoVeiculo)
        {
            InitializeComponent();

            checkedListBoxTaxas.DisplayMember = "Descricao";
            checkedListBoxTaxas.ValueMember = "Id";

            _servicoCliente = servicoCliente;
            _clientes = _servicoCliente.SelecionarTodos().Value;

            _servicoGrupoVeiculos = servicoGrupoVeiculos;
            _gruposVeiculos = _servicoGrupoVeiculos.SelecionarTodos().Value;

            _servicoTaxa = servicoTaxa;
            _taxas = _servicoTaxa.SelecionarTodos().Value;

            _servicoVeiculo = servicoVeiculo;

            dateTimeLocacao.MinDate = DateTime.Now.Date;
            dateTimePrevisaoEntrega.MinDate = DateTime.Now.Date;

            CarregarClientes();
            CarregarGrupoVeiculos();
            CarregarPlanosCobranca();
           
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        public Locacao Locacao
        {
            get { return _locacao; }
            set
            {
                _locacao = value;

                labelFuncionario.Text = _locacao.Funcionario == null ? GerenciadorUsuario.ObtemNome() : _locacao.Funcionario.Nome;
                comboBoxClientes.SelectedItem = _locacao.Cliente;
                comboBoxGrupoVeiculos.SelectedItem = _locacao.GrupoVeiculos;
                comboBoxPlanosCobranca.SelectedItem = _locacao.PlanosCobranca;
                comboBoxVeiculo.SelectedItem = _locacao.Veiculo;

                if (_locacao.DataLocacao == DateTime.MinValue)
                    dateTimeLocacao.Value = DateTime.Now.Date;
                else
                    dateTimeLocacao.Value = _locacao.DataLocacao;

                if (_locacao.DataPrevistaEntrega == DateTime.MinValue)
                    dateTimePrevisaoEntrega.Value = DateTime.Now.Date;
                else
                    dateTimePrevisaoEntrega.Value = _locacao.DataPrevistaEntrega;

                labelValorPrevisto.Text = _locacao.ValorPrevisto.ToString();

                CarregarCheckBoxTaxas();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            _locacao.FuncionarioId = GerenciadorUsuario.ObtemId();

            _locacao.Cliente = (Cliente)comboBoxClientes.SelectedItem;
            _locacao.ClienteId = _locacao.Cliente.Id;

            _locacao.GrupoVeiculos = (GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem;
            _locacao.GrupoVeiculosId = _locacao.GrupoVeiculos.Id;

            _locacao.PlanosCobranca = (PlanoCobrancaEnum)comboBoxPlanosCobranca.SelectedItem;

            _locacao.Veiculo = (Veiculo)comboBoxVeiculo.SelectedItem;
            _locacao.VeiculoId = _locacao.Veiculo.Id;

            _locacao.DataLocacao = Convert.ToDateTime(dateTimeLocacao.Value);
            _locacao.DataPrevistaEntrega = Convert.ToDateTime(dateTimePrevisaoEntrega.Value);

            CarregarTaxasNaLocacao();

            var resultadoValidacao = GravarRegistro(_locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Inserção de Locação",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    DialogResult = DialogResult.None;
                }
                else
                {
                    labelRodapeLocacao.Text = erro;

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void CarregarClientes()
        {
            comboBoxClientes.Items.Clear();

            foreach (var item in _clientes)
                comboBoxClientes.Items.Add(item);
        }

        private void CarregarGrupoVeiculos()
        {
            comboBoxGrupoVeiculos.Items.Clear();

            foreach (var item in _gruposVeiculos)
                comboBoxGrupoVeiculos.Items.Add(item);
        }

        private void CarregarPlanosCobranca()
        {
            comboBoxPlanosCobranca.DataSource = Enum.GetValues(typeof(PlanoCobrancaEnum));
        }

        private void CarregarCheckBoxTaxas()
        {
            checkedListBoxTaxas.Items.Clear();

            foreach (var item in _taxas)
            {
                if (_locacao.Taxas != null && _locacao.Taxas.Any(x => x.Id == item.Id))
                    checkedListBoxTaxas.Items.Add(item, CheckState.Checked);
                else
                    checkedListBoxTaxas.Items.Add(item);
            }
        }

        private void CarregarTaxasNaLocacao()
        {
            _locacao.Taxas.Clear();
            foreach (var item in checkedListBoxTaxas.CheckedItems)
                _locacao.Taxas.Add((Taxa)item);
        }

        private void CarregarVeiculos()
        {
            comboBoxVeiculo.Items.Clear();

            foreach (var item in _veiculos)
                comboBoxVeiculo.Items.Add(item);
        }

        private void comboBoxVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVeiculo.SelectedIndex >= 0)
            {
                var veiculosSelecionado = (Veiculo)comboBoxVeiculo.SelectedItem;

                var veiculo = _veiculos.FirstOrDefault(x => x.Id == veiculosSelecionado.Id);

                labelKmVeiculo.Text = veiculo.QuilometragemPercorrida.ToString();
            }
        }

        private void comboBoxGrupoVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxVeiculo.SelectedIndex = -1;
            comboBoxVeiculo.Items.Clear();
            labelKmVeiculo.Text = string.Empty;

            var grupoVeiculosSelecionado = (GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem;

            _veiculos = _servicoVeiculo.BuscarPeloIdGrupoVeiculos(grupoVeiculosSelecionado.Id).Value;

            CarregarVeiculos();
        }
    }
}
