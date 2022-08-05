using FluentValidation;
using LocadoraVeiculos.Dominio.ModuloLocacao;
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

            RuleFor(x => x.Locacao)
                .Must(ValidarQuilometragem);

            RuleFor(x => x.QuilometragemVeiculo)
                .NotNull().WithMessage("O campo quilometragem não pode ficar vazio")
                .NotEmpty().WithMessage("O campo quilometragem não pode ficar vazio");

            RuleFor(x => x.Locacao)
                .Must(ValidarData);

            RuleFor(x => x.DataDevolucao)
                .NotNull().WithMessage("O campo data de devolução não pode ficar vazio")
                .NotEmpty().WithMessage("O campo data de devolução não pode ficar vazio");
        }

        private bool ValidarData(Devolucao arg1, Locacao arg, ValidationContext<Devolucao> contexto)
        {
            if (arg1 == null || arg == null)
                return false;

            if (arg1.DataDevolucao > arg.DataLocacao)
            {
                contexto.AddFailure(new FluentValidation.Results.ValidationFailure("Data Devolução", "O campo" +
                    "data devolução deve ocorrer após a data de locação."));

                return true;
            }

            return false;
        }

        private bool ValidarQuilometragem(Devolucao arg1,Locacao arg, ValidationContext<Devolucao> contexto)
        {
            if (arg1 == null || arg == null)
                return false;

            if (arg1.QuilometragemVeiculo > arg.Veiculo.QuilometragemPercorrida)
            {
                contexto.AddFailure(new FluentValidation.Results.ValidationFailure("Quilometragem Veiculo", "O campo" +
                    "quilometragem percorrida deve ser maior que a quilometragem anterior do veículo"));

                return true;
            }

            return false;
        }
    }
}
