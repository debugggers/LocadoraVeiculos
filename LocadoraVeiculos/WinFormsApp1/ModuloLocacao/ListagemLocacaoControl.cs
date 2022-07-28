using LocadoraVeiculos.Dominio.Compartilhado;
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
                new DataGridViewTextBoxColumn { DataPropertyName = "PlanosCobranca", HeaderText = "Planos de Cobrança"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veículo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "KmVeiculo", HeaderText = "Km do Veículo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataLocacao", HeaderText = "Data da Locação"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataPrevistaEntrega", HeaderText = "Data Prevista da Entrega"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPrevisto", HeaderText = "Valor Previsto"}
            };

            return colunas;
        }

        public Guid ObtemIdLocacaoSelecionada()
        {
            return gridLocacao.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            gridLocacao.Rows.Clear();

            foreach (var locacao in locacoes)
            {
                gridLocacao.Rows.Add(
                    locacao.Id,
                    locacao.Funcionario == null ? GerenciadorUsuario.ObtemNome() : locacao.Funcionario.Nome,
                    locacao.Cliente.Nome,
                    locacao.GrupoVeiculos.Nome,
                    locacao.PlanosCobranca.ToString(),
                    $"{locacao.Veiculo.Modelo} - {locacao.Veiculo.Placa}",
                    locacao.Veiculo.QuilometragemPercorrida,
                    locacao.DataLocacao.ToString(),
                    locacao.DataPrevistaEntrega.ToString(),
                    locacao.ValorPrevisto.ToString());
            }
        }
    }
}
