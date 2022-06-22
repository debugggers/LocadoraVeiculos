using LocadoraVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public Funcionario()
        {
        }

        public Funcionario(string v1, string v2, string v3, DateTime dateTime, decimal v4, bool v5)
        {
            Nome = v1;
            Login = v2;
            Senha = v3;
            DataAdmissao = dateTime;
            Salario = v4;
            EhAdmin = v5;
        }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
        public bool EhAdmin { get; set; }
       

        public override bool Equals(object obj)
        {
            Funcionario funcionario = obj as Funcionario;

            if (funcionario == null)
                return false;

            return
                funcionario.Id.Equals(Id) &&
                funcionario.Nome.Equals(Nome) &&
                funcionario.Login.Equals(Login) &&
                funcionario.Senha.Equals(Senha) &&
                funcionario.DataAdmissao.Equals(DataAdmissao) &&
                funcionario.Salario.Equals(Salario);
                funcionario.EhAdmin.Equals(EhAdmin);
        }
    }
}
