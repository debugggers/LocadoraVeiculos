using FluentValidation;
using System;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome).NotNull()
                .NotEmpty();

            RuleFor(x => x.Nome).MinimumLength(3).WithMessage("'Nome' deve ter no mínimo 3 caracteres.");

            RuleFor(x => x.Nome).Matches(@"^[a-zA-Záéíóúàèìòùâêîôûãõç\s]+$")
                .WithMessage("Não são permitidos caracteres especiais.");

            RuleFor(x => x.Login).NotNull().NotEmpty();

            RuleFor(x => x.Senha).NotNull().NotEmpty();

            RuleFor(x => x.Senha).MinimumLength(5)
                .WithMessage("'Senha' deve ter no mínimo 5 caracteres.");

            RuleFor(x => x.Salario).NotEmpty();

            RuleFor(x => x.DataAdmissao).NotEmpty()
                .LessThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("'Data Admissao' deve ser igual ou menor que a data atual.");

            RuleFor(x => x.EhAdmin).NotNull();
        }
    }
}
