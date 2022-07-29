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
        public  decimal NivelDoTanque { get; set; }
        public  List<Taxa>? Taxas { get; set; }
        public decimal ValorTotal { get; set; }

        public Devolucao()
        {
        }

        public Devolucao(Locacao locacao, int quilometragemVeiculo, DateTime dataDevolucao, decimal nivelDoTanque, List<Taxa> taxas, decimal valorTotal)
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

        public decimal CalcularTotalGasolina()
        {

            decimal total = 0;

            switch (NivelDoTanque)
            {

                case 1m:
                    total += 5.89m * Locacao.Veiculo.CapacidadeTanque;
                    break;
                case 1/4m:
                    total += 5.89m * (Locacao.Veiculo.CapacidadeTanque - (Locacao.Veiculo.CapacidadeTanque * 0.25m));
                    break;
                case 1/2m:
                    total += 5.89m * (Locacao.Veiculo.CapacidadeTanque - (Locacao.Veiculo.CapacidadeTanque * 0.5m));
                    break;
                case 3/4m:
                    total += 5.89m * (Locacao.Veiculo.CapacidadeTanque - (Locacao.Veiculo.CapacidadeTanque * 0.75m));
                    break;
            }

           return total;
        } 

        public decimal CalcularTotalData()
        {

            decimal total = 0;

            int resultado = DateTime.Compare(Locacao.DataPrevistaEntrega.Date, DataDevolucao.Date);

            if (resultado == -1)
                total = Locacao.ValorPrevisto + (Locacao.ValorPrevisto * 0.10m);
            else if (resultado == 1)
                total = Locacao.ValorPrevisto + (Locacao.ValorPrevisto * 0.10m);

            return total;

        }
    }
}
