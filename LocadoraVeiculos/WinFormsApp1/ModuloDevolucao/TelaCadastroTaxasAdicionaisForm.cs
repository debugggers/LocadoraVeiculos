using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloDevolucao;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloDevolucao
{
    public partial class TelaCadastroTaxasAdicionaisForm : Form
    {

        Devolucao devolucao;
        ServicoTaxa servicoTaxa;
        List<Taxa> taxas;

        public TelaCadastroTaxasAdicionaisForm(Devolucao devolucao, ServicoTaxa servicoTaxa)
        {
            InitializeComponent();
            this.devolucao = devolucao;
            this.servicoTaxa = servicoTaxa;
            taxas = servicoTaxa.SelecionarTodos().Value;
            IniciarTaxas();
        }

        

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            foreach (var item in checkedListBoxTaxas.SelectedItems)
            {

                foreach (var taxa in taxas)
                {

                    if (taxa.Descricao == item.ToString())
                        devolucao.AdicionarTaxas(taxa);

                }
            }

            Dispose();
        }

        private void IniciarTaxas()
        {

            if(taxas != null)
            {

                foreach (var item in taxas)
                {
                    if(devolucao.Locacao.Taxas.Contains(item))
                        checkedListBox1.Items.Add(item.Descricao);
                }

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }

            foreach (var item in taxas)
            {


                if (!devolucao.Locacao.Taxas.Contains(item))
                    checkedListBoxTaxas.Items.Add(item.Descricao);

            }
        }

        private void checkedListBoxTaxas_SelectedIndexChanged(object sender, EventArgs e)
        {

            

        }
    }
}
