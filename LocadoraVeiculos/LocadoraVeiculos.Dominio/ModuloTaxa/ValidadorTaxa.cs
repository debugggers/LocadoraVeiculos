using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloTaxa
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            RuleFor(x => x.Descricao).NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .Matches(@"^[a-zA-Záéíóúàèìòùâêîôûãõç\s]+$")
                .WithMessage("Não são permitidos caracteres especiais.");

            RuleFor(x => x.Valor).NotEmpty();

            RuleFor(x => x.TipoCalculo).NotNull();
        }
    }
}
