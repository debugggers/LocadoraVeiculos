using FluentValidation.Results;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using Serilog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloPlanoCobranca
{
    public partial class TelaCadastroPlanoCobrancaForm : Form
    {
        private PlanoCobranca _planoCobranca;
        private ServicoPlanoCobranca _servicoPlanoCobranca;
        private List<GrupoVeiculos> _gruposVeiculos;
        private RepositorioGrupoVeiculosEmBancoDados _repositorioGrupoVeiculos = new();

        public TelaCadastroPlanoCobrancaForm(ServicoPlanoCobranca servicoPlanoCobranca)
        {
            InitializeComponent();

            _servicoPlanoCobranca = servicoPlanoCobranca;

            _gruposVeiculos = _repositorioGrupoVeiculos.SelecionarTodos();

            CarregarGrupoVeiculos();
        }

        public Func<PlanoCobranca, ValidationResult> GravarRegistro { get; set; }

        public PlanoCobranca PlanoCobranca
        {
            get { return _planoCobranca; }
            set
            {
                _planoCobranca = value;
                 
                txtId.Text = _planoCobranca.Id.ToString();
                comboBoxGrupoVeiculos.SelectedItem = _planoCobranca.GrupoVeiculos;

                CarregarFormularioTipoPlano();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (CamposEstaoValidos())
            {
                CarregarPlanoCobranca();

                var resultadoValidacao = GravarRegistro(_planoCobranca);

                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    labelRodapePlanoCobranca.Text = erro;

                    DialogResult = DialogResult.None;
                }
            }
        }

        private bool CamposEstaoValidos()
        {
            if (!CampoEstaValido(txtValorDiario_Diario.Text, PlanoCobrancaConstantes.ValorDiarioConst, PlanoCobrancaConstantes.DiarioConst))
                return false;

            if (!CampoEstaValido(txtValorPorKm_Diario.Text, PlanoCobrancaConstantes.ValorPorKMConst, PlanoCobrancaConstantes.DiarioConst))
                return false;

            if (!CampoEstaValido(txtValorDiario_Livre.Text, PlanoCobrancaConstantes.ValorDiarioConst, PlanoCobrancaConstantes.LivreConst))
                return false;

            if (!CampoEstaValido(txtValorDiario_Controlado.Text, PlanoCobrancaConstantes.ValorDiarioConst, PlanoCobrancaConstantes.ControladoConst))
                return false;            

            if (!CampoEstaValido(txtValorPorKm_Controlado.Text, PlanoCobrancaConstantes.ValorPorKMConst, PlanoCobrancaConstantes.ControladoConst))
                return false;

            if (!CampoEstaValido(txtControleKm.Text, PlanoCobrancaConstantes.ControleKMConst, PlanoCobrancaConstantes.ControladoConst))
                return false;

            return true;
        }

        private bool CampoEstaValido(string txtValorDiarioString, string nomeCampo, string nomeAba)
        {
            decimal valorDiario;

            if (decimal.TryParse(txtValorDiarioString, out valorDiario))
            {
                if (valorDiario < 1)
                {
                    var mensagemErro = $"Campo '{nomeCampo}' da aba '{nomeAba}' deve ser maior que zero.";

                    labelRodapePlanoCobranca.Text = mensagemErro;
                    DialogResult = DialogResult.None;

                    Log.Logger.Warning(mensagemErro);

                    return false;
                }
            }
            else
            {
                var mensagemErro = $"Campo '{nomeCampo}' da aba '{nomeAba}' está inválido.";
                
                labelRodapePlanoCobranca.Text = mensagemErro;
                DialogResult = DialogResult.None;

                Log.Logger.Warning(mensagemErro);

                return false;
            }

            return true;
        }

        private void CarregarPlanoCobranca()
        {
            _planoCobranca.ValorDiario_Diario = Convert.ToDecimal(txtValorDiario_Diario.Text);
            _planoCobranca.ValorPorKm_Diario = Convert.ToDecimal(txtValorPorKm_Diario.Text);

            _planoCobranca.ValorDiario_Livre = Convert.ToDecimal(txtValorDiario_Livre.Text);

            _planoCobranca.ValorDiario_Controlado = Convert.ToDecimal(txtValorDiario_Controlado.Text);
            _planoCobranca.ValorPorKm_Controlado = Convert.ToDecimal(txtValorPorKm_Controlado.Text);
            _planoCobranca.ControleKm = Convert.ToInt32(txtControleKm.Text);

            _planoCobranca.GrupoVeiculos = (GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem;
            _planoCobranca.IdGrupoVeiculos = _planoCobranca.GrupoVeiculos.Id;
        }

        private void CarregarFormularioTipoPlano()
        {
            if (_planoCobranca.Id != Guid.Empty)
            {
                txtValorDiario_Diario.Text = _planoCobranca.ValorDiario_Diario.ToString();
                txtValorPorKm_Diario.Text = _planoCobranca.ValorPorKm_Diario.ToString();

                txtValorDiario_Livre.Text = _planoCobranca.ValorDiario_Livre.ToString();

                txtValorDiario_Controlado.Text = _planoCobranca.ValorDiario_Controlado.ToString();
                txtValorPorKm_Controlado.Text = _planoCobranca.ValorPorKm_Diario.ToString();
                txtControleKm.Text = _planoCobranca.ControleKm.ToString();
            }
            else
                comboBoxGrupoVeiculos.SelectedIndex = 0;
        }

        private void CarregarGrupoVeiculos()
        {
            comboBoxGrupoVeiculos.Items.Clear();

            foreach (var item in _gruposVeiculos)
            {
                comboBoxGrupoVeiculos.Items.Add(item);
            }
        }
    }
}
