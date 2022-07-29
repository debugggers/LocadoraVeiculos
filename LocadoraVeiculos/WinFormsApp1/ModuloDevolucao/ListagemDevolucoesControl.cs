using LocadoraVeiculos.Dominio.ModuloDevolucao;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloDevolucao
{
    public partial class ListagemDevolucoesControl : UserControl
    {
        public ListagemDevolucoesControl()
        {
            InitializeComponent();
            GridDevolucao.ConfigurarGridZebrado();
            GridDevolucao.ConfigurarGridSomenteLeitura();
            GridDevolucao.Columns.AddRange(ObterColunas());

        }

        public void AtualizarRegistros(List<Devolucao> devolucoes)
        {
            GridDevolucao.Rows.Clear();

            foreach (Devolucao d in devolucoes)
            {

                GridDevolucao.Rows.Add(d.Id, d.Locacao.Id, d.QuilometragemVeiculo, d.DataDevolucao.ToShortDateString(), d.NivelDoTanque, d.ValorTotal);

            }

        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "IdLocacao", HeaderText = "Id da locação"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Quilometragem", HeaderText = "Quilometragem do veículo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucao", HeaderText = "Data de devolução"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NivelTanque", HeaderText = "Nivel do tanque entregue"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorTotal", HeaderText = "Valor total"}
            };

            return colunas;
        }

        public Guid SelecionarIdDevolucao()
        {
            return GridDevolucao.SelecionarId<Guid>();
        }

    }
}
