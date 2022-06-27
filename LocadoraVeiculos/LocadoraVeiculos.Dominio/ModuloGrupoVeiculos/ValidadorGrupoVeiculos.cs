using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class ValidadorGrupoVeiculos : AbstractValidator<GrupoVeiculos>
    {
        public ValidadorGrupoVeiculos()
        {
            RuleFor(x => x.Nome).NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .Matches(@"^[a-zA-Z\s]+$")
                .WithMessage("Não são permitidos caracteres especiais.");
        }
    }
}
