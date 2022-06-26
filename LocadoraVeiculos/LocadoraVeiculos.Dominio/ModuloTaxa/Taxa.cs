using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public Taxa()
        {
        }

        public Taxa(string descricao, decimal valor, TipoCalculoEnum tipoCalculo)
        {
            Descricao = descricao;
            Valor = valor;
            TipoCalculo = tipoCalculo;
        }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public TipoCalculoEnum TipoCalculo { get; set; }

        public override bool Equals(object obj)
        {
            Taxa taxa = obj as Taxa;

            if (taxa == null)
                return false;

            return
                taxa.Id.Equals(Id) &&
                taxa.Descricao.Equals(Descricao) &&
                taxa.Valor.Equals(Valor) &&
                taxa.TipoCalculo.Equals(TipoCalculo);
        }
    }
}
