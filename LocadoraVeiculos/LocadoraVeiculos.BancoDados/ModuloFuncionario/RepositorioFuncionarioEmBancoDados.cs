using ControleMedicamentos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados :
        RepositorioBase<Funcionario, ValidadorFuncionario, MapeadorFuncionario>
    {
        #region SQL Queries
        protected override string sqlInserir =>
            @"INSERT INTO TBFUNCIONARIO
            (
                    NOME,
                    LOGIN,
                    SENHA,
                    DATA_ADMISSAO,
                    SALARIO,
                    EHADMIN
            )
            VALUES
            (
                    @NOME,
                    @LOGIN,
                    @SENHA,
                    @DATA_ADMISSAO,
                    @SALARIO,
                    @EHADMIN
            );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
           @"UPDATE TBFUNCIONARIO
		        SET
			        NOME = @NOME,
                    LOGIN = @LOGIN,
                    SENHA = @SENHA,
                    DATA_ADMISSAO = @DATA_ADMISSAO,
                    SALARIO = @SALARIO,
                    EHADMIN = @EHADMIN
		        WHERE
			        ID = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM TBFUNCIONARIO
		        WHERE
			        ID = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            ID, 
		            NOME,
                    LOGIN,
                    SENHA,
                    DATA_ADMISSAO,
                    SALARIO,
                    EHADMIN
	            FROM 
		            TBFUNCIONARIO
		        WHERE
                    ID = @ID";

        protected override string sqlSelecionarTodos =>
             @"SELECT * FROM TBFUNCIONARIO";

        private const string sqlSelecionarPorLogin =
            @"SELECT ID 
                FROM 
                    TBFUNCIONARIO
                WHERE
                    LOGIN = @LOGIN AND ID != @ID";

        private const string sqlSelecionarPorLoginSenha =
            @"SELECT *
                FROM 
                    TBFUNCIONARIO
                WHERE
                    LOGIN = @LOGIN AND SENHA = @SENHA";

        #endregion

        public bool FuncionarioJaExiste(string login, int id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(EnderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorLogin, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("LOGIN", login);
            comandoSelecao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var funcionarioJaExiste = false;

            if (leitorRegistro != null)
                funcionarioJaExiste = leitorRegistro.HasRows;

            conexaoComBanco.Close();

            return funcionarioJaExiste;
        }

        public Funcionario BuscarUsuarioPorLoginSenha(string login, string senha)
        {
            SqlConnection conexaoComBanco = new SqlConnection(EnderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorLoginSenha, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("LOGIN", login);
            comandoSelecao.Parameters.AddWithValue("SENHA", senha);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var mapeador = new MapeadorFuncionario();

            Funcionario funcionario = null;
            if (leitorRegistro.Read())
                funcionario = mapeador.ConverterRegistro(leitorRegistro);

            conexaoComBanco.Close();

            return funcionario;
        }
    }
}
