using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloDevolucao
{
    public class ValidadorDevolucao : AbstractValidator<Devolucao>
    {

        public ValidadorDevolucao()
        {
            RuleFor(x => x.Locacao)
                .NotNull().WithMessage("O campo locação não pode ficar vazio")
                .NotEmpty().WithMessage("O campo locação não pode ficar vazio");

            RuleFor(x => x.QuilometragemVeiculo)
                .NotNull().WithMessage("O campo quilometragem não pode ficar vazio")
                .NotEmpty().WithMessage("O campo quilometragem não pode ficar vazio")
                .GreaterThan(x => x.Locacao.Veiculo.QuilometragemPercorrida).WithMessage("A quilometragem atual deve ser maior do que a anterior a locação");

            RuleFor(x => x.DataDevolucao)
                .NotNull().WithMessage("O campo data de devolução não pode ficar vazio")
                .NotEmpty().WithMessage("O campo data de devolução não pode ficar vazio")
                .GreaterThan(x => x.Locacao.DataLocacao).WithMessage("A data de entrega não pode ser anterior a locação");

            RuleFor(x => x.NivelDoTanque)
                .NotNull().WithMessage("O campo nivel do tanque não pode ficar vazio")
                .NotEmpty().WithMessage("O campo nivel do tanque não pode ficar vazio");

        }
    }
}
