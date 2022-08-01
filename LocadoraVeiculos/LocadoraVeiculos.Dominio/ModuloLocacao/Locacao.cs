using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public Locacao() { }

        public Locacao(Funcionario funcionario, Guid? funcionarioId, Cliente cliente, Guid clienteId, 
            GrupoVeiculos grupoVeiculos, Guid grupoVeiculosId, List<Taxa> taxas, PlanoCobrancaEnum planosCobranca, 
            Veiculo veiculo, Guid veiculoId, DateTime dataLocacao, DateTime dataPrevistaEntrega, decimal valorPrevisto)
        {
            Funcionario = funcionario;
            FuncionarioId = funcionarioId;
            Cliente = cliente;
            ClienteId = clienteId;
            GrupoVeiculos = grupoVeiculos;
            GrupoVeiculosId = grupoVeiculosId;
            Taxas = taxas;
            PlanosCobranca = planosCobranca;
            Veiculo = veiculo;
            VeiculoId = veiculoId;
            DataLocacao = dataLocacao;
            DataPrevistaEntrega = dataPrevistaEntrega;
            ValorPrevisto = valorPrevisto;
        }

        public Funcionario Funcionario { get; set; }
        public Guid? FuncionarioId { get; set; }

        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }

        public GrupoVeiculos GrupoVeiculos { get; set; }
        public Guid GrupoVeiculosId { get; set; }

        public List<Taxa> Taxas { get; set; }

        public PlanoCobrancaEnum PlanosCobranca { get; set; }

        public Veiculo Veiculo { get; set; }
        public Guid VeiculoId { get; set; }

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
                locacao.FuncionarioId.Equals(FuncionarioId) &&
                locacao.Cliente.Equals(Cliente) &&
                locacao.ClienteId.Equals(ClienteId) &&
                locacao.GrupoVeiculos.Equals(GrupoVeiculos) &&
                locacao.GrupoVeiculosId.Equals(GrupoVeiculosId) &&
                locacao.PlanosCobranca.Equals(PlanosCobranca) &&
                locacao.Taxas.Equals(Taxas) &&
                locacao.Veiculo.Equals(Veiculo) &&
                locacao.VeiculoId.Equals(VeiculoId) &&
                locacao.DataLocacao.Equals(DataLocacao) &&
                locacao.DataPrevistaEntrega.Equals(DataPrevistaEntrega) &&
                locacao.ValorPrevisto.Equals(ValorPrevisto);
        }
    }
}
