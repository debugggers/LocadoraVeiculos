using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public Locacao()
        {
        }

        public Locacao(Funcionario funcionario, Cliente cliente, List<GrupoVeiculos> grupoVeiculos, 
            List<Taxa> taxas, List<PlanoCobranca> planosCobranca, Veiculo veiculo, int kmVeiculo, 
            DateTime dataLocacao, DateTime dataPrevistaEntrega, decimal valorPrevisto)
        {
            Funcionario = funcionario;
            Cliente = cliente;
            GrupoVeiculos = grupoVeiculos;
            Taxas = taxas;
            PlanosCobranca = planosCobranca;
            Veiculo = veiculo;
            KmVeiculo = kmVeiculo;
            DataLocacao = dataLocacao;
            DataPrevistaEntrega = dataPrevistaEntrega;
            ValorPrevisto = valorPrevisto;
        }

        public Funcionario Funcionario { get; set; }

        public Cliente Cliente { get; set; }

        public List<GrupoVeiculos> GrupoVeiculos { get; set; }

        public List<Taxa> Taxas { get; set; }

        public List<PlanoCobranca> PlanosCobranca { get; set; }

        public Veiculo Veiculo { get; set; }

        public int KmVeiculo { get; }

        public DateTime DataLocacao { get; set; }

        public DateTime DataPrevistaEntrega { get; set; }

        public decimal ValorPrevisto { get; set; }


        public override bool Equals(object obj)
        {
            Locacao locacao = obj as Locacao;

            if (locacao == null)
                return false;

            return
                locacao.Id.Equals(Id) &&
                locacao.Funcionario.Equals(Funcionario) &&
                locacao.Cliente.Equals(Cliente) &&
                locacao.GrupoVeiculos.Equals(GrupoVeiculos) &&
                locacao.PlanosCobranca.Equals(PlanosCobranca) &&
                locacao.Taxas.Equals(Taxas) &&
                locacao.Veiculo.Equals(Veiculo) &&
                locacao.KmVeiculo.Equals(KmVeiculo) &&
                locacao.DataLocacao.Equals(DataLocacao) &&
                locacao.DataPrevistaEntrega.Equals(DataPrevistaEntrega) &&
                locacao.ValorPrevisto.Equals(ValorPrevisto);
        }
    }
}
