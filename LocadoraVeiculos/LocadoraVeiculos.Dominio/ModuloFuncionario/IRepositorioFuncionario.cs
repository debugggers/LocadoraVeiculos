using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {
        Funcionario SelecionarFuncionarioPorNome(string nome);
        Funcionario SelecionarFuncionarioPorLogin(string login);
        Funcionario SelecionarFuncionarioPorLoginSenha(string login, string senha);
    }
}
