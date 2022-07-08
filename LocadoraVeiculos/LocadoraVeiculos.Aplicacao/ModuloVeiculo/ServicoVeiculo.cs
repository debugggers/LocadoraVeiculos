using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Serilog;

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

            Log.Logger.Debug("Tentando inserir veículo... {@v}", veiculo);

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid){

                repositorioVeiculo.Inserir(veiculo);
                Log.Logger.Debug("Veículo {VeiculoModelo} inserido com sucesso", veiculo.Modelo);

            }
            else
            {

                foreach (var item in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao inserir o veículo {VeiculoModelo} - {Motivo}", veiculo.Modelo, item.ErrorMessage);

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

                repositorioVeiculo.Editar(veiculo);
                Log.Logger.Debug("Veículo {VeiculoModelo} editado com sucesso", veiculo.Modelo);

            }
            else
            {

                foreach (var item in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao editar o veículo {VeiculoModelo} - {Motivo}", veiculo.Modelo, item.ErrorMessage);

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
            var veiculoEncontrado = repositorioVeiculo.VeiculoJaExiste(veiculo);

            return veiculoEncontrado;
        }

    }
}
