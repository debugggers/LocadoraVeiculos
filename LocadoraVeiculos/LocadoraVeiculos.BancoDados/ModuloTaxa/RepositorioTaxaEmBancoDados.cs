using ControleMedicamentos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDados :
        RepositorioBase<Taxa, MapeadorTaxa>
    {
        #region SQL Queries
        protected override string sqlInserir =>
            @"INSERT INTO TBTAXA
            (
                    DESCRICAO,
                    VALOR,
                    TIPOCALCULO
            )
            VALUES
            (
                    @DESCRICAO,
                    @VALOR,
                    @TIPOCALCULO
            );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
           @"UPDATE TBTAXA
		        SET
			        DESCRICAO = @DESCRICAO,
                    VALOR = @VALOR,
                    TIPOCALCULO = @TIPOCALCULO
		        WHERE
			        ID = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM TBTAXA
		        WHERE
			        ID = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            ID, 
		            DESCRICAO,
                    VALOR,
                    TIPOCALCULO
	            FROM 
		            TBTAXA
		        WHERE
                    ID = @ID";

        protected override string sqlSelecionarTodos =>
             @"SELECT * FROM TBTAXA";

        public const string sqlSelecionarPorDescricao =
            @"SELECT ID 
                FROM 
                    TBTAXA
                WHERE
                    DESCRICAO = @DESCRICAO AND ID != @ID";

        public bool TaxaJaExiste(string descricao, int id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(EnderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorDescricao, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("DESCRICAO", descricao);
            comandoSelecao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var taxaJaExiste = false;

            if (leitorRegistro != null)
                taxaJaExiste = leitorRegistro.HasRows;

            conexaoComBanco.Close();

            return taxaJaExiste;
        }


        #endregion

        public bool VerificarSeExiste(Taxa taxa)
        {

            var taxas = SelecionarTodos();

            foreach (Taxa item in taxas)
            {

                if (item.Descricao == taxa.Descricao)
                    return false;

            }

            return true;
        }
    }
}
