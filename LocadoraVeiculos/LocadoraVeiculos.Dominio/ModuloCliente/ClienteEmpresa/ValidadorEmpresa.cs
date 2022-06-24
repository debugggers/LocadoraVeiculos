﻿using FluentValidation;
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
                .NotEmpty().WithMessage("O campo nome não pode ficar vazio");

            RuleFor(x => x.Telefone)
                .NotNull().WithMessage("O campo telefone não pode ficar vazio")
                .NotEmpty().WithMessage("O campo telefone não pode ficar vazio")
                .MinimumLength(9).WithMessage("O telefone precisa ter pelo menos 9 digitos");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("O campo email não pode ficar vazio")
                .NotEmpty().WithMessage("O campo email não pode ficar vazio")
                .EmailAddress().WithMessage("Formato inválido");

            RuleFor(x => x.Endereco)
                .NotNull().WithMessage("O campo endereço não pode ficar vazio")
                .NotEmpty().WithMessage("O campo endereço não pode ficar vazio");

        }
    }
}