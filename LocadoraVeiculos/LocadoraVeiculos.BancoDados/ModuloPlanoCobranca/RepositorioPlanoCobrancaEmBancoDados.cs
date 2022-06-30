using ControleMedicamentos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaEmBancoDados :
        RepositorioBase<PlanoCobranca, MapeadorPlanoCobranca>
    {
        #region SQL Queries
        protected override string sqlInserir =>
            @"INSERT INTO TBPLANOCOBRANCA
            (
                    TIPOPLANO,
                    VALOR,
                    GRUPOVEICULOS_ID
            )
            VALUES
            (
                    @TIPOPLANO,
                    @VALOR,
                    @GRUPOVEICULOS_ID
            );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
           @"UPDATE TBPLANOCOBRANCA
		        SET
			        TIPOPLANO = @TIPOPLANO,
                    VALOR = @VALOR,
                    GRUPOVEICULOS_ID = @GRUPOVEICULOS_ID
		        WHERE
			        ID = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM TBPLANOCOBRANCA
		        WHERE
			        ID = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT * FROM TBPLANOCOBRANCA
		        WHERE
                    ID = @ID";

        protected override string sqlSelecionarTodos =>
             @"SELECT * FROM TBPLANOCOBRANCA";

        private const string sqlSelecionarPorTipoPlano =
            @"SELECT * 
                FROM 
                    TBPLANOCOBRANCA
                WHERE
                    TIPOPLANO = @TIPOPLANO";

        #endregion

        public PlanoCobranca SelecionarPlanoCobrancaPorTipoPlano(string tipoPlano)
        {
            return SelecionarPorParametro(sqlSelecionarPorTipoPlano, new SqlParameter("TIPOPLANO", tipoPlano));
        }
    }
}
