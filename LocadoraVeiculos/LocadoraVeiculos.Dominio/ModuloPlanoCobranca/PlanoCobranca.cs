using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;

namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        public PlanoCobranca()
        {
        }

        public PlanoCobranca(decimal valor, GrupoVeiculos grupoVeiculos, int idGrupoVeiculos, TipoPlanoEnum tipoPlano)
        {
            Valor = valor;
            GrupoVeiculos = grupoVeiculos;
            IdGrupoVeiculos = idGrupoVeiculos;
            TipoPlano = tipoPlano;
        }

        public TipoPlanoEnum TipoPlano { get; set; }

        public decimal Valor { get; set; }

        public GrupoVeiculos GrupoVeiculos { get; set; }

        public int IdGrupoVeiculos { get; set; }

        public override bool Equals(object obj)
        {
            PlanoCobranca planoCobranca = obj as PlanoCobranca;

            if (planoCobranca == null)
                return false;

            return
                planoCobranca.Id.Equals(Id) &&
                planoCobranca.TipoPlano.Equals(TipoPlano) &&
                planoCobranca.Valor.Equals(Valor) &&
                planoCobranca.GrupoVeiculos.Equals(GrupoVeiculos);
        }
    }
}
