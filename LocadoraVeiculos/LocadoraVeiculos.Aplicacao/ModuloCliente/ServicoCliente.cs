using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private RepositorioClienteEmBancoDados _repositorioCliente;

        public ServicoCliente(RepositorioClienteEmBancoDados repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public  Result<Cliente> Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir cliente... {@c}", cliente);

            Result resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Cliente {ClienteId} - {Motivo}",
                       cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioCliente.Inserir(cliente);

                Log.Logger.Information("Cliente {ClienteId} inserido com sucesso", cliente.Id);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar cliente... {@c}", cliente);

            Result resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Cliente {ClienteId} - {Motivo}",
                       cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                _repositorioCliente.Editar(cliente);

                Log.Logger.Information("Cliente {ClienteId} editado com sucesso", cliente.Id);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando excluir cliente... {@c}", cliente);

            try
            {
                _repositorioCliente.Excluir(cliente);

                Log.Logger.Information("Cliente {ClienteId} excluído com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> SelecionarPorId(Guid id)
        {

            try
            {

                return Result.Ok(_repositorioCliente.SelecionarPorId(id));

            }
            catch (Exception ex)
            {

                string msgErro = "Falha no sistema ao tentar selecionar o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", id);

                return Result.Fail(msgErro);

            }
        }

        public Result<List<Cliente>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(_repositorioCliente.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os clientes";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(Cliente cliente)
        {
            var validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (ClienteDuplicado(cliente))
                erros.Add(new Error("Cliente duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool ClienteDuplicado(Cliente cliente)
        {
            var clienteEncontrado = _repositorioCliente.ClienteJaExiste(cliente);

            return clienteEncontrado;
        }
    }
}
