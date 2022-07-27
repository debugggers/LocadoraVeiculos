using FluentValidation;
using System;

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
                .GreaterThan(0).WithMessage("A quilometragem deve ser maior do que 0");

            RuleFor(x => x.DataDevolucao)
                .NotNull().WithMessage("O campo data de devolução não pode ficar vazio")
                .NotEmpty().WithMessage("O campo data de devolução não pode ficar vazio");

            RuleFor(x => x.NivelDoTanque)
                .NotNull().WithMessage("O campo nivel do tanque não pode ficar vazio")
                .NotEmpty().WithMessage("O campo nivel do tanque não pode ficar vazio");

        }
    }
}
