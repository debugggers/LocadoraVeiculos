using FluentResults;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        private Locacao _locacao;

        private List<Funcionario> _funcionarios;
        private ServicoFuncionario _servicoFuncionario;

        private List<Cliente> _clientes;
        private ServicoCliente _servicoCliente;

        private List<GrupoVeiculos> _gruposVeiculos;
        private ServicoGrupoVeiculos _servicoGrupoVeiculos;

        private List<PlanoCobranca> _planosCobranca;
        private ServicoPlanoCobranca _servicoPlanoCobranca;

        private List<Taxa> _taxas;
        private ServicoTaxa _servicoTaxa;

        private List<Veiculo> _veiculos;
        private ServicoVeiculo _servicoVeiculo;

        public TelaCadastroLocacaoForm(ServicoFuncionario servicoFuncionario, ServicoCliente servicoCliente,
            ServicoGrupoVeiculos servicoGrupoVeiculos, ServicoPlanoCobranca servicoPlanoCobranca,
            ServicoTaxa servicoTaxa, ServicoVeiculo servicoVeiculo)
        {
            InitializeComponent();

            _servicoFuncionario = servicoFuncionario;
            _funcionarios = _servicoFuncionario.SelecionarTodos().Value;

            _servicoCliente = servicoCliente;
            _clientes = _servicoCliente.SelecionarTodos().Value;

            _servicoGrupoVeiculos = servicoGrupoVeiculos;
            _gruposVeiculos = _servicoGrupoVeiculos.SelecionarTodos().Value;

            _servicoPlanoCobranca = servicoPlanoCobranca;
            _planosCobranca = _servicoPlanoCobranca.SelecionarTodos().Value;

            _servicoTaxa = servicoTaxa;
            _taxas = _servicoTaxa.SelecionarTodos().Value;

            _servicoVeiculo = servicoVeiculo;
            _veiculos = _servicoVeiculo.SelecionarTodos().Value;

            dateTimeLocacao.MinDate = DateTime.Now.Date;
            dateTimePrevisaoEntrega.MinDate = DateTime.Now.Date;


            CarregarFuncionarios();
            CarregarClientes();
            CarregarGrupoVeiculos();
            CarregarPlanosCobranca();
            CarregarTaxas();
            CarregarVeiculos();
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        public Locacao Locacao
        {
            get { return _locacao; }
            set
            {
                _locacao = value;

                labelFuncionario.Text = _locacao.Funcionario.Nome;
                comboBoxClientes.SelectedItem = _locacao.Cliente;
                comboBoxGrupoVeiculos.SelectedItem = _locacao.GrupoVeiculos;
                comboBoxPlanosCobranca.SelectedItem = _locacao.PlanoCobranca;
                comboBoxVeiculo.SelectedItem = _locacao.Veiculo;
                labelKmVeiculo.Text = _locacao.Veiculo.QuilometragemPercorrida.ToString();

                if (_locacao.DataLocacao == DateTime.MinValue)
                    dateTimeLocacao.Value = DateTime.Now.Date;
                else
                    dateTimeLocacao.Value = _locacao.DataLocacao;

                if (_locacao.DataPrevistaEntrega == DateTime.MinValue)
                    dateTimePrevisaoEntrega.Value = DateTime.Now.Date;
                else
                    dateTimePrevisaoEntrega.Value = _locacao.DataPrevistaEntrega;

                labelValorPrevisto.Text = _locacao.ValorPrevisto.ToString();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            _locacao.Funcionario.Nome = labelFuncionario.Text;

            _locacao.Cliente = (Cliente)comboBoxClientes.SelectedItem;
            _locacao.ClienteId = _locacao.Cliente.Id;

            _locacao.GrupoVeiculos = (GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem;
            _locacao.GrupoVeiculosId = _locacao.GrupoVeiculos.Id;

            _locacao.PlanoCobranca = (PlanoCobranca)comboBoxPlanosCobranca.SelectedItem;
            _locacao.PlanoCobrancaId = _locacao.PlanoCobranca.Id;

            _locacao.Veiculo = (Veiculo)comboBoxVeiculo.SelectedItem;
            _locacao.VeiculoId = _locacao.Veiculo.Id;

            _locacao.KmVeiculo = _locacao.Veiculo.QuilometragemPercorrida;

            _locacao.DataLocacao = Convert.ToDateTime(dateTimeLocacao.Value);
            _locacao.DataPrevistaEntrega = Convert.ToDateTime(dateTimePrevisaoEntrega.Value);

            
            var resultadoValidacao = GravarRegistro(_locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Inserção de Locação",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    labelRodapeLocacao.Text = erro;

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void CarregarFuncionarios()
        {
        }

        private void CarregarClientes()
        {
            comboBoxClientes.Items.Clear();

            foreach (var item in _clientes)
            {
                comboBoxClientes.Items.Add(item);
            }
        }

        private void CarregarGrupoVeiculos()
        {
            comboBoxGrupoVeiculos.Items.Clear();

            foreach (var item in _gruposVeiculos)
            {
                comboBoxGrupoVeiculos.Items.Add(item);
            }
        }

        private void CarregarPlanosCobranca()
        {
            comboBoxPlanosCobranca.Items.Clear();

            foreach (var item in _planosCobranca)
            {
                comboBoxPlanosCobranca.Items.Add(item);
            }
        }

        private void CarregarTaxas()
        {
            checkedListBoxTaxas.Items.Clear();

            foreach (var item in _taxas)
            {
                checkedListBoxTaxas.Items.Add(item);
            }
        }

        private void CarregarVeiculos()
        {
            comboBoxVeiculo.Items.Clear();

            foreach (var item in _veiculos)
            {
                comboBoxVeiculo.Items.Add(item);
            }
        }
    }
}
