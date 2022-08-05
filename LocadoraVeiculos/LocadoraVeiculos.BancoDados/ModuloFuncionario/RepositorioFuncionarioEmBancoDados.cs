using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados :
        RepositorioBase<Funcionario, MapeadorFuncionario>, IRepositorioFuncionario
    {
        #region SQL Queries
        protected override string sqlInserir =>
            @"INSERT INTO TBFUNCIONARIO
            (
                    ID,
                    NOME,
                    LOGIN,
                    SENHA,
                    DATA_ADMISSAO,
                    SALARIO,
                    EHADMIN
            )
            VALUES
            (
                    @ID,
                    @NOME,
                    @LOGIN,
                    @SENHA,
                    @DATA_ADMISSAO,
                    @SALARIO,
                    @EHADMIN
            );";

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

        private const string sqlSelecionarPorNome =
            @"SELECT * 
                FROM 
                    TBFUNCIONARIO
                WHERE
                    NOME = @NOME";

        private const string sqlSelecionarPorLogin =
            @"SELECT * 
                FROM 
                    TBFUNCIONARIO
                WHERE
                    LOGIN = @LOGIN";

        private const string sqlSelecionarPorLoginSenha =
            @"SELECT *
                FROM 
                    TBFUNCIONARIO
                WHERE
                    LOGIN = @LOGIN AND SENHA = @SENHA";

        #endregion

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            return SelecionarPorParametro(sqlSelecionarPorLogin, new SqlParameter("LOGIN", login));
        }

        public Funcionario BuscarUsuarioPorLoginSenha(string login, string senha)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

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

        public Funcionario SelecionarFuncionarioPorLoginSenha(string login, string senha)
        {
            throw new System.NotImplementedException();
        }
    }
}
