using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;

namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        public PlanoCobranca()
        {
        }

        public PlanoCobranca(GrupoVeiculos grupoVeiculos, int idGrupoVeiculos, 
            decimal valorDiarioDiario, decimal valorPorKmDiario, decimal valorDiarioLivre, 
            decimal valorDiarioControlado, decimal valorPorKmControlado, int controleKm)
        {
            GrupoVeiculos = grupoVeiculos;
            IdGrupoVeiculos = idGrupoVeiculos;
            ValorDiario_Diario = valorDiarioDiario;
            ValorPorKm_Diario = valorPorKmDiario;
            ValorDiario_Livre = valorDiarioLivre;
            ValorDiario_Controlado = valorDiarioControlado;
            ValorPorKm_Controlado = valorPorKmControlado;
            ControleKm = controleKm;
        }

        public GrupoVeiculos GrupoVeiculos { get; set; }
        public int IdGrupoVeiculos { get; set; }
        
        public decimal ValorDiario_Diario { get; set; }
        public decimal ValorPorKm_Diario { get; set; }
        public decimal ValorDiario_Livre { get; set; }
        public decimal ValorDiario_Controlado { get; set; }
        public decimal ValorPorKm_Controlado { get; set; }
        public int ControleKm { get; set; }

        public override bool Equals(object obj)
        {
            PlanoCobranca planoCobranca = obj as PlanoCobranca;

            if (planoCobranca == null)
                return false;

            return
                planoCobranca.Id.Equals(Id) &&
                planoCobranca.ValorDiario_Diario.Equals(ValorDiario_Diario) &&
                planoCobranca.ValorPorKm_Diario.Equals(ValorPorKm_Diario) &&
                planoCobranca.ValorDiario_Livre.Equals(ValorDiario_Livre) &&
                planoCobranca.ValorDiario_Controlado.Equals(ValorDiario_Controlado) &&
                planoCobranca.ValorPorKm_Controlado.Equals(ValorPorKm_Controlado) &&
                planoCobranca.ControleKm.Equals(ControleKm) &&
                planoCobranca.GrupoVeiculos.Equals(GrupoVeiculos);
        }
    }
}
