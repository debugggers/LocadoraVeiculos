using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public Funcionario()
        {
            Ativo = true;
        }

        public Funcionario(string nome, string login, string senha, DateTime dataAdmissao, decimal salario, 
            bool ehAdmin, bool ativo)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            DataAdmissao = dataAdmissao;
            Salario = salario;
            EhAdmin = ehAdmin;
            Ativo = ativo;
        }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
        public bool EhAdmin { get; set; }
        public bool Ativo { get; set; }
        public List<Locacao> Locacoes { get; set; }

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
                funcionario.Ativo.Equals(Ativo);
        }
    }
}
