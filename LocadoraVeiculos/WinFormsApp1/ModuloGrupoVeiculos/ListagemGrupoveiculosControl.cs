using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloGrupoVeiculos
{
    public partial class ListagemGrupoveiculosControl : UserControl
    {
        public ListagemGrupoveiculosControl()
        {
            InitializeComponent();
            gridGrupoVeiculos.ConfigurarGridZebrado();
            gridGrupoVeiculos.ConfigurarGridSomenteLeitura();
            gridGrupoVeiculos.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {

                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"}
            };

            return colunas;
        }

        public Guid SelecionarIdGrupoVeiculos()
        {
            return gridGrupoVeiculos.SelecionarId<Guid>();
        }
        internal void AtualizarRegistros(List<GrupoVeiculos> grupoVeiculos)
        {
            gridGrupoVeiculos.Rows.Clear();

            foreach (GrupoVeiculos t in grupoVeiculos)
            {
                gridGrupoVeiculos.Rows.Add(t.Id, t.Nome);
            }
        }

        private void gridFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
