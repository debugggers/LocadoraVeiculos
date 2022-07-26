using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente.ClienteEmpresa
{
    public class ServicoEmpresa
    {
        private IRepositorioEmpresa _repositorioEmpresa;
        private IContext context;

        public ServicoEmpresa(IRepositorioEmpresa repositorioEmpresa, IContext context)
        {
            _repositorioEmpresa = repositorioEmpresa;
            this.context = context;
        }

        public Result<Empresa> Inserir(Empresa empresa)
        {
            Log.Logger.Debug("Tentando inserir empresa... {@e}", empresa);

            Result resultadoValidacao = Validar(empresa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a Empresa {EmpresaId} - {Motivo}",
                       empresa.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioEmpresa.Inserir(empresa);

                context.GravarDados();

                Log.Logger.Information("Empresa {EmpresaId} inserida com sucesso", empresa.Id);

                return Result.Ok(empresa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a empresa";

                Log.Logger.Error(ex, msgErro + "{EmpresaId}", empresa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Empresa> Editar(Empresa empresa)
        {
            Log.Logger.Debug("Tentando editar empresa... {@e}", empresa);

            Result resultadoValidacao = Validar(empresa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar a Empresa {EmpresaId} - {Motivo}",
                       empresa.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioEmpresa.Editar(empresa);

                context.GravarDados();

                Log.Logger.Information("Empresa {EmpresaId} editada com sucesso", empresa.Id);

                return Result.Ok(empresa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a empresa";

                Log.Logger.Error(ex, msgErro + "{EmpresaId}", empresa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Empresa empresa)
        {
            Log.Logger.Debug("Tentando excluir empresa... {@e}", empresa);

            try
            {
                _repositorioEmpresa.Excluir(empresa);

                context.GravarDados();

                Log.Logger.Information("Empresa {EmpresaId} excluída com sucesso", empresa.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a empresa";

                Log.Logger.Error(ex, msgErro + "{EmpresaId}", empresa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Empresa> SelecionarPorId(Guid id)
        {

            try
            {

                return Result.Ok(_repositorioEmpresa.SelecionarPorId(id));

            }
            catch (Exception ex)
            {

                string msgErro = "Falha no sistema ao tentar selecionar a empresa";

                Log.Logger.Error(ex, msgErro + "{EmpresaId}", id);

                return Result.Fail(msgErro);

            }
        }

        public Result<List<Empresa>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioEmpresa.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as empresas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(Empresa empresa)
        {
            var validador = new ValidadorEmpresa();

            var resultadoValidacao = validador.Validate(empresa);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (EmpresaDuplicada(empresa))
                erros.Add(new Error("Empresa duplicada"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool EmpresaDuplicada(Empresa empresa)
        {
            var empresaEncontrada = _repositorioEmpresa.EmpresaJaExiste(empresa);

            return empresaEncontrada;
        }
    }
}
