using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {

        private RepositorioVeiculoEmBancoDados _repositorioVeiculo;

        public ServicoVeiculo(RepositorioVeiculoEmBancoDados repositorioVeiculo)
        {
            _repositorioVeiculo = repositorioVeiculo;
        }

        public Result<Veiculo> Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir veículo... {@v}", veiculo);

            Result resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Veículo {VeículoId} - {Motivo}",
                       veiculo.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioVeiculo.Inserir(veiculo);

                Log.Logger.Information("Veículo {VeículoId} inserido com sucesso", veiculo.Id);

                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o veículo";

                Log.Logger.Error(ex, msgErro + "{VeículoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculo> Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar veículo... {@v}", veiculo);

            Result resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Veículo {VeículoId} - {Motivo}",
                       veiculo.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioVeiculo.Editar(veiculo);

                Log.Logger.Information("Veículo {VeículoId} editado com sucesso", veiculo.Id);

                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o veículo";

                Log.Logger.Error(ex, msgErro + "{VeículoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando excluir veículo... {@v}", veiculo);

            try
            {
                _repositorioVeiculo.Excluir(veiculo);

                Log.Logger.Information("Veículo {VeículoId} excluído com sucesso", veiculo.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o veículo";

                Log.Logger.Error(ex, msgErro + "{VeículoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculo> SelecionarPorId(Guid id)
        {

            try
            {

                return Result.Ok(_repositorioVeiculo.SelecionarPorId(id));

            }
            catch (Exception ex)
            {

                string msgErro = "Falha no sistema ao tentar selecionar o veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", id);

                return Result.Fail(msgErro);

            }
        }

        public Result<List<Veiculo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioVeiculo.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os veículos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(Veiculo veiculo)
        {
            var validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            List<Error> erros = new List<Error>(); 

            foreach (ValidationFailure item in resultadoValidacao.Errors)            
                erros.Add(new Error(item.ErrorMessage));

            if (VeiculoDuplicado(veiculo))
                erros.Add(new Error("Placa do Veiculo duplicada"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool VeiculoDuplicado(Veiculo veiculo)
        {
            var veiculoEncontrado = _repositorioVeiculo.VeiculoJaExiste(veiculo);

            return veiculoEncontrado;
        }
    }
}
