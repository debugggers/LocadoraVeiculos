using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos
    {
        private RepositorioGrupoVeiculosEmBancoDados _repositorioGrupoVeiculos;

        public ServicoGrupoVeiculos(RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos)
        {
            _repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public Result<GrupoVeiculos> Inserir(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando inserir grupo de veículos... {@g}", grupoVeiculos);

            Result resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Grupo de Veículos {GrupoId} - {Motivo}",
                       grupoVeiculos.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioGrupoVeiculos.Inserir(grupoVeiculos);

                Log.Logger.Information("Grupo de Veículos {GrupoId} inserido com sucesso", grupoVeiculos.Id);

                return Result.Ok(grupoVeiculos);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o grupo de veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoId}", grupoVeiculos.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<GrupoVeiculos> Editar(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando editar o grupo de veículos... {@g}", grupoVeiculos);

            Result resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Grupo de Veículos {GrupoId} - {Motivo}",
                       grupoVeiculos.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioGrupoVeiculos.Editar(grupoVeiculos);

                Log.Logger.Information("Grupo de Veículos {GrupoId} editado com sucesso", grupoVeiculos.Id);

                return Result.Ok(grupoVeiculos);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o Grupo de veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoId}", grupoVeiculos.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(GrupoVeiculos grupo)
        {
            Log.Logger.Debug("Tentando excluir grupo de veículos... {@g}", grupo);

            try
            {
                _repositorioGrupoVeiculos.Excluir(grupo);

                Log.Logger.Information("Grupo de Veículos {GrupoId} excluído com sucesso", grupo.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o grupo veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoId}", grupo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<GrupoVeiculos> SelecionarPorId(Guid id)
        {

            try
            {

                return Result.Ok(_repositorioGrupoVeiculos.SelecionarPorId(id));

            }
            catch (Exception ex)
            {

                string msgErro = "Falha no sistema ao tentar selecionar grupo de veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoVeiculosId}", id);

                return Result.Fail(msgErro);

            }
        }

        public Result<List<GrupoVeiculos>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioGrupoVeiculos.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os grupos de veículos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(GrupoVeiculos grupoVeiculos)
        {
            var validador = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validador.Validate(grupoVeiculos);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (NomeDuplicado(grupoVeiculos))
                erros.Add(new Error("Nome duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(GrupoVeiculos grupoVeiculos)
        {
            var grupoVeiculosEncontrado = _repositorioGrupoVeiculos.SelecionarGrupoVeiculosPorNome(grupoVeiculos.Nome);

            return grupoVeiculosEncontrado != null &&
                   grupoVeiculosEncontrado.Nome.ToLower() == grupoVeiculos.Nome.ToLower() &&
                   grupoVeiculosEncontrado.Id != grupoVeiculos.Id;
        }
    }
}
