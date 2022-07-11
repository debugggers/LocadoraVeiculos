using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente.ClienteEmpresa
{
    public class ServicoEmpresa
    {
        private RepositorioEmpresaBancoDados _repositorioEmpresa;

        public ServicoEmpresa(RepositorioEmpresaBancoDados repositorioEmpresa)
        {
            _repositorioEmpresa = repositorioEmpresa;
        }

        public ValidationResult Inserir(Empresa empresa)
        {
            Log.Logger.Debug("Tentando inserir empresa... {@e}", empresa);

            ValidationResult resultadoValidacao = Validar(empresa);

            if (resultadoValidacao.IsValid)
            {
                _repositorioEmpresa.Inserir(empresa);
                Log.Logger.Debug("Empresa {EmpresaId} inserida com sucesso", empresa.Id);
            }
            else
            {
                foreach (var item in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao inserir a empresa {EmpresaId} - {Motivo}", empresa.Id, item.ErrorMessage);
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
                _repositorioEmpresa.Editar(empresa);
                Log.Logger.Debug("Empresa {EmpresaId} editada com sucesso", empresa.Id);
            }
            else
            {
                foreach (var item in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao editar a empresa {EmpresaId} - {Motivo}", empresa.Id, item.ErrorMessage);
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
            var empresaEncontrada = _repositorioEmpresa.EmpresaJaExiste(empresa);

            return empresaEncontrada;
        }
    }
}
