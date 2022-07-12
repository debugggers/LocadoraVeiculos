using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using Serilog;

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
            Log.Logger.Debug("Tentando inserir Plano de Cobrança... {@p}", planoCobranca);

            var resultadoValidacao = Validar(planoCobranca);

            if (resultadoValidacao.IsValid)
            {
                Log.Logger.Debug("Plano de Cobrança {PlanoCobrancaId} inserido com sucesso", planoCobranca.Id);
                _repositorioPlanoCobranca.Inserir(planoCobranca);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao inserir Plano de Cobrança {PlanoCobrancaId} - {Motivo}",
                        planoCobranca.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando editar Plano de Cobrança... {@p}", planoCobranca);

            var resultadoValidacao = Validar(planoCobranca);

            if (resultadoValidacao.IsValid)
            {
                Log.Logger.Debug("Plano de Cobrança {PlanoCobrancaId} editado com sucesso", planoCobranca.Id);
                _repositorioPlanoCobranca.Editar(planoCobranca);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao editar Plano de Cobrança {PlanoCobrancaId} - {Motivo}",
                        planoCobranca.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(PlanoCobranca planoCobranca)
        {
            var validador = new ValidadorPlanoCobranca();

            var resultadoValidacao = validador.Validate(planoCobranca);

            if (GrupoVeiculosDuplicado(planoCobranca))
                resultadoValidacao.Errors.Add(new ValidationFailure
                    ("GrupoVeiculos", "Grupo de Veiculos duplicado"));

            return resultadoValidacao;
        }

        private bool GrupoVeiculosDuplicado(PlanoCobranca planoCobranca)
        {
            return _repositorioPlanoCobranca.GrupoVeiculosDuplicado(planoCobranca.GrupoVeiculos.Id);
        }
    }
}
