using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty();

            RuleFor(x => x.Login).NotNull().NotEmpty();

            RuleFor(x => x.Senha).NotNull().NotEmpty();

            RuleFor(x => x.Salario).NotNull();

            RuleFor(x => x.DataAdmissao).NotNull();

            RuleFor(x => x.EhAdmin).NotNull();
        }
    }
}
