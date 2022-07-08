using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using Serilog;

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
            Log.Logger.Debug("Tentando inserir funcionário... {@f}", funcionario);

            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                _repositorioFuncionario.Inserir(funcionario);
                Log.Logger.Debug("Funcionário {FuncionarioNome} inserido com sucesso", funcionario.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Funcionário {FuncionarioNome} - {Motivo}",
                        funcionario.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Funcionario funcionario)
        {
            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                _repositorioFuncionario.Editar(funcionario);

            return resultadoValidacao;
        }

        public ValidationResult Validar(Funcionario funcionario)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            if (NomeDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            if (LoginDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "Login duplicado"));

            return resultadoValidacao;
        }

        public bool NomeDuplicado(Funcionario funcionario)
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
