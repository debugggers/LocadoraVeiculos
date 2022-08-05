using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public CombustivelEnum TipoCombustivel { get; set; }
        public int CapacidadeTanque { get; set; }
        public int Ano { get; set; }
        public int QuilometragemPercorrida { get; set; }
        public byte[] Foto { get; set; }
        public List<Locacao> Locacoes { get; set; }
        public GrupoVeiculos GrupoVeiculos { get; set; }
        public Guid? GrupoVeiculosId { get; set; }
        public bool EstaDisponivel { get; set; }

        public Veiculo()
        {
            EstaDisponivel = true;
        }

        public override bool Equals(object obj)
        {
            return obj is Veiculo veiculo &&
                Id == veiculo.Id &&
                Modelo == veiculo.Modelo &&
                Placa == veiculo.Placa &&
                Marca == veiculo.Marca &&
                Cor == veiculo.Cor &&
                CapacidadeTanque == veiculo.CapacidadeTanque &&
                Ano == veiculo.Ano &&
                QuilometragemPercorrida == veiculo.QuilometragemPercorrida &&
                TipoCombustivel == veiculo.TipoCombustivel &&
                GrupoVeiculos == veiculo.GrupoVeiculos &&
                Foto == veiculo.Foto;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Modelo: {Modelo}, Placa: {Placa}, Marca: {Marca}, Cor: {Cor}, Tipo de combustivel: {TipoCombustivel}" + "\n" +
                $"Capacidade do tanque: {CapacidadeTanque}, Ano: {Ano}, Quilometragem: {QuilometragemPercorrida}";
        }

    }
}
