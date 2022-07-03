using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {

        private RepositorioVeiculoEmBancoDados repositorioVeiculo;

        public ServicoVeiculo(RepositorioVeiculoEmBancoDados repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo veiculo)
        {

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Inserir(veiculo);

            return resultadoValidacao;

        }

        public ValidationResult Editar(Veiculo veiculo)
        {

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Editar(veiculo);

            return resultadoValidacao;

        }

        private ValidationResult Validar(Veiculo veiculo)
        {
            var validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            if (VeiculoDuplicado(veiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Veiculo", "placa do Veiculo duplicada"));
            return resultadoValidacao;
        }

        private bool VeiculoDuplicado(Veiculo veiculo)
        {
            var veiculoEncontrado = repositorioVeiculo.VeiculoJaExiste(veiculo);

            return veiculoEncontrado;
        }

    }
}
