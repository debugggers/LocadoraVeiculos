using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosEmBancoDados : 
        RepositorioBase<GrupoVeiculos, MapeadorGrupoVeiculos>, IRepositorioGrupoVeiculos
    {
        #region SQL Queries
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPOVEICULO]
           (
            [ID],
		    [NOME]
		   )
        VALUES
           (
            @ID,
            @NOME
		   );";

        protected override string sqlEditar =>
        @"UPDATE [TBGRUPOVEICULO]
            SET 
                [NOME] = @NOME
            WHERE [ID] = @ID";

        protected override string sqlExcluir =>
        @"DELETE FROM [TBGRUPOVEICULO]
            WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
        @"SELECT 
            [ID],       
            [NOME] 
        FROM
            [TBGRUPOVEICULO]
        WHERE 
            [ID] = @ID";

        protected override string sqlSelecionarTodos =>
        @"SELECT 
            [ID],       
            [NOME]  
        FROM
            [TBGRUPOVEICULO]";

        private const string sqlSelecionarPorNome =
            @"SELECT *
                FROM 
                    TBGRUPOVEICULO
                WHERE
                    NOME = @NOME";

        #endregion

        public GrupoVeiculos SelecionarGrupoVeiculosPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}
