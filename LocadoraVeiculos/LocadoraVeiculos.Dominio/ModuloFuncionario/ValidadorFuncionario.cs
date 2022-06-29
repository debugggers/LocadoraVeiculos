using FluentValidation;
using System;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome).NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .Matches(@"^[a-zA-Záéíóúàèìòùâêîôûãõç\s]+$")
                .WithMessage("Não são permitidos caracteres especiais.");

            RuleFor(x => x.Login).NotNull().NotEmpty();

            RuleFor(x => x.Senha).NotNull().NotEmpty();

            RuleFor(x => x.Salario).NotEmpty();

            RuleFor(x => x.DataAdmissao).NotNull()
                .LessThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("'Data' deve ser igual ou menor que a data atual.");

            RuleFor(x => x.EhAdmin).NotNull();
        }
    }
}
