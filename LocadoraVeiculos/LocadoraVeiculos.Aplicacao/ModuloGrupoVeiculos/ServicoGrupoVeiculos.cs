using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos
    {
        private RepositorioGrupoVeiculosEmBancoDados _repositorioGrupoVeiculos;

        public ServicoGrupoVeiculos(RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos)
        {
            _repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public ValidationResult Inserir(GrupoVeiculos grupoVeiculos)
        {

            Log.Logger.Debug("Tentando inserir grupo de veículos... {@g}", grupoVeiculos);

            var resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsValid)
            {

                _repositorioGrupoVeiculos.Inserir(grupoVeiculos);
                Log.Logger.Debug("Grupo de veículos {VeiculoNome} inserido com sucesso", grupoVeiculos.Nome);

            }
            else
            {

                foreach (var item in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao inserir o grupo de veículos {GrupoVeiculoNome} - {Motivo}", grupoVeiculos.Nome, item.ErrorMessage);

                }

            }
                

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoVeiculos grupoVeiculos)
        {

            Log.Logger.Debug("Tentando editar grupo de veículos... {@g}", grupoVeiculos);

            var resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsValid)
            {

                _repositorioGrupoVeiculos.Editar(grupoVeiculos);
                Log.Logger.Debug("Grupo de veículos {VeiculoNome} editado com sucesso", grupoVeiculos.Nome);

            }
            else
            {

                foreach (var item in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao editar o grupo de veículos {GrupoVeiculoNome} - {Motivo}", grupoVeiculos.Nome, item.ErrorMessage);

                }

            }
                

            return resultadoValidacao;
        }

        private ValidationResult Validar(GrupoVeiculos grupoVeiculos)
        {
            var validador = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validador.Validate(grupoVeiculos);

            if (NomeDuplicado(grupoVeiculos))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(GrupoVeiculos grupoVeiculos)
        {
            var grupoVeiculosEncontrado = _repositorioGrupoVeiculos.SelecionarGrupoVeiculosPorNome(grupoVeiculos.Nome);

            return grupoVeiculosEncontrado != null &&
                   grupoVeiculosEncontrado.Nome == grupoVeiculos.Nome &&
                   grupoVeiculosEncontrado.Id != grupoVeiculos.Id;
        }
    }
}
