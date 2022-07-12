using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloTaxa
{
    public partial class ListagemTaxasControl : UserControl
    {
        public ListagemTaxasControl()
        {
            InitializeComponent();
            gridTaxas.ConfigurarGridZebrado();
            gridTaxas.ConfigurarGridSomenteLeitura();
            gridTaxas.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCalculo", HeaderText = "Tipo de Cálculo"}
            };

            return colunas;
        }

        public Guid SelecionarIdTaxa()
        {
            return gridTaxas.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<Taxa> taxas)
        {
            gridTaxas.Rows.Clear();

            foreach (Taxa t in taxas)
            {
                gridTaxas.Rows.Add(t.Id, t.Descricao, t.Valor, t.TipoCalculo);
            }
        }
    }
}
