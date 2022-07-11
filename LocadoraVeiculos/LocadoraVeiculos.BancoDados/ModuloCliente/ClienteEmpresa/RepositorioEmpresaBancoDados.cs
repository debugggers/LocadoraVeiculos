using ControleMedicamentos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa
{
    public class RepositorioEmpresaBancoDados :
        RepositorioBase<Empresa, MapeadorEmpresa>
    {
        #region Sql Queries

        protected override string sqlInserir =>

            @"INSERT INTO [TBEMPRESA]
                (
                    [NOME],       
                    [TELEFONE], 
                    [EMAIL],                    
                    [ENDERECO],
                    [CNPJ]
                )
            VALUES
                (
                    @EMPRESA_NOME,
                    @EMPRESA_TELEFONE,
                    @EMPRESA_EMAIL,
                    @EMPRESA_ENDERECO,
                    @EMPRESA_CNPJ
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>

            @"UPDATE [TBEMPRESA]	
		        SET
                    [NOME] = @EMPRESA_NOME,
                    [TELEFONE] = @EMPRESA_TELEFONE,
                    [EMAIL] = @EMPRESA_EMAIL,
                    [ENDERECO] = @EMPRESA_ENDERECO,
                    [CNPJ] = @EMPRESA_CNPJ
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>

            @"DELETE FROM [TBEMPRESA]
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>

             @"SELECT        
	                ID,
	                NOME, 
	                TELEFONE, 
	                EMAIL, 
                    ENDERECO,
 	                CNPJ
	
                FROM  
	                [TBEMPRESA]
                WHERE 
	                [ID] = @ID";

        protected override string sqlSelecionarTodos =>

            @"SELECT        
	                [ID],
	                [NOME], 
	                [TELEFONE], 
	                [EMAIL], 
                    [ENDERECO],
 	                [CNPJ]
                FROM  
	                [TBEMPRESA]";

        private const string sqlSelecionarPorNomeOuCnpj =
            @"SELECT ID 
                FROM 
                    TBEMPRESA
                WHERE
                    (NOME = @NOME OR CNPJ = @CNPJ) AND ID != @ID";

        #endregion

        public bool EmpresaJaExiste(Empresa empresa)
        {
            SqlConnection conexaoComBanco = new SqlConnection();

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNomeOuCnpj, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", empresa.Id);
            comandoSelecao.Parameters.AddWithValue("NOME", empresa.Nome);
            comandoSelecao.Parameters.AddWithValue("CNPJ", empresa.CNPJ);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var empresaJaExiste = false;

            if (leitorRegistro != null)
                empresaJaExiste = leitorRegistro.HasRows;

            conexaoComBanco.Close();

            return empresaJaExiste;
        }
    }
}
