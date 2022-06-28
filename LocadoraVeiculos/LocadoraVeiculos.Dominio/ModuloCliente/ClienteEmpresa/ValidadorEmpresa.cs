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

        string t = @"";

        public ValidadorEmpresa()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("O campo nome não pode ficar vazio")
                .NotEmpty().WithMessage("O campo nome não pode ficar vazio")
                .MinimumLength(3).WithMessage("O Nome precia ter ao menos três caracteres")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Não são permitidos caracteres especiais no nome");

            RuleFor(x => x.Telefone)
                .NotNull().WithMessage("O campo telefone não pode ficar vazio")
                .NotEmpty().WithMessage("O campo telefone não pode ficar vazio")
                .MinimumLength(9).WithMessage("O telefone precisa ter pelo menos 9 digitos")
                .Matches(@"^(?:\+55)?\s?\(?0?[1-9][1-9]\)?\s?(?:9)?\s?\d{4}\-?\d{4}$").WithMessage("Formato de telefone inválido");

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
                .Matches(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})").WithMessage("Formato de cnpj inválido");

            RuleFor(x => x.Condutor)
                .NotNull().WithMessage("O campo condutor não pode ficar vazio")
                .NotEmpty().WithMessage("O campo condutor não pode ficar vazio");
        }
    }
}
