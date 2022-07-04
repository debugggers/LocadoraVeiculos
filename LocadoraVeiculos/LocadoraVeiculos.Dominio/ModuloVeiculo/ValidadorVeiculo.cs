using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {

        public ValidadorVeiculo()
        {

            RuleFor(x => x.Modelo)
                .NotNull().WithMessage("O campo modelo não pode ficar vazio")
                .NotEmpty().WithMessage("O campo modelo não pode ficar vazio")
                .MinimumLength(3).WithMessage("O modelo precisa ter pelo menos três caracteres");

            RuleFor(x => x.Marca)
                .NotNull().WithMessage("O campo marca não pode ficar vazio")
                .NotEmpty().WithMessage("O campo marca não pode ficar vazio")
                .MinimumLength(3).WithMessage("A marca precisa ter pelo menos três caracteres");

            RuleFor(x => x.Placa)
                .NotNull().WithMessage("O campo placa não pode ficar vazio")
                .NotEmpty().WithMessage("O campo placa não pode ficar vazio")
                .Matches(@"[a-zA-Z0-9]").WithMessage("Não são permitidos caracteres especiais na placa")
                .MinimumLength(6).WithMessage("A placa precisa ter pelo menos 6 caracteres");

            RuleFor(x => x.Cor)
                .NotNull().WithMessage("O campo cor não pode ficar vazio")
                .NotEmpty().WithMessage("O campo cor não pode ficar vazio")
                .Matches(@"^[a-zA-Záéíóúàèìòùâêîôûãõç\s]+$").WithMessage("O campo cor não pode ter caracteres especiais");


            RuleFor(x => x.Ano)
                .NotNull().WithMessage("O campo ano não pode ficar vazio")
                .NotEmpty().WithMessage("O campo ano não pode ficar vazio");

            RuleFor(x => x.QuilometragemPercorrida)
                .NotEmpty().WithMessage("O campo quilometragem não pode ficar vazio")
                .GreaterThan(-1).WithMessage("A quilometragem percorrida não pode ser vazia");

            RuleFor(x => x.CapacidadeTanque)
                .NotNull().WithMessage("O campo capacidade do tanque não pode ficar vazio")
                .NotEmpty().WithMessage("O campo capacidade do tanque não pode ficar vazio");

            RuleFor(x => x.Foto)
                .NotNull().WithMessage("O campo foto não pode ficar vazio")
                .NotEmpty().WithMessage("O campo foto não pode ficar vazio");

            RuleFor(x => x.GrupoVeiculo)
                .NotNull().WithMessage("O campo grupo de veiculos não pode ficar vazio")
                .NotEmpty().WithMessage("O campo grupo de veiculos não pode ficar vazio");

        }
    }
}
