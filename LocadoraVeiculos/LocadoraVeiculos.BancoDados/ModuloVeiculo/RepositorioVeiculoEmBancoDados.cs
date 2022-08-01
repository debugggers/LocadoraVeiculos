using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloVeiculo
{
    public class RepositorioVeiculoEmBancoDados : 
        RepositorioBase<Veiculo, MapeadorVeiculo>, IRepositorioVeiculo
    {
        #region SQL Queries
        protected override string sqlInserir =>
            @"INSERT INTO [TBVEICULO]
                (
                    [ID],
                    [MODELO],                    
                    [MARCA],
                    [PLACA],
                    [COR],
                    [TIPO_COMBUSTIVEL],
                    [CAPACIDADE_TANQUE],
                    [ANO],
                    [QUILOMETRAGEM],
                    [FOTO],
                    [GRUPO_VEICULO_ID]
	            )
	            VALUES
                (
                    @ID,
                    @VEICULO_MODELO,                    
                    @VEICULO_MARCA,
                    @VEICULO_PLACA,
                    @VEICULO_COR,
                    @VEICULO_TIPO_COMBUSTIVEL,
                    @VEICULO_CAPACIDADE_TANQUE,
                    @VEICULO_ANO,
                    @VEICULO_QUILOMETRAGEM,
                    @VEICULO_FOTO,
                    @VEICULO_GRUPO_VEICULO_ID
                );";

        protected override string sqlEditar =>
            @"UPDATE [TBVEICULO]	
		        SET
                    [MODELO] = @VEICULO_MODELO,
                    [MARCA] = @VEICULO_MARCA,
                    [PLACA] = @VEICULO_PLACA,
                    [COR] = @VEICULO_COR,
                    [TIPO_COMBUSTIVEL] = @VEICULO_TIPO_COMBUSTIVEL,
                    [CAPACIDADE_TANQUE] = @VEICULO_CAPACIDADE_TANQUE,
                    [ANO] = @VEICULO_ANO,
                    [QUILOMETRAGEM] = @VEICULO_QUILOMETRAGEM,
                    [FOTO] = @VEICULO_FOTO,
                    [GRUPO_VEICULO_ID] = @VEICULO_GRUPO_VEICULO_ID
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
             @"DELETE FROM [TBVEICULO]
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT
                    VEICULO.ID,
                    VEICULO.MODELO,                    
                    VEICULO.MARCA,
                    VEICULO.PLACA,
                    VEICULO.COR,
                    VEICULO.TIPO_COMBUSTIVEL,
                    VEICULO.CAPACIDADE_TANQUE,
                    VEICULO.ANO,
                    VEICULO.QUILOMETRAGEM,
                    VEICULO.FOTO,

	                GRUPO.ID GRUPO_ID,
	                GRUPO.NOME GRUPO_NOME
	
            FROM  
	               TBVEICULO VEICULO INNER JOIN TBGRUPOVEICULO GRUPO
            ON 
	               VEICULO.GRUPO_VEICULO_ID = GRUPO.ID
            WHERE
                VEICULO.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT   
                    VEICULO.ID,
                    VEICULO.MODELO,                    
                    VEICULO.MARCA,
                    VEICULO.PLACA,
                    VEICULO.COR,
                    VEICULO.TIPO_COMBUSTIVEL,
                    VEICULO.CAPACIDADE_TANQUE,
                    VEICULO.ANO,
                    VEICULO.QUILOMETRAGEM,
                    VEICULO.FOTO,

	                GRUPO.ID GRUPO_ID,
	                GRUPO.NOME GRUPO_NOME
            FROM  
	               TBVEICULO VEICULO INNER JOIN TBGRUPOVEICULO GRUPO
            ON 
	               VEICULO.GRUPO_VEICULO_ID = GRUPO.ID";

        private const string sqlSelecionarPorPlaca =
            @"SELECT ID 
                FROM 
                    TBVEICULO
                WHERE
                    PLACA = @PLACA AND ID != @ID";
        #endregion

        public bool VeiculoJaExiste(Veiculo veiculo)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorPlaca, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("PLACA", veiculo.Placa);
            comandoSelecao.Parameters.AddWithValue("ID", veiculo.Id);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var veiculoJaExiste = false;

            if (leitorRegistro != null)
                veiculoJaExiste = leitorRegistro.HasRows;

            conexaoComBanco.Close();

            return veiculoJaExiste;
        }

        public List<Veiculo> BuscarVeiculosDisponiveisPeloIdGrupoVeiculos(Guid idGrupoVeiculos)
        {
            return new List<Veiculo>();
        }
    }
}
