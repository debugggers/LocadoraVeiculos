using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private RepositorioClienteEmBancoDados _repositorioCliente;

        public ServicoCliente(RepositorioClienteEmBancoDados repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public  ValidationResult Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir cliente... {@c}", cliente);

            ValidationResult resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
            {
                _repositorioCliente.Inserir(cliente);
                Log.Logger.Debug("Cliente {ClienteId} inserido com sucesso", cliente.Id);
            }
            else
            {
                foreach (var item in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao inserir o cliente {ClienteId} - {Motivo}", cliente.Id, item.ErrorMessage);
                }
            }                

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar cliente... {@c}", cliente);

            ValidationResult resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
            {
                _repositorioCliente.Editar(cliente);
                Log.Logger.Debug("Cliente {ClienteId} editado com sucesso", cliente.Id);
            }
            else
            {
                foreach (var item in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao editar o cliente {ClienteId} - {Motivo}", cliente.Id, item.ErrorMessage);
                }
            }
                
            return resultadoValidacao;
        }

        private ValidationResult Validar(Cliente cliente)
        {
            var validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            if (ClienteDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cliente", "Cliente duplicado"));
            return resultadoValidacao;
        }

        private bool ClienteDuplicado(Cliente cliente)
        {
            var clienteEncontrado = _repositorioCliente.ClienteJaExiste(cliente);

            return clienteEncontrado;
        }
    }
}
