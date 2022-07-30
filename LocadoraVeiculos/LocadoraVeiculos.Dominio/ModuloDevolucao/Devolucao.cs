using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
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

        public decimal CalcularGasolina()
        {

            switch (NivelDoTanque)
            {

                case 1m:
                    return 5.89m * Locacao.Veiculo.CapacidadeTanque;
                case 1/4m:
                    return 5.89m * (Locacao.Veiculo.CapacidadeTanque - (Locacao.Veiculo.CapacidadeTanque * 0.25m));
                case 1/2m:
                    return 5.89m * (Locacao.Veiculo.CapacidadeTanque - (Locacao.Veiculo.CapacidadeTanque * 0.5m));
                case 3/4m:
                    return 5.89m * (Locacao.Veiculo.CapacidadeTanque - (Locacao.Veiculo.CapacidadeTanque * 0.75m));
                default:
                    return 0m;
            }
        } 

        public decimal CalcularTotal(List<PlanoCobranca> planos)
        {

            PlanoCobranca planoCobrancaSelecionado = null;
            decimal total = 0;
            var dias = (int)DataDevolucao.Subtract(Locacao.DataLocacao).TotalDays;
            decimal quilometragemPercorrida = QuilometragemVeiculo - Locacao.Veiculo.QuilometragemPercorrida;

            foreach (var plano in planos)
            {

                if(plano.GrupoVeiculos.Id == Locacao.GrupoVeiculos.Id)
                {

                    planoCobrancaSelecionado = plano;
                    break;

                }
            }

            switch (Locacao.PlanosCobranca)
            {

                case PlanoCobrancaEnum.Diario:
                    total = (planoCobrancaSelecionado.ValorDiario_Diario * dias)  + (planoCobrancaSelecionado.ValorPorKm_Diario * quilometragemPercorrida);
                    break;
                case PlanoCobrancaEnum.Livre:
                    total = (planoCobrancaSelecionado.ValorDiario_Livre * dias);
                    break;
                case PlanoCobrancaEnum.Controlado:
                    if (quilometragemPercorrida > planoCobrancaSelecionado.ControleKm)
                        total = (planoCobrancaSelecionado.ValorDiario_Controlado * dias) + (planoCobrancaSelecionado.ValorPorKm_Controlado * quilometragemPercorrida);
                    else
                        total = planoCobrancaSelecionado.ValorDiario_Controlado * dias;
                    break;

            }

            int resultado = DateTime.Compare(Locacao.DataPrevistaEntrega.Date, DataDevolucao.Date);

            if (resultado == -1)
               total += total * 0.10m;

            return total;

        }

        public decimal CalcularTaxas()
        {

            decimal total = 0;
            if(Locacao.Taxas != null)
            {

                foreach (var item in Locacao.Taxas)
                {
                    total += item.Valor;
                }

            }
            
            if(Taxas != null)
            {

                foreach (var item in Taxas)
                {
                    total += item.Valor;
                }

            }
            
            return total;
        }

        public void AdicionarTaxas(Taxa taxa)
        {
            Taxas.Add(taxa);
        }

    }
}
