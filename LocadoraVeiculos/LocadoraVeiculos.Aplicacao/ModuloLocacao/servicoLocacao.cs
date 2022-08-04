using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloLocacao
{
    public class ServicoLocacao
    {

        private IRepositorioLocacao _repositorioLocacao;
        private IContext _context;
        private IGeradorPdfLocacao _geradorPdfLocacao;

        public ServicoLocacao(IRepositorioLocacao repositorioLocacao, IContext context, IGeradorPdfLocacao geradorPdfLocacao)
        {
            _repositorioLocacao = repositorioLocacao;
            _context = context;
            _geradorPdfLocacao = geradorPdfLocacao;
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
                _repositorioLocacao.Inserir(locacao);

                _context.GravarDados();

                _geradorPdfLocacao.GerarPdf(locacao);

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
                _repositorioLocacao.Editar(locacao);

                _context.GravarDados();

                _geradorPdfLocacao.GerarPdf(locacao);

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
                _repositorioLocacao.Excluir(locacao);

                _context.GravarDados();

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
                return Result.Ok(_repositorioLocacao.SelecionarPorId(id));
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
                return Result.Ok(_repositorioLocacao.SelecionarTodos());
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

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        public decimal CalcularValorPrevisto(DateTime dataLocacao, DateTime dataPrevistaDevolucao,
            PlanoCobranca planoCobranca, PlanoCobrancaEnum planoCobrancaEnum, List<Taxa> taxas)
        {
            decimal valorPrevisto = 0;
            var totalDias = (dataPrevistaDevolucao - dataLocacao).Days + 1;

            if (planoCobrancaEnum == PlanoCobrancaEnum.Diario)
                valorPrevisto = totalDias * planoCobranca.ValorDiario_Diario;
            else if (planoCobrancaEnum == PlanoCobrancaEnum.Livre)
                valorPrevisto = totalDias * planoCobranca.ValorDiario_Livre;
            else
                valorPrevisto = totalDias * planoCobranca.ValorDiario_Controlado;

            foreach (var taxa in taxas)
            {
                if (taxa.TipoCalculo == TipoCalculoEnum.CalculoFixo)
                    valorPrevisto += taxa.Valor;
                else
                    valorPrevisto += totalDias * taxa.Valor;
            }

            return valorPrevisto;
        }
    }
}
