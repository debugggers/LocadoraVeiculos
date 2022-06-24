using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
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

            gridPessoaJuridica.ConfigurarGridZebrado();
            gridPessoaJuridica.ConfigurarGridSomenteLeitura();
            gridPessoaJuridica.Columns.AddRange(ObterColunasPessoaJuridica());
        }

        public void AtualizarRegistros(List<Cliente> clientes)
        {

            grid.Rows.Clear();

            foreach (Cliente c in clientes)
            {

                grid.Rows.Add(c.Id, c.Nome, c.Email, c.Telefone, c.Endereco, c.CPF, c.CnhNumero, c.CnhNome, c.CnhVencimento.ToShortDateString());

            }

        }
        public void AtualizarRegistrosPessoaJuridica(List<Empresa> empresas)
        {

            gridPessoaJuridica.Rows.Clear();

            foreach (Empresa e in empresas)
            {

                grid.Rows.Add(e.Id, e.Nome, e.Email, e.Telefone, e.Endereco, e.CNPJ, e.Condutor.Id);

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

        private DataGridViewColumn[] ObterColunasPessoaJuridica()
        {
            var colunas = new DataGridViewColumn[]
            {

                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "E-mail"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cnpj", HeaderText = "CNPJ"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente_Numero", HeaderText = "Número condutor"}

            };

            return colunas;
        }

        public int SelecionarNumeroCliente()
        {

            return grid.SelecionarNumero<int>();

        }

        public int SelecionarNumeroEmpresa()
        {

            return gridPessoaJuridica.SelecionarNumero<int>();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
