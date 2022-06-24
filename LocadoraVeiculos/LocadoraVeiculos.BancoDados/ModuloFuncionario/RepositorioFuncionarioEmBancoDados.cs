using ControleMedicamentos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
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

        private const string sqlSelecionarPorNome =
            @"SELECT ID 
                FROM 
                    TBFUNCIONARIO
                WHERE
                    NOME = @NOME AND ID != @ID";

        #endregion

        public bool FuncionarioJaExiste(string nome, int id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNome, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NOME", nome);
            comandoSelecao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var funcionarioJaExiste = false;

            if (leitorRegistro != null)
                funcionarioJaExiste = leitorRegistro.HasRows;

            conexaoComBanco.Close();

            return funcionarioJaExiste;
        }
    }
}
