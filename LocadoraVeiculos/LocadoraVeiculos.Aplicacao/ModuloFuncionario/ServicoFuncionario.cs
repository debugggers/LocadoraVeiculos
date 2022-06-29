using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {

        private RepositorioFuncionarioEmBancoDados repositorioFuncionario;

        public ServicoFuncionario(RepositorioFuncionarioEmBancoDados repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        //public ValidationResult Inserir(Funcionario funcionario)
        //{
        //    ValidationResult resultadoValidacao = Validar(funcionario);

        //    if (resultadoValidacao.IsValid)
        //        repositorioFuncionario.Inserir(funcionario);

        //    return resultadoValidacao;
        //}

        //public ValidationResult Editar(Funcionario funcionario)
        //{
        //    ValidationResult resultadoValidacao = Validar(funcionario);

        //    if (resultadoValidacao.IsValid)
        //        repositorioFuncionario.Editar(funcionario);

        //    return resultadoValidacao;
        //}

        //private ValidationResult Validar(Funcionario funcionario)
        //{
        //    var validador = new ValidadorFuncionario();

        //    var resultadoValidacao = validador.Validate(funcionario);

        //    if (NomeDuplicado(funcionario))
        //        resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

        //    if (UsuarioDuplicado(funcionario))
        //        resultadoValidacao.Errors.Add(new ValidationFailure("Login", "Login duplicado"));

        //    return resultadoValidacao;
        }

        //private bool NomeDuplicado(Funcionario funcionario)
        //{
        //    var funcionarioEncontrado = repositorioFuncionario.FuncionarioJaExiste(funcionario.Nome, funcionario.Id);

        //    return funcionarioEncontrado != null &&
        //           funcionarioEncontrado.Nome == funcionario.Nome &&
        //           funcionarioEncontrado.Id != funcionario.Id;
        //}

        //private bool UsuarioDuplicado(Funcionario funcionario)
        //{
        //    var funcionarioEncontrado = repositorioFuncionario.FuncionarioJaExiste(funcionario., funcionario.Id);

        //    return funcionarioEncontrado != null &&
        //           funcionarioEncontrado.Usuario == funcionario.Usuario &&
        //           funcionarioEncontrado.Id != funcionario.Id;
        //}
}
