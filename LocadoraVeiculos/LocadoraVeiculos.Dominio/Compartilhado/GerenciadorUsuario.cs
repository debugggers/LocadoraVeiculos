using LocadoraVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraVeiculos.Dominio.Compartilhado
{
    public static class GerenciadorUsuario
    {
        private static Funcionario _funcionario;

        public static void Set(Funcionario funcionario)
        {
            _funcionario = funcionario;
        }

        public static string ObtemNome()
        {
            return _funcionario.Nome;
        }

        public static bool EhAdmin()
        {
            return _funcionario.EhAdmin;
        }
    }
}
