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
                    DESCRICAO = @DESCRICAO";

        #endregion

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return SelecionarPorParametro(sqlSelecionarPorDescricao, new SqlParameter("DESCRICAO", descricao));
        }
    }
}
