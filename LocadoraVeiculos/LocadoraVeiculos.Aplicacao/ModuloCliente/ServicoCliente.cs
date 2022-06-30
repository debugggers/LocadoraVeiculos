using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;

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

            ValidationResult resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Inserir(cliente);

            return resultadoValidacao;

        }

        public ValidationResult Editar(Cliente cliente)
        {

            ValidationResult resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Editar(cliente);

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
