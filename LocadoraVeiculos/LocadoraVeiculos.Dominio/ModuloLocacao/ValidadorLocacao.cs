using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            RuleFor(x => x.Cliente).NotEmpty().NotNull();
            RuleFor(x => x.GrupoVeiculos).NotEmpty().NotNull();
            RuleFor(x => x.Veiculo).NotEmpty().NotNull();
            RuleFor(x => x.DataLocacao).NotEmpty();
            RuleFor(x => x.DataPrevistaEntrega).NotEmpty()
                .GreaterThanOrEqualTo(x => x.DataLocacao)
                .WithMessage("'Data Prevista Entrega' deve ser maior que 'Data Locacao'")
                .LessThanOrEqualTo(x => x.DataLocacao.AddDays(30))
                .WithMessage("'Data Prevista Entrega' deve ser menor que 30 dias");
        }
    }
}
