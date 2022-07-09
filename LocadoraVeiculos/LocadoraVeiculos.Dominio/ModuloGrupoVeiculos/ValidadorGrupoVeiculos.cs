using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class ValidadorGrupoVeiculos : AbstractValidator<GrupoVeiculos>
    {
        public ValidadorGrupoVeiculos()
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("O campo nome não pode ficar vazio")
                .NotEmpty().WithMessage("O campo nome não pode ficar vazio")
                .MinimumLength(3).WithMessage("O campo nome precisa ter pelo menos três caracteres")
                .Matches(@"^[a-zA-ZáéíóúàèìòùâêîôûãõçÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÃÕÇ\s]+$")
                .WithMessage("Não são permitidos caracteres especiais.");
        }
    }
}
