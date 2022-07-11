using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa
{
    public partial class ListagemEmpresasControl : UserControl
    {
        public ListagemEmpresasControl()
        {
            InitializeComponent();
            gridPessoaJuridica.ConfigurarGridZebrado();
            gridPessoaJuridica.ConfigurarGridSomenteLeitura();
            gridPessoaJuridica.Columns.AddRange(ObterColunasPessoaJuridica());
        }

        public void AtualizarRegistrosPessoaJuridica(List<Empresa> empresas)
        {
            gridPessoaJuridica.Rows.Clear();

            foreach (Empresa e in empresas)
            {
                gridPessoaJuridica.Rows.Add(e.Id, e.Nome, e.Email, e.Telefone, e.Endereco, e.CNPJ);
            }
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
            };

            return colunas;
        }

        public Guid SelecionarIdEmpresa()
        {
            return gridPessoaJuridica.SelecionarId<Guid>();
        }
    }
}
