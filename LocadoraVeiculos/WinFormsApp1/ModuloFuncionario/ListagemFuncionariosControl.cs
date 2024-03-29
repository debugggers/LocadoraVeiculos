﻿using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloFuncionario
{
    public partial class ListagemFuncionariosControl : UserControl
    {
        public ListagemFuncionariosControl()
        {
            InitializeComponent();
            gridFuncionarios.ConfigurarGridZebrado();
            gridFuncionarios.ConfigurarGridSomenteLeitura();
            gridFuncionarios.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Login", HeaderText = "Login"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Senha", HeaderText = "Senha"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataAdmissao", HeaderText = "Data de Admissão"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Salario", HeaderText = "Salário" },

                new DataGridViewTextBoxColumn { DataPropertyName = "EhAdmin", HeaderText = "É admin"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Ativo", HeaderText = "Ativo"}
            };

            return colunas;
        }

        public Guid ObtemIdFuncionarioSelecionado()
        {
            return gridFuncionarios.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            gridFuncionarios.Rows.Clear();

            foreach (var funcionario in funcionarios)
            {
                gridFuncionarios.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.Login, funcionario.Senha, 
                    funcionario.DataAdmissao.ToShortDateString(), funcionario.Salario.ToString(), funcionario.EhAdmin.ToString(),
                    funcionario.Ativo.ToString());
            }
        }
    }
}
