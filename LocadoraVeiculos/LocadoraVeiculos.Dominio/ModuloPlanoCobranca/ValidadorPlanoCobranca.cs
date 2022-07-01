using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>
    {
        public ValidadorPlanoCobranca()
        {
            RuleFor(x => x.ValorDiario_Diario).NotEmpty();
            RuleFor(x => x.ValorPorKm_Diario).NotEmpty();
            RuleFor(x => x.ValorDiario_Livre).NotEmpty();
            RuleFor(x => x.ValorDiario_Controlado).NotEmpty();
            RuleFor(x => x.ValorPorKm_Controlado).NotEmpty();
            RuleFor(x => x.ControleKm).NotEmpty();
        }
    }
}
