using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculosForm.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloPlanoCobranca
{
    public partial class ListagemPlanoCobrancaControl : UserControl
    {
        public ListagemPlanoCobrancaControl()
        {
            InitializeComponent();
            gridPlanoCobranca.ConfigurarGridZebrado();
            gridPlanoCobranca.ConfigurarGridSomenteLeitura();
            gridPlanoCobranca.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario_Diario", HeaderText = "Valor Diário_Diário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPorKm_Diario", HeaderText = "Valor por Km_Diário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario_Livre", HeaderText = "Valor Diário_Livre"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario_Controlado", HeaderText = "Valor Diário_Controlado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPorKm_Controlado", HeaderText = "Valor por Km_Controlado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ControleKm", HeaderText = "Controle Km"},
                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoVeiculos", HeaderText = "Grupo de Veiculos"}
            };

            return colunas;
        }

        public int ObtemIdPlanoCobrancaSelecionado()
        {
            return gridPlanoCobranca.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<PlanoCobranca> planosCobranca)
        {
            gridPlanoCobranca.Rows.Clear();

            foreach (var planoCobranca in planosCobranca)
            {
                gridPlanoCobranca.Rows.Add(
                    planoCobranca.Id, 
                    planoCobranca.ValorDiario_Diario.ToString(), 
                    planoCobranca.ValorPorKm_Diario.ToString(), 
                    planoCobranca.ValorDiario_Livre.ToString(), 
                    planoCobranca.ValorDiario_Controlado.ToString(), 
                    planoCobranca.ValorPorKm_Controlado.ToString(), 
                    planoCobranca.ControleKm.ToString(), 
                    planoCobranca.GrupoVeiculos.Nome);
            }
        }
    }
}
