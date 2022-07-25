using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloTaxa
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            RuleFor(x => x.Descricao).NotNull()
                .NotEmpty()
                .MinimumLength(3).WithMessage("'Descricao' deve ter no mínimo 3 caracteres.")
                .Matches(@"^[a-zA-Záéíóúàèìòùâêîôûãõç\s]+$")
                .WithMessage("Não são permitidos caracteres especiais.");

            RuleFor(x => x.Valor).NotEmpty();

        }
    }
}
