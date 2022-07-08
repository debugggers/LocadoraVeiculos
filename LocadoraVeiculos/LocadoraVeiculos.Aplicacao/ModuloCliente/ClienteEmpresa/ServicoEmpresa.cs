using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente.ClienteEmpresa
{
    public class ServicoEmpresa
    {
        private RepositorioEmpresaBancoDados repositorioEmpresa;

        public ServicoEmpresa(RepositorioEmpresaBancoDados repositorioEmpresa)
        {
            this.repositorioEmpresa = repositorioEmpresa;
        }

        public ValidationResult Inserir(Empresa empresa)
        {

            Log.Logger.Debug("Tentando inserir empresa... {@e}", empresa);

            ValidationResult resultadoValidacao = Validar(empresa);

            if (resultadoValidacao.IsValid)
            {

                repositorioEmpresa.Inserir(empresa);
                Log.Logger.Debug("Empresa {EmpresaNome} inserida com sucesso", empresa.Nome);

            }
            else
            {

                foreach (var item in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao inserir a empresa {EmpresaNome} - {Motivo}", empresa.Nome, item.ErrorMessage);

                }

            }
                

            return resultadoValidacao;

        }

        public ValidationResult Editar(Empresa empresa)
        {

            Log.Logger.Debug("Tentando editar empresa... {@e}", empresa);

            ValidationResult resultadoValidacao = Validar(empresa);

            if (resultadoValidacao.IsValid)
            {

                repositorioEmpresa.Editar(empresa);
                Log.Logger.Debug("Empresa {EmpresaNome} editada com sucesso", empresa.Nome);

            }
            else
            {

                foreach (var item in resultadoValidacao.Errors)
                {

                    Log.Logger.Warning("Falha ao editar a empresa {EmpresaNome} - {Motivo}", empresa.Nome, item.ErrorMessage);

                }

            }
                

            return resultadoValidacao;

        }

        private ValidationResult Validar(Empresa empresa)
        {
            var validador = new ValidadorEmpresa();

            var resultadoValidacao = validador.Validate(empresa);

            if (EmpresaDuplicada(empresa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Empresa", "Empresa encontrada"));
            return resultadoValidacao;
        }

        private bool EmpresaDuplicada(Empresa empresa)
        {
            var empresaEncontrada = repositorioEmpresa.EmpresaJaExiste(empresa);

            return empresaEncontrada;
        }

    }
}
