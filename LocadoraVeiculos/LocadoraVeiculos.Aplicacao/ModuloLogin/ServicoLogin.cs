using LocadoraVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraVeiculos.Aplicacao.ModuloLogin
{
    public class ServicoLogin
    {
        private IRepositorioFuncionario _repositorioFuncionario;

        public ServicoLogin(IRepositorioFuncionario repositorioFuncionario)
        {
            _repositorioFuncionario = repositorioFuncionario;
        }

        public Funcionario SelecionarFuncionarioPorLoginSenha(string login, string senha)
        {
            return _repositorioFuncionario.SelecionarFuncionarioPorLoginSenha(login, senha);
        }
    }
}
