using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa
{
    public class ValidadorEmpresa : AbstractValidator<Empresa>
    {

        public ValidadorEmpresa()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("O campo nome não pode ficar vazio")
                .NotEmpty().WithMessage("O campo nome não pode ficar vazio")
                .MinimumLength(3).WithMessage("O Nome precia ter ao menos três caracteres")
                .Matches(@"^[a-zA-Záéíóúàèìòùâêîôûãõç\s]+$").WithMessage("Não são permitidos caracteres especiais no nome");

            RuleFor(x => x.Telefone)
                .NotNull().WithMessage("O campo telefone não pode ficar vazio")
                .NotEmpty().WithMessage("O campo telefone não pode ficar vazio")
                .MinimumLength(9).WithMessage("O telefone precisa ter pelo menos 9 digitos");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("O campo email não pode ficar vazio")
                .NotEmpty().WithMessage("O campo email não pode ficar vazio")
                .EmailAddress().WithMessage("Formato de email inválido");

            RuleFor(x => x.Endereco)
                .NotNull().WithMessage("O campo endereço não pode ficar vazio")
                .NotEmpty().WithMessage("O campo endereço não pode ficar vazio");

            RuleFor(x => x.CNPJ)
                .NotNull().WithMessage("O campo CNPJ não pode ficar vazio")
                .NotEmpty().WithMessage("O campo CNPJ não pode ficar vazio")
                .MinimumLength(14).WithMessage("O campo CNPJ não pode ficar vazio ou incompleto");

        }
    }
}
