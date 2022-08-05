using FluentResults;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloVeiculo
{
    public partial class TelaCadastroVeiculosForm : Form
    {

        Veiculo veiculo;
        List<GrupoVeiculos> gruposVeiculos;
        private ServicoGrupoVeiculos _servicoGrupoVeiculos;

        public TelaCadastroVeiculosForm(ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            InitializeComponent();
            CarregarTipoCombustivel();
            _servicoGrupoVeiculos = servicoGrupoVeiculos;
            gruposVeiculos = _servicoGrupoVeiculos.SelecionarTodos().Value;
            InicializarComboBoxGrupoVeiculos(gruposVeiculos);

        }

        public Func<Veiculo, Result<Veiculo>> GravarRegistro { get; set; }

        public Veiculo Veiculo
        {
            get
            {
                return veiculo;
            }
            set
            {
                veiculo = value;
                txtMarca.Text = veiculo.Marca;
                txtModelo.Text = veiculo.Modelo;
                maskedTxtPlaca.Text = veiculo.Placa;
                txtCor.Text = veiculo.Cor;
                txtCapacidadeTanque.Text = veiculo.CapacidadeTanque.ToString();
                txtAno.Text = veiculo.Ano.ToString();
                txtKm.Text = veiculo.QuilometragemPercorrida.ToString();
                comboBoxGrupoVeiculos.SelectedItem = veiculo.GrupoVeiculos;
                comboBoxCombustivel.SelectedItem = veiculo.TipoCombustivel;
                if(veiculo.Foto != null)
                {

                    byte[] data = veiculo.Foto;
                    var foto = Image.FromStream(new System.IO.MemoryStream(data));
                    pictureBoxVeiculo.Image = foto;

                }
            }
        }


        private void TelaCadastroVeiculoForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroVeiculoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void btnImagem_Click(object sender, EventArgs e)
        {

            try
            {

                openFileDialog1.FileName = "";

                openFileDialog1.Filter = "Arquivos de Imagem (*.jpg;*.gif)|*.jpg;*.gif";

                openFileDialog1.ShowDialog();

                pictureBoxVeiculo.Image = Image.FromFile(openFileDialog1.FileName);

                //veiculo.Foto = (Bitmap)pictureBoxVeiculo.Image;

                MemoryStream ms = new MemoryStream();

                pictureBoxVeiculo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] buff = ms.GetBuffer();

                veiculo.Foto = buff;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Caminho de imagem vazio! Por favor selecione uma imagem",
                "Inserção de imagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;

            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            veiculo.Marca = txtMarca.Text;
            veiculo.Modelo = txtModelo.Text;
            veiculo.Placa = maskedTxtPlaca.Text;
            veiculo.Cor = txtCor.Text;
            veiculo.CapacidadeTanque = Convert.ToInt32(txtCapacidadeTanque.Text);
            veiculo.QuilometragemPercorrida = Convert.ToInt32(txtKm.Text);
            veiculo.Ano = Convert.ToInt32(txtAno.Text);
            veiculo.TipoCombustivel = (CombustivelEnum)comboBoxCombustivel.SelectedItem;
            foreach (var item in gruposVeiculos)
            {

                if (item.Nome.Equals(comboBoxGrupoVeiculos.SelectedItem))
                    veiculo.GrupoVeiculos = item;

            }

            var resultadoValidacao = GravarRegistro(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                    labelRodapeVeiculo.Text = erro;

                    DialogResult = DialogResult.None;
                }

            }

        }

        private void InicializarComboBoxGrupoVeiculos(List<GrupoVeiculos> gruposVeiculos)
        {
            foreach (var g in gruposVeiculos)
            {

                comboBoxGrupoVeiculos.Items.Add(g.Nome);

            }
        }

        private void CarregarTipoCombustivel()
        {
            var tipoCombustivel = Enum.GetValues(typeof(CombustivelEnum));

            foreach (var item in tipoCombustivel)
            {
                comboBoxCombustivel.Items.Add(item);
            }
        }
    }
}
