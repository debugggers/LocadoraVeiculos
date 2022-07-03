using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using System.Drawing;

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
        public Bitmap Foto { get; set; }
        public GrupoVeiculos GrupoVeiculo { get; set; }

        public Veiculo()
        {

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
                GrupoVeiculo == veiculo.GrupoVeiculo;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Modelo: {Modelo}, Placa: {Placa}, Marca: {Marca}, Cor: {Cor}, Tipo de combustivel: {TipoCombustivel}" + "\n" +
                $"Capacidade do tanque: {CapacidadeTanque}, Ano: {Ano}, Quilometragem: {QuilometragemPercorrida}";
        }

    }
}
