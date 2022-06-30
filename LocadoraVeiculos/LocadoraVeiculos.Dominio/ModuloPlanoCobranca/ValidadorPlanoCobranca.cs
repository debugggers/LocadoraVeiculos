using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>
    {
        public ValidadorPlanoCobranca()
        {
            RuleFor(x => x.TipoPlano).NotNull().NotEmpty();

            RuleFor(x => x.Valor).NotNull().NotEmpty();

            RuleFor(x => x.GrupoVeiculos).NotNull().NotEmpty();
        }
    }
}
