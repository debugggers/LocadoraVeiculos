using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloTaxa;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {
        private IRepositorioTaxa _repositorioTaxa;
        private IContext _context;

        public ServicoTaxa(IRepositorioTaxa repositorioTaxa, IContext context)
        {
            _repositorioTaxa = repositorioTaxa;
            _context = context;
        }

        public Result<Taxa> Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir taxa... {@t}", taxa);

            var resultadoValidacao = ValidarTaxa(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Taxa {TaxaId} - {Motivo}",
                        taxa.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                _repositorioTaxa.Inserir(taxa);

                _context.GravarDados();

                Log.Logger.Information("Taxa {TaxaId} inserida com sucesso", taxa.Id);

                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                var msgErro = "Falha no sistema ao tentar inserir a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar taxa... {@t}", taxa);

            var resultadoValidacao = ValidarTaxa(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Taxa {TaxaId} - {Motivo}",
                        taxa.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                _repositorioTaxa.Editar(taxa);

                _context.GravarDados();

                Log.Logger.Information("Taxa {TaxaId} editada com sucesso", taxa.Id);

                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                var msgErro = "Falha no sistema ao tentar editar a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando excluir taxa... {@t}", taxa);

            try
            {
                _repositorioTaxa.Excluir(taxa);

                _context.GravarDados();

                Log.Logger.Information("Taxa {TaxaId} excluída com sucesso", taxa.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                var msgErro = "Falha no sistema ao tentar excluir a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Taxa>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioTaxa.SelecionarTodos());
            }
            catch (Exception ex)
            {
                var msgErro = "Falha no sistema ao tentar selecionar todas as taxas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(_repositorioTaxa.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                var msgErro = "Falha no sistema ao tentar selecionar a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarTaxa(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                Log.Logger.Warning(item.ErrorMessage);

                erros.Add(new Error(item.ErrorMessage));
            }

            if (DescricaoDuplicada(taxa))
                erros.Add(new Error("Descricao duplicada"));
            
            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        public bool DescricaoDuplicada(Taxa taxa)
        {
            var taxaEncontrada = _repositorioTaxa.SelecionarTaxaPorDescricao(taxa.Descricao);

            return taxaEncontrada != null &&
                   taxaEncontrada.Descricao == taxa.Descricao &&
                   taxaEncontrada.Id != taxa.Id;
        }
    }
}
