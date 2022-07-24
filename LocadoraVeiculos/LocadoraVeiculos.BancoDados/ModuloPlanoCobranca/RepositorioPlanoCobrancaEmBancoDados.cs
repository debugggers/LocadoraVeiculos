using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaEmBancoDados :
        RepositorioBase<PlanoCobranca, MapeadorPlanoCobranca>, IRepositorioPlanoCobranca
    {
        #region SQL Queries
        protected override string sqlInserir =>
            @"INSERT INTO TBPLANOCOBRANCA
            (
                   ID,
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
                   @ID,
                   @VALORDIARIO_DIARIO,
                   @VALORPORKM_DIARIO,
                   @VALORDIARIO_LIVRE,
                   @VALORDIARIO_CONTROLADO,
                   @VALORPORKM_CONTROLADO,
                   @CONTROLEKM_CONTROLADO,
                   @GRUPOVEICULOS_ID
            );";

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
		       WHERE PLANO.ID = @ID";

        protected override string sqlSelecionarTodos =>
             @"SELECT 
                    PLANO.*, 
                    GRUPO.NOME AS GRUPOVEICULOS_NOME
               FROM TBPLANOCOBRANCA PLANO
               INNER JOIN TBGRUPOVEICULO GRUPO ON GRUPO.ID = PLANO.GRUPOVEICULOS_ID";

        private const string sqlSelecionarPorGrupoVeiculos =
            @"SELECT * 
                FROM 
                    TBPLANOCOBRANCA
                WHERE
                    GRUPOVEICULOS_ID = @GRUPOVEICULOS_ID";

        #endregion

        public bool GrupoVeiculosDuplicado(Guid idGrupoVeiculos)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorGrupoVeiculos, conexaoComBanco);

            comandoSelecao.Parameters.Add(new SqlParameter("GRUPOVEICULOS_ID", idGrupoVeiculos));

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var grupoVeiculoDuplicado = false;
            if (leitorRegistro.Read())
            {
                var id = Convert.ToInt32(leitorRegistro["ID"]);
                if (id > 0)
                    grupoVeiculoDuplicado = true;
            }

            conexaoComBanco.Close();

            return grupoVeiculoDuplicado;
        }
    }
}
