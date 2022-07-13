using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {

        private RepositorioVeiculoEmBancoDados _repositorioVeiculo;

        public ServicoVeiculo(RepositorioVeiculoEmBancoDados repositorioVeiculo)
        {
            _repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir veículo... {@v}", veiculo);

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                _repositorioVeiculo.Inserir(veiculo);
                Log.Logger.Debug("Veículo {VeiculoId} inserido com sucesso", veiculo.Id);
            }
            else
            {
                foreach (var item in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao inserir o veículo {VeiculoId} - {Motivo}", 
                        veiculo.Id, item.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar veículo... {@v}", veiculo);

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                _repositorioVeiculo.Editar(veiculo);
                Log.Logger.Debug("Veículo {VeiculoId} editado com sucesso", veiculo.Id);
            }
            else
            {
                foreach (var item in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao editar o veículo {VeiculoId} - {Motivo}", 
                        veiculo.Id, item.ErrorMessage);
                }
            }

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
            var veiculoEncontrado = _repositorioVeiculo.VeiculoJaExiste(veiculo);

            return veiculoEncontrado;
        }
    }
}
