using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloDevolucao;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloDevolucao
{
    public class ServicoDevolucao
    {

        private IRepositorioDevolucao repositorioDevolucao;
        private IGeradorPdfDevolucao geradorPdfDevolucao;
        private IContext context;

        public ServicoDevolucao(IRepositorioDevolucao repositorioDevolucao, IContext context, IGeradorPdfDevolucao geradorPdfDevolucao)
        {
            this.repositorioDevolucao = repositorioDevolucao;
            this.context = context;
            this.geradorPdfDevolucao = geradorPdfDevolucao;

        }

        public Result<Devolucao> Inserir(Devolucao devolucao)
        {
            Log.Logger.Debug("Tentando inserir devolução... {@d}", devolucao);

            Result resultadoValidacao = Validar(devolucao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a devolução {DevoluçãoId} - {Motivo}",
                       devolucao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioDevolucao.Inserir(devolucao);

                context.GravarDados();

                geradorPdfDevolucao.GerarPdf(devolucao);

                Log.Logger.Information("Devolução {DevoluçãoId} inserida com sucesso", devolucao.Id);

                return Result.Ok(devolucao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a devolução";

                Log.Logger.Error(ex, msgErro + "{DevoluçãoId}", devolucao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Devolucao> Editar(Devolucao devolucao)
        {
            Log.Logger.Debug("Tentando editar devolução... {@d}", devolucao);

            Result resultadoValidacao = Validar(devolucao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar a Devolução {DevoluçãoId} - {Motivo}",
                       devolucao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioDevolucao.Editar(devolucao);

                context.GravarDados();

                geradorPdfDevolucao.GerarPdf(devolucao);

                Log.Logger.Information("Devolução {DevoluçãoId} editada com sucesso", devolucao.Id);

                return Result.Ok(devolucao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a edvolução";

                Log.Logger.Error(ex, msgErro + "{DevoluçãoId}", devolucao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Devolucao devolucao)
        {
            Log.Logger.Debug("Tentando excluir devolução... {@d}", devolucao);

            try
            {
                repositorioDevolucao.Excluir(devolucao);

                context.GravarDados();

                Log.Logger.Information("Devolução {DevoluçãoId} excluída com sucesso", devolucao.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a devolução";

                Log.Logger.Error(ex, msgErro + "{DevoluçãoId}", devolucao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Devolucao> SelecionarPorId(Guid id)
        {

            try
            {

                return Result.Ok(repositorioDevolucao.SelecionarPorId(id));

            }
            catch (Exception ex)
            {

                string msgErro = "Falha no sistema ao tentar selecionar a devolução";

                Log.Logger.Error(ex, msgErro + "{DevoluçãoId}", id);

                return Result.Fail(msgErro);

            }
        }

        public Result<List<Devolucao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioDevolucao.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as devoluções";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(Devolucao devolucao)
        {
            var validador = new ValidadorDevolucao();

            var resultadoValidacao = validador.Validate(devolucao);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (DevolucaoDuplicada(devolucao))
                erros.Add(new Error("devolução duplicada"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool DevolucaoDuplicada(Devolucao devolucao)
        {
            var devolucaoEncontrada = repositorioDevolucao.DevulacaoJaExiste(devolucao);

            return devolucaoEncontrada;
        }

    }
}
