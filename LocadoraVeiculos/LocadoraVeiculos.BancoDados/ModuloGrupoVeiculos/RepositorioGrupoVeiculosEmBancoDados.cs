using ControleMedicamentos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosEmBancoDados : RepositorioBase<GrupoVeiculos, MapeadorGrupoVeiculos>
    {

        #region SQL Queries
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPOVEICULO]
           (
		   [Nome]
		   )
        VALUES
           (
            @NOME
		   );SELECT SCOPE_IDENTITY();";

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
            @"SELECT ID 
                FROM 
                    TBGRUPOVEICULO
                WHERE
                    NOME = @NOME";

        #endregion


        public bool GrupoVeiculosJaExiste(string nome)
        {
            SqlConnection conexaoComBanco = new SqlConnection(EnderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNome, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NOME", nome);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var grupoveiculosJaExiste = false;

            if (leitorRegistro != null)
                grupoveiculosJaExiste = leitorRegistro.HasRows;

            conexaoComBanco.Close();

            return grupoveiculosJaExiste;
        }
    }
}
