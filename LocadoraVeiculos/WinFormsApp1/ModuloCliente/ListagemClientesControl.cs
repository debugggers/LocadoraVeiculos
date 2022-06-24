using LocadoraVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            };

            return colunas;
        }

        public int SelecionarNumeroCliente()
        {

            return grid.SelecionarNumero<int>();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
