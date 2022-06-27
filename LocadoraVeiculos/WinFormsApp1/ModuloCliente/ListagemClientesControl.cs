using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloCliente
{
    public partial class ListagemClientesControl : UserControl
    {
        public ListagemClientesControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public void AtualizarRegistros(List<Cliente> clientes)
        {
            grid.Rows.Clear();

            foreach (Cliente c in clientes)
            {
                grid.Rows.Add(c.Id, c.Nome, c.Email, c.Telefone, c.Endereco, c.CPF, c.CnhNumero, c.CnhNome, c.CnhVencimento.ToShortDateString());
            }

        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "E-mail"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CnhNumero", HeaderText = "Número CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CnhNome", HeaderText = "Nome CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CnhVencimento", HeaderText = "Data de vencimento CNH"}
            };

            return colunas;
        }

        public int SelecionarNumeroCliente()
        {
            return grid.SelecionarId<int>();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
