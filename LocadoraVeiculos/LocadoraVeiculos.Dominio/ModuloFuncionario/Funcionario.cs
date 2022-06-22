using LocadoraVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public Funcionario()
        {
        }

        public Funcionario(string nome, string login, string senha, DateTime dataAdmissao, decimal salario, bool ehAdmin)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            DataAdmissao = dataAdmissao;
            Salario = salario;
            EhAdmin = ehAdmin;
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
