using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;

namespace LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca
    {
        RepositorioPlanoCobrancaEmBancoDados _repositorioPlanoCobranca;

        public ServicoPlanoCobranca(RepositorioPlanoCobrancaEmBancoDados repositorioPlanoCobranca)
        {
            _repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        public ValidationResult Inserir(PlanoCobranca planoCobranca)
        {
            var resultadoValidacao = Validar(planoCobranca);

            if (resultadoValidacao.IsValid)
                _repositorioPlanoCobranca.Inserir(planoCobranca);

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoCobranca planoCobranca)
        {
            var resultadoValidacao = Validar(planoCobranca);

            if (resultadoValidacao.IsValid)
                _repositorioPlanoCobranca.Editar(planoCobranca);

            return resultadoValidacao;
        }

        private ValidationResult Validar(PlanoCobranca planoCobranca)
        {
            var validador = new ValidadorPlanoCobranca();

            var resultadoValidacao = validador.Validate(planoCobranca);

            return resultadoValidacao;
        }
    }
}
