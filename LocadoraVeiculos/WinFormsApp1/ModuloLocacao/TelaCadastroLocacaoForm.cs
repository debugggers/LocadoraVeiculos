﻿using FluentResults;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
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
        private ServicoLocacao _servicoLocacao;

        private List<Cliente> _clientes;
        private ServicoCliente _servicoCliente;

        private List<GrupoVeiculos> _gruposVeiculos;
        private ServicoGrupoVeiculos _servicoGrupoVeiculos;

        private List<Taxa> _taxas;
        private ServicoTaxa _servicoTaxa;

        private List<Veiculo> _veiculos;
        private ServicoVeiculo _servicoVeiculo;

        private PlanoCobranca _planoCobranca;
        private ServicoPlanoCobranca _servicoPlanoCobranca;

        decimal _valorPrevisto = 0;
        Guid _idVeiculoSelecionado = new Guid();

        public TelaCadastroLocacaoForm(ServicoLocacao servicoLocacao, ServicoCliente servicoCliente, ServicoGrupoVeiculos servicoGrupoVeiculos,
            ServicoTaxa servicoTaxa, ServicoVeiculo servicoVeiculo, ServicoPlanoCobranca servicoPlanoCobranca)
        {
            InitializeComponent();

            checkedListBoxTaxas.DisplayMember = "Descricao";
            checkedListBoxTaxas.ValueMember = "Id";

            _servicoLocacao = servicoLocacao;

            _servicoCliente = servicoCliente;
            _clientes = _servicoCliente.SelecionarTodos().Value;

            _servicoGrupoVeiculos = servicoGrupoVeiculos;
            _gruposVeiculos = _servicoGrupoVeiculos.SelecionarTodos().Value;

            _servicoTaxa = servicoTaxa;
            _taxas = _servicoTaxa.SelecionarTodos().Value;

            _servicoVeiculo = servicoVeiculo;

            _servicoPlanoCobranca = servicoPlanoCobranca;

            dateTimeLocacao.MinDate = DateTime.Now.Date;
            dateTimePrevisaoEntrega.MinDate = DateTime.Now.Date;

            CarregarClientes();
            CarregarGrupoVeiculos();
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        public Locacao Locacao
        {
            get { return _locacao; }
            set
            {
                _locacao = value;

                CarregarCheckBoxTaxas();
                CarregarPlanosCobranca();

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
            }
        }        

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            _locacao.FuncionarioId = GerenciadorUsuario.ObtemId();

            var clienteSelecionado = (Cliente)comboBoxClientes.SelectedItem;
            if (clienteSelecionado == null)
            {
                labelRodapeLocacao.Text = "Cliente deve ser informado";

                DialogResult = DialogResult.None;
            }
            else
            {
                _locacao.Cliente = clienteSelecionado;
                _locacao.ClienteId = clienteSelecionado.Id;
            }

            var grupoVeiculosSelecionado = (GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem;
            if (grupoVeiculosSelecionado == null)
            {
                labelRodapeLocacao.Text = "Grupo de Veículos deve ser informado";

                DialogResult = DialogResult.None;
            }
            else
            {
                _locacao.GrupoVeiculos = grupoVeiculosSelecionado;
                _locacao.GrupoVeiculosId = _locacao.GrupoVeiculos.Id;
            }

            _locacao.PlanosCobranca = (PlanoCobrancaEnum)comboBoxPlanosCobranca.SelectedItem;

            var veiculoSelecionado = (Veiculo)comboBoxVeiculo.SelectedItem;

            if (veiculoSelecionado == null)
            {
                labelRodapeLocacao.Text = "Veículo deve ser informado";

                DialogResult = DialogResult.None;
            }
            else
            {
                veiculoSelecionado.EstaDisponivel = false;
                _locacao.Veiculo = veiculoSelecionado;
                _locacao.VeiculoId = _locacao.Veiculo.Id;

                _locacao.DataLocacao = Convert.ToDateTime(dateTimeLocacao.Value);
                _locacao.DataPrevistaEntrega = Convert.ToDateTime(dateTimePrevisaoEntrega.Value);

                CarregarTaxasNaLocacao();

                _locacao.ValorPrevisto = _valorPrevisto;

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
            if (_locacao.Taxas != null)
            {
                _locacao.Taxas.Clear();
                _locacao.Taxas = ObterTaxasSelecionadas();
            }
        }

        private void CarregarVeiculos()
        {
            comboBoxVeiculo.Items.Clear();

            if (_veiculos.Count > 0 )
            {
                foreach (var item in _veiculos)
                    comboBoxVeiculo.Items.Add(item);
            }            
        }

        private void comboBoxVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVeiculo.SelectedIndex >= 0)
            {
                var veiculosSelecionado = (Veiculo)comboBoxVeiculo.SelectedItem;

                var veiculo = _veiculos.FirstOrDefault(x => x.Id == veiculosSelecionado.Id);

                labelKmVeiculo.Text = veiculo.QuilometragemPercorrida.ToString();

                if (_idVeiculoSelecionado != Guid.Empty && veiculo.EstaDisponivel == false)
                    _servicoVeiculo.DisponibilizarVeiculoPeloId(_idVeiculoSelecionado);

                _idVeiculoSelecionado = veiculo.Id;
            }
        }

        private void comboBoxGrupoVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxVeiculo.SelectedIndex = -1;
            comboBoxVeiculo.Items.Clear();
            labelKmVeiculo.Text = string.Empty;

            var grupoVeiculosSelecionado = (GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem;

            _veiculos = _servicoVeiculo.BuscarVeiculosDisponiveisPeloIdGrupoVeiculos(grupoVeiculosSelecionado.Id).Value;

            if (EhEdicao())
                _veiculos.Add(_locacao.Veiculo);

            _planoCobranca = _servicoPlanoCobranca.BuscarPlanoIdGrupoVeiculos(grupoVeiculosSelecionado.Id).Value;

            CarregarVeiculos();
            CarregarValorPrevisto();
        }

        private void CarregarValorPrevisto()
        {
            if (_planoCobranca != null)
            {
                var planoCobrancaEnum = (PlanoCobrancaEnum)comboBoxPlanosCobranca.SelectedItem;

                var taxasSelecionadas = ObterTaxasSelecionadas();

                _valorPrevisto = _servicoLocacao.CalcularValorPrevisto(dateTimeLocacao.Value, dateTimePrevisaoEntrega.Value, _planoCobranca,
                                planoCobrancaEnum, taxasSelecionadas);

                labelValorPrevisto.Text = _valorPrevisto.ToString("C");
            }
        }

        private List<Taxa> ObterTaxasSelecionadas()
        {
            var taxasSelecionadas = new List<Taxa>();

            foreach (var item in checkedListBoxTaxas.CheckedItems)
                taxasSelecionadas.Add((Taxa)item);

            return taxasSelecionadas;
        }

        private void comboBoxPlanosCobranca_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarValorPrevisto();
        }

        private void dateTimeLocacao_ValueChanged(object sender, EventArgs e)
        {
            CarregarValorPrevisto();
        }

        private void dateTimePrevisaoEntrega_ValueChanged(object sender, EventArgs e)
        {
            CarregarValorPrevisto();
        }

        private void checkedListBoxTaxas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarValorPrevisto();
        }

        private void checkedListBoxTaxas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CarregarValorPrevisto();
        }

        private void checkedListBoxTaxas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CarregarValorPrevisto();
        }

        private void checkedListBoxTaxas_KeyUp(object sender, KeyEventArgs e)
        {
            CarregarValorPrevisto();
        }

        private bool EhEdicao()
        {
            return _locacao.ClienteId == Guid.Empty ? false : true;
        }
    }
}
