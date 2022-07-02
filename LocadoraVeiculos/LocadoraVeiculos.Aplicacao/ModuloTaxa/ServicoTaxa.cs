using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloTaxa;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {
        private RepositorioTaxaEmBancoDados _repositorioTaxa;

        public ServicoTaxa(RepositorioTaxaEmBancoDados repositorioTaxa)
        {
            _repositorioTaxa = repositorioTaxa;
        }

        public ValidationResult Inserir(Taxa taxa)
        {
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                _repositorioTaxa.Inserir(taxa);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                _repositorioTaxa.Editar(taxa);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            if (DescricaoDuplicada(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Descricao", "Descricao duplicada"));

            return resultadoValidacao;
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
