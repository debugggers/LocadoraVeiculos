using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloLocacao
{
    public class servicoLocacao
    {

        private IRepositorioLocacao repositorioLocacao;
        private IContext context;

        public servicoLocacao(IRepositorioLocacao repositorioLocacao, IContext context)
        {
            this.repositorioLocacao = repositorioLocacao;
            this.context = context;
        }

        public Result<Locacao> Inserir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando inserir locação... {@l}", locacao);

            Result resultadoValidacao = Validar(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a Locação {LocaçãoId} - {Motivo}",
                       locacao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Inserir(locacao);

                context.GravarDados();

                Log.Logger.Information("Locação {LocaçãoId} inserida com sucesso", locacao.Id);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a locação";

                Log.Logger.Error(ex, msgErro + "{LocaçãoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> Editar(Locacao locacao)
        {
            Log.Logger.Debug("Tentando editar locação... {@l}", locacao);

            Result resultadoValidacao = Validar(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar a Locação {LocaçãoId} - {Motivo}",
                       locacao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Editar(locacao);

                context.GravarDados();

                Log.Logger.Information("Locação {LocaçãoId} editada com sucesso", locacao.Id);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a locação";

                Log.Logger.Error(ex, msgErro + "{LocaçãoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando excluir locação... {@l}", locacao);

            try
            {
                repositorioLocacao.Excluir(locacao);

                context.GravarDados();

                Log.Logger.Information("Locação {LocaçãoId} excluída com sucesso", locacao.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a locação";

                Log.Logger.Error(ex, msgErro + "{LocaçãoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> SelecionarPorId(Guid id)
        {

            try
            {

                return Result.Ok(repositorioLocacao.SelecionarPorId(id));

            }
            catch (Exception ex)
            {

                string msgErro = "Falha no sistema ao tentar selecionar a locação";

                Log.Logger.Error(ex, msgErro + "{LocaçãoId}", id);

                return Result.Fail(msgErro);

            }
        }

        public Result<List<Locacao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as locações";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(Locacao locacao)
        {
            var validador = new ValidadorLocacao();

            var resultadoValidacao = validador.Validate(locacao);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            //if (LocacaoDuplicada(locacao))
             //   erros.Add(new Error("Cliente duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        //private bool LocacaoDuplicada(Locacao locacao)
        //{
            //var clienteEncontrado = _repositorioCliente.ClienteJaExiste(cliente);

            //return clienteEncontrado;
        //}

    }
}
