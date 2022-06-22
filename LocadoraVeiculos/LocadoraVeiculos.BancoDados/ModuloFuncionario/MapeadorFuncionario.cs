using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override Funcionario ConverterRegistro(SqlDataReader leitorFuncionario)
        {
            var id = Convert.ToInt32(leitorFuncionario["ID"]);
            var nome = Convert.ToString(leitorFuncionario["NOME"]);
            var login = Convert.ToString(leitorFuncionario["LOGIN"]);
            var senha = Convert.ToString(leitorFuncionario["SENHA"]);
            var dataAdmissao = Convert.ToDateTime(leitorFuncionario["DATA_ADMISSAO"]);
            var salario = Convert.ToDecimal(leitorFuncionario["SALARIO"]);
            var ehAdmin = Convert.ToBoolean(leitorFuncionario["EHADMIN"]);

            var funcionario = new Funcionario()
            {
                Id = id,
                Nome = nome,
                Login = login,
                Senha = senha,
                DataAdmissao = dataAdmissao,
                Salario = salario,
                EhAdmin = ehAdmin
            };

            return funcionario;
        }

        public override void ConfigurarParametros(Funcionario novoFuncionario, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", novoFuncionario.Id);
            comando.Parameters.AddWithValue("NOME", novoFuncionario.Nome);
            comando.Parameters.AddWithValue("LOGIN", novoFuncionario.Login);
            comando.Parameters.AddWithValue("SENHA", novoFuncionario.Senha);
            comando.Parameters.AddWithValue("DATA_ADMISSAO", novoFuncionario.DataAdmissao);
            comando.Parameters.AddWithValue("SALARIO", novoFuncionario.Salario);
            comando.Parameters.AddWithValue("EHADMIN", novoFuncionario.EhAdmin);
        }
    }
}
