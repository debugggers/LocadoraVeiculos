using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente.ClienteEmpresa
{
    public class ServicoEmpresa
    {
        private RepositorioEmpresaBancoDados repositorioEmpresa;

        public ServicoEmpresa(RepositorioEmpresaBancoDados repositorioEmpresa)
        {
            this.repositorioEmpresa = repositorioEmpresa;
        }

        public ValidationResult Inserir(Empresa empresa)
        {

            ValidationResult resultadoValidacao = Validar(empresa);

            if (resultadoValidacao.IsValid)
                repositorioEmpresa.Inserir(empresa);

            return resultadoValidacao;

        }

        public ValidationResult Editar(Empresa empresa)
        {

            ValidationResult resultadoValidacao = Validar(empresa);

            if (resultadoValidacao.IsValid)
                repositorioEmpresa.Editar(empresa);

            return resultadoValidacao;

        }

        private ValidationResult Validar(Empresa empresa)
        {
            var validador = new ValidadorEmpresa();

            var resultadoValidacao = validador.Validate(empresa);

            if (EmpresaDuplicada(empresa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Empresa", "Empresa encontrada"));
            return resultadoValidacao;
        }

        private bool EmpresaDuplicada(Empresa empresa)
        {
            var empresaEncontrada = repositorioEmpresa.EmpresaJaExiste(empresa);

            return empresaEncontrada;
        }

    }
}
