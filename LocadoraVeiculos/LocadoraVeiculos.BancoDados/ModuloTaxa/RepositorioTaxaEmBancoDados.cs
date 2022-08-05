using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using System;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDados :
        RepositorioBase<Taxa, MapeadorTaxa>, IRepositorioTaxa
    {
        #region SQL Queries
        protected override string sqlInserir =>
            @"INSERT INTO TBTAXA
            (
                    ID,
                    DESCRICAO,
                    VALOR,
                    TIPOCALCULO
            )
            VALUES
            (
                    @ID,
                    @DESCRICAO,
                    @VALOR,
                    @TIPOCALCULO
            );";

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
            @"SELECT * 
                FROM 
                    TBTAXA
                WHERE
                    DESCRICAO = @DESCRICAO";

        #endregion

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return SelecionarPorParametro(sqlSelecionarPorDescricao, new SqlParameter("DESCRICAO", descricao));
        }

        public bool ExisteTaxaVinculadaComLocacoes(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
