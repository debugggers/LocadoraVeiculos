using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System;

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
            if (_funcionario.Id == Guid.Empty)
                return "Admin";
            return _funcionario.Nome;
        }

        public static Guid? ObtemId()
        {
            if (EhAdmin())
                return null;
            return _funcionario.Id;
        }

        public static bool EhAdmin()
        {
            return _funcionario.EhAdmin;
        }
    }
}
