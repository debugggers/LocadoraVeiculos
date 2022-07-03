using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculosForm.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloVeiculo
{
    public partial class ListagemVeiculosControl : UserControl
    {
        public ListagemVeiculosControl()
        {
            InitializeComponent();
            gridVeiculos.ConfigurarGridZebrado();
            gridVeiculos.ConfigurarGridSomenteLeitura();
            gridVeiculos.Columns.AddRange(ObterColunas());
        }

        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            gridVeiculos.Rows.Clear();

            foreach (Veiculo v in veiculos)
            {
                gridVeiculos.Rows.Add(v.Id, v.Marca, v.Modelo, v.Cor, v.Placa, v.Ano, v.TipoCombustivel, v.CapacidadeTanque, v.QuilometragemPercorrida, v.GrupoVeiculo.Nome);
            }

        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCombustivel", HeaderText = "Tipo combustivel"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CapacidadeTanque", HeaderText = "Capacidade do tanque"},

                new DataGridViewTextBoxColumn { DataPropertyName = "KmPercorridos", HeaderText = "Quilometragem percorrida"},

                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoVeiculos", HeaderText = "Grupo de veiculos"}
            };

            return colunas;
        }

        public int SelecionarNumeroVeiculo()
        {
            return gridVeiculos.SelecionarId<int>();
        }

    }
}
