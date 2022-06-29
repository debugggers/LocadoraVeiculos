using FluentValidation;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {

        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("O campo nome não pode ficar vazio")
                .NotEmpty().WithMessage("O campo nome não pode ficar vazio")
                .MinimumLength(3).WithMessage("O Nome precisa ter mais do que três caracteres")
                .Matches(@"^[a-zA-Záéíóúàèìòùâêîôûãõç\s]+$").WithMessage("Não são permitidos caracteres especiais no nome"); ;

            RuleFor(x => x.Telefone)
                .NotNull().WithMessage("O campo telefone não pode ficar vazio")
                .NotEmpty().WithMessage("O campo telefone não pode ficar vazio")
                .MinimumLength(9).WithMessage("O telefone precisa deve ter 9 digitos");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("O campo email não pode ficar vazio")
                .NotEmpty().WithMessage("O campo email não pode ficar vazio")
                .EmailAddress().WithMessage("Formato de email inválido");

            RuleFor(x => x.Endereco)
                .NotNull().WithMessage("O campo endereço não pode ficar vazio")
                .NotEmpty().WithMessage("O campo endereço não pode ficar vazio");

            RuleFor(x => x.CPF)
                .NotNull().WithMessage("O campo CPF não pode ficar vazio")
                .NotEmpty().WithMessage("O campo CPF não pode ficar vazio");

            RuleFor(x => x.CnhNome)
                .NotNull().WithMessage("O nome da CNH não pode ficar vazio")
                .NotEmpty().WithMessage("O nome da CNH não pode ficar vazio")
                .Equal(x => x.Nome).WithMessage("O nome da CNH precisa ser igual ao do cliente");

            RuleFor(x => x.CnhNumero)
                .NotNull().WithMessage("O campo telefone não pode ficar vazio")
                .NotEmpty().WithMessage("O campo telefone não pode ficar vazio");

            RuleFor(x => x.CnhVencimento)
                .NotEmpty().WithMessage("O campo de vencimento não pode ficar vazio")
                .NotNull().WithMessage("O campo de vencimento não pode ficar vazio")
                .GreaterThan(DateTime.Now.Date).WithMessage("Impossivel cadastrar com documento vencido");

        }
    }
}