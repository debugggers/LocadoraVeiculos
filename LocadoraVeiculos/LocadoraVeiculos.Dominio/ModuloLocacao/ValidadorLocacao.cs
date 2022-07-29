using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            RuleFor(x => x.DataLocacao).NotEmpty();
            RuleFor(x => x.DataPrevistaEntrega).NotEmpty();
        }
    }
}
