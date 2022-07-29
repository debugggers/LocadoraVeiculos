using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloDevolucao
{
    public class Devolucao : EntidadeBase<Devolucao>
    {

        public Locacao Locacao { get; set; }
        public  Guid LocacaoId { get; set; }
        public int QuilometragemVeiculo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public  Double NivelDoTanque { get; set; }
        public  List<Taxa>? Taxas { get; set; }
        public Double ValorTotal { get; set; }

        public Devolucao()
        {
        }

        public Devolucao(Locacao locacao, int quilometragemVeiculo, DateTime dataDevolucao, double nivelDoTanque, List<Taxa> taxas, double valorTotal)
        {
            Locacao = locacao;
            QuilometragemVeiculo = quilometragemVeiculo;
            DataDevolucao = dataDevolucao;
            NivelDoTanque = nivelDoTanque;
            Taxas = taxas;
            ValorTotal = valorTotal;
        }

        public override bool Equals(object obj)
        {
            return obj is Devolucao devolucao &&
                  Id == devolucao.Id &&
                  Locacao == devolucao.Locacao &&
                  QuilometragemVeiculo == devolucao.QuilometragemVeiculo &&
                  DataDevolucao == devolucao.DataDevolucao &&
                  NivelDoTanque == devolucao.NivelDoTanque &&
                  Taxas == devolucao.Taxas &&
                  ValorTotal == devolucao.ValorTotal;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public double CalcularTotal()
        {
            return 0;
        }

        public bool EntregueAntesDataPrevista()
        {
            return false;
        } 

    }
}
