using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraVeiculos.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private RepositorioFuncionarioEmBancoDados _repositorioFuncionario;

        public ServicoFuncionario(RepositorioFuncionarioEmBancoDados repositorioFuncionario)
        {
            _repositorioFuncionario = repositorioFuncionario;
        }

        public ValidationResult Inserir(Funcionario funcionario)
        {
            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                _repositorioFuncionario.Inserir(funcionario);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Funcionario funcionario)
        {
            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                _repositorioFuncionario.Editar(funcionario);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Funcionario funcionario)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            if (NomeDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            if (LoginDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "Login duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = _repositorioFuncionario.SelecionarFuncionarioPorNome(funcionario.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == funcionario.Nome &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }

        public bool LoginDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado =
                _repositorioFuncionario.SelecionarFuncionarioPorLogin(funcionario.Login);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login == funcionario.Login &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }
    }
}
