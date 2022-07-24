using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca
    {
        private IRepositorioPlanoCobranca _repositorioPlanoCobranca;

        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca)
        {
            _repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        public Result<PlanoCobranca> Inserir(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando inserir Plano de Cobrança... {@p}", planoCobranca);

            var resultadoValidacao = ValidarPlanoCobranca(planoCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Plano de Cobrança {PlanoCobrancaId} - {Motivo}",
                        planoCobranca.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                _repositorioPlanoCobranca.Inserir(planoCobranca);
                Log.Logger.Information("Plano de Cobrança {PlanoCobrancaId} inserido com sucesso", planoCobranca.Id);

                return Result.Ok(planoCobranca);
            }
            catch (Exception ex)
            {
                var msgErro = "Falha no sistema ao tentar inserir o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoCobrancaId}", planoCobranca.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoCobranca> Editar(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando editar Plano de Cobrança... {@p}", planoCobranca);

            var resultadoValidacao = ValidarPlanoCobranca(planoCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Plano de Cobrança {PlanoCobrancaId} - {Motivo}",
                        planoCobranca.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                _repositorioPlanoCobranca.Editar(planoCobranca);
                Log.Logger.Information("Plano de Cobrança {PlanoCobrancaId} editado com sucesso", planoCobranca.Id);

                return Result.Ok(planoCobranca);
            }
            catch (Exception ex)
            {
                var msgErro = "Falha no sistema ao tentar editar o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoCobrancaId}", planoCobranca.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando excluir plano de cobrança... {@p}", planoCobranca);

            try
            {
                _repositorioPlanoCobranca.Excluir(planoCobranca);
                Log.Logger.Information("Plano de Cobrança {PlanoCobrancaId} excluído com sucesso", planoCobranca.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                var msgErro = "Falha no sistema ao tentar excluir o plano de Cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoCobrancaId}", planoCobranca.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<PlanoCobranca>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioPlanoCobranca.SelecionarTodos());
            }
            catch (Exception ex)
            {
                var msgErro = "Falha no sistema ao tentar selecionar todos os planos de cobrança";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoCobranca> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(_repositorioPlanoCobranca.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                var msgErro = "Falha no sistema ao tentar selecionar o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoCobrancaId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarPlanoCobranca(PlanoCobranca planoCobranca)
        {
            var validador = new ValidadorPlanoCobranca();

            var resultadoValidacao = validador.Validate(planoCobranca);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                Log.Logger.Warning(item.ErrorMessage);

                erros.Add(new Error(item.ErrorMessage));
            }

            if (GrupoVeiculosDuplicado(planoCobranca))
                erros.Add(new Error("Grupo de Veiculos duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool GrupoVeiculosDuplicado(PlanoCobranca planoCobranca)
        {
            return _repositorioPlanoCobranca.GrupoVeiculosDuplicado(planoCobranca.GrupoVeiculos.Id);
        }
    }
}
