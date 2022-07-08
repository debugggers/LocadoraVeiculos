using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {

        private RepositorioClienteEmBancoDados repositorioCliente;

        public ServicoCliente(RepositorioClienteEmBancoDados repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }


        public  ValidationResult Inserir(Cliente cliente)
        {

            Log.Logger.Debug("Tentando inserir cliente... {@c}", cliente);

            ValidationResult resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
            {

                repositorioCliente.Inserir(cliente);
                Log.Logger.Debug("Cliente {ClienteNome} inserido com sucesso", cliente.Nome);

            }
            else
            {

                foreach (var item in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao inserir o cliente {ClienteNome} - {Motivo}", cliente.Nome, item.ErrorMessage);

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

                repositorioCliente.Editar(cliente);
                Log.Logger.Debug("Cliente {ClienteNome} editado com sucesso", cliente.Nome);

            }
            else
            {

                foreach (var item in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao editar o cliente {ClienteNome} - {Motivo}", cliente.Nome, item.ErrorMessage);

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
            var clienteEncontrado = repositorioCliente.ClienteJaExiste(cliente);

            return clienteEncontrado;
        }
    }
}
