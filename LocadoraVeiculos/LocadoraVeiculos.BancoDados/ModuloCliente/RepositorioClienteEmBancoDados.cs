using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloCliente
{
    public class RepositorioClienteEmBancoDados :
        RepositorioBase<Cliente, MapeadorCliente>
    {
        #region SQL Queries
        protected override string sqlInserir =>

             @"INSERT INTO [TBCLIENTE]
                (
                    [ID],
                    [NOME],       
                    [TELEFONE], 
                    [EMAIL],                    
                    [ENDERECO],
                    [CPF],
                    [CNH_NUMERO],
                    [CNH_NOME],
                    [CNH_VENCIMENTO],
                    [EMPRESA_ID]
                )
            VALUES
                (
                    @CLIENTE_ID,
                    @CLIENTE_NOME,
                    @CLIENTE_TELEFONE,
                    @CLIENTE_EMAIL,
                    @CLIENTE_ENDERECO,
                    @CLIENTE_CPF,
                    @CLIENTE_CNH_NUMERO,
                    @CLIENTE_CNH_NOME,
                    @CLIENTE_CNH_VENCIMENTO,
                    @CLIENTE_EMPRESA_ID
                );";

        protected override string sqlEditar =>

            @"UPDATE [TBCLIENTE]	
		        SET
                    [NOME] = @CLIENTE_NOME,
                    [TELEFONE] = @CLIENTE_TELEFONE,
                    [EMAIL] = @CLIENTE_EMAIL,
                    [ENDERECO] = @CLIENTE_ENDERECO,
                    [CPF] = @CLIENTE_CPF,
                    [CNH_NUMERO] = @CLIENTE_CNH_NUMERO,
                    [CNH_NOME] = @CLIENTE_CNH_NOME,
                    [CNH_VENCIMENTO] = @CLIENTE_CNH_VENCIMENTO,
                    [EMPRESA_ID] = @CLIENTE_EMPRESA_ID
		        WHERE
			        [ID] = @CLIENTE_ID";

        protected override string sqlExcluir =>

            @"DELETE FROM [TBCLIENTE]
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>

            @"SELECT   
                    CLIENTE.ID ,
	                CLIENTE.NOME , 
	                CLIENTE.TELEFONE , 
	                CLIENTE.EMAIL , 
                    CLIENTE.ENDERECO ,
                    CLIENTE.CPF ,
                    CLIENTE.CNH_NUMERO ,
                    CLIENTE.CNH_NOME ,
                    CLIENTE.CNH_VENCIMENTO ,                    

	                EMPRESA.ID EMPRESA_ID,
	                EMPRESA.NOME EMPRESA_NOME, 
	                EMPRESA.TELEFONE EMPRESA_TELEFONE, 
	                EMPRESA.EMAIL EMPRESA_EMAIL, 
                    EMPRESA.ENDERECO EMPRESA_ENDERECO,
 	                EMPRESA.CNPJ EMPRESA_CNPJ
	
            FROM  
	               TBCLIENTE CLIENTE LEFT JOIN TBEMPRESA EMPRESA
            ON 
	               CLIENTE.EMPRESA_ID = EMPRESA.ID
            WHERE
                CLIENTE.[ID] = @ID";

        protected override string sqlSelecionarTodos =>

            @"SELECT   
                    CLIENTE.ID ,
	                CLIENTE.NOME , 
	                CLIENTE.TELEFONE , 
	                CLIENTE.EMAIL , 
                    CLIENTE.ENDERECO ,
                    CLIENTE.CPF ,
                    CLIENTE.CNH_NUMERO ,
                    CLIENTE.CNH_NOME ,
                    CLIENTE.CNH_VENCIMENTO ,                    

	                EMPRESA.ID EMPRESA_ID,
	                EMPRESA.NOME EMPRESA_NOME, 
	                EMPRESA.TELEFONE EMPRESA_TELEFONE, 
	                EMPRESA.EMAIL EMPRESA_EMAIL, 
                    EMPRESA.ENDERECO EMPRESA_ENDERECO,
 	                EMPRESA.CNPJ EMPRESA_CNPJ
	
                FROM  
	                TBCLIENTE CLIENTE LEFT JOIN TBEMPRESA EMPRESA
                ON 
	                CLIENTE.EMPRESA_ID = EMPRESA.ID";

        private const string sqlSelecionarPorNomeOuCpfOuCnhNumero =
            @"SELECT ID 
                FROM 
                    TBCLIENTE
                WHERE
                    (NOME = @NOME OR CPF = @CPF OR CNH_NUMERO = @CNH_NUMERO) AND ID != @ID";
        #endregion

        public bool ClienteJaExiste(Cliente cliente)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNomeOuCpfOuCnhNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NOME", cliente.Nome);
            comandoSelecao.Parameters.AddWithValue("CPF", cliente.CPF);
            comandoSelecao.Parameters.AddWithValue("ID", cliente.Id);
            comandoSelecao.Parameters.AddWithValue("CNH_NUMERO", cliente.CnhNumero);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var clienteJaExiste = false;

            if (leitorRegistro != null)
                clienteJaExiste = leitorRegistro.HasRows;

            conexaoComBanco.Close();

            return clienteJaExiste;
        }
    }
}
