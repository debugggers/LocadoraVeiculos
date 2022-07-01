using ControleMedicamentos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;

namespace LocadoraVeiculos.BancoDados.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaEmBancoDados :
        RepositorioBase<PlanoCobranca, MapeadorPlanoCobranca>
    {
        #region SQL Queries
        protected override string sqlInserir =>
            @"INSERT INTO TBPLANOCOBRANCA
            (
                   VALORDIARIO_DIARIO,
                   VALORPORKM_DIARIO,
                   VALORDIARIO_LIVRE,
                   VALORDIARIO_CONTROLADO,
                   VALORPORKM_CONTROLADO,
                   CONTROLEKM_CONTROLADO,
                   GRUPOVEICULOS_ID
            )
            VALUES
            (
                   @VALORDIARIO_DIARIO,
                   @VALORPORKM_DIARIO,
                   @VALORDIARIO_LIVRE,
                   @VALORDIARIO_CONTROLADO,
                   @VALORPORKM_CONTROLADO,
                   @CONTROLEKM_CONTROLADO,
                   @GRUPOVEICULOS_ID
            );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
           @"UPDATE TBPLANOCOBRANCA
		        SET
			       VALORDIARIO_DIARIO = @VALORDIARIO_DIARIO,
                   VALORPORKM_DIARIO = @VALORPORKM_DIARIO,
                   VALORDIARIO_LIVRE = @VALORDIARIO_LIVRE,
                   VALORDIARIO_CONTROLADO = @VALORDIARIO_CONTROLADO,
                   VALORPORKM_CONTROLADO = @VALORPORKM_CONTROLADO,
                   CONTROLEKM_CONTROLADO = @CONTROLEKM_CONTROLADO,
                   GRUPOVEICULOS_ID = @GRUPOVEICULOS_ID
		        WHERE
			        ID = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM TBPLANOCOBRANCA
		        WHERE
			        ID = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                    PLANO.*, 
                    GRUPO.NOME AS GRUPOVEICULOS_NOME
               FROM TBPLANOCOBRANCA PLANO
               INNER JOIN TBGRUPOVEICULO GRUPO ON GRUPO.ID = PLANO.GRUPOVEICULOS_ID
		       WHERE plano.ID = @ID";

        protected override string sqlSelecionarTodos =>
             @"SELECT 
                    PLANO.*, 
                    GRUPO.NOME AS GRUPOVEICULOS_NOME
               FROM TBPLANOCOBRANCA PLANO
               INNER JOIN TBGRUPOVEICULO GRUPO ON GRUPO.ID = PLANO.GRUPOVEICULOS_ID";

        #endregion
    }
}
