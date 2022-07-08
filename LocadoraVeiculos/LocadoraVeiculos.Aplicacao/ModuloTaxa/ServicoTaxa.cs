using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using Serilog;

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
            Log.Logger.Debug("Tentando inserir taxa... {@t}", taxa);

            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                Log.Logger.Debug("Taxa {TaxaDescricao} inserida com sucesso", taxa.Descricao);
                _repositorioTaxa.Inserir(taxa);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Taxa {TaxaDescricao} - {Motivo}",
                        taxa.Descricao, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar taxa... {@t}", taxa);

            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                Log.Logger.Debug("Taxa {TaxaDescricao} editada com sucesso", taxa.Descricao);
                _repositorioTaxa.Editar(taxa);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Taxa {TaxaDescricao} - {Motivo}",
                        taxa.Descricao, erro.ErrorMessage);
                }
            }

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
