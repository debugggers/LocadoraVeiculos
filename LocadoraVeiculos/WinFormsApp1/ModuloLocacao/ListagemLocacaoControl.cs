using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloLocacao
{
    public partial class ListagemLocacaoControl : UserControl
    {
        public ListagemLocacaoControl()
        {
            InitializeComponent();
            gridLocacao.ConfigurarGridZebrado();
            gridLocacao.ConfigurarGridSomenteLeitura();
            gridLocacao.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Funcionario", HeaderText = "Funcionário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},
                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoVeiculos", HeaderText = "Grupo de Veículos"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Taxas", HeaderText = "Taxas"},
                new DataGridViewTextBoxColumn { DataPropertyName = "PlanosCobranca", HeaderText = "Planos de Cobrança"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veículo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "KmVeiculo", HeaderText = "Km do Veículo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataLocacao", HeaderText = "Data da Locação"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataPrevistaEntrega", HeaderText = "Data Prevista da Entrega"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPrevisto", HeaderText = "Valor Previsto"}
            };

            return colunas;
        }

        public Guid ObtemIdPlanoCobrancaSelecionado()
        {
            return gridLocacao.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            gridLocacao.Rows.Clear();

            foreach (var planoCobranca in locacoes)
            {
                gridLocacao.Rows.Add(
                    planoCobranca.Id,
                    planoCobranca.Funcionario.Nome,
                    planoCobranca.Cliente.Nome,
                    planoCobranca.GrupoVeiculos.Nome,
                    planoCobranca.Taxa.Descricao,
                    planoCobranca.PlanoCobranca.Id.ToString(),
                    planoCobranca.Veiculo.Placa,
                    planoCobranca.KmVeiculo.ToString(),
                    planoCobranca.DataLocacao.ToString(),
                    planoCobranca.DataPrevistaEntrega.ToString(),
                    planoCobranca.ValorPrevisto.ToString());
            }
        }
    }
}
