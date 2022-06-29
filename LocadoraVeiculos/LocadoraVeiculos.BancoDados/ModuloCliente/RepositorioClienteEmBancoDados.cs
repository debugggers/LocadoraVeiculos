using ControleMedicamentos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloCliente
{
    public class RepositorioClienteEmBancoDados :
        RepositorioBase<Cliente, MapeadorCliente>
    {
        protected override string sqlInserir =>

             @"INSERT INTO [TBCLIENTE]
                (
                    [NOME],       
                    [TELEFONE], 
                    [EMAIL],                    
                    [ENDERECO],
                    [CPF],
                    [CNH_NUMERO],
                    [CNH_NOME],
                    [CNH_VENCIMENTO]
                )
            VALUES
                (
                    @CLIENTE_NOME,
                    @CLIENTE_TELEFONE,
                    @CLIENTE_EMAIL,
                    @CLIENTE_ENDERECO,
                    @CLIENTE_CPF,
                    @CLIENTE_CNH_NUMERO,
                    @CLIENTE_CNH_NOME,
                    @CLIENTE_CNH_VENCIMENTO
                ); SELECT SCOPE_IDENTITY();";

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
                    [CNH_VENCIMENTO] = @CLIENTE_CNH_VENCIMENTO
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>

            @"DELETE FROM [TBCLIENTE]
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>

            @"SELECT 
                [ID],       
                [NOME],
                [TELEFONE],
                [EMAIL],             
                [ENDERECO],                    
                [CPF],
                [CNH_NUMERO],
                [CNH_NOME],
                [CNH_VENCIMENTO]
            FROM
                [TBCLIENTE]
            WHERE 
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>

            @"SELECT 
		            [ID],       
                    [NOME],
                    [TELEFONE],
                    [EMAIL],             
                    [ENDERECO],                    
                    [CPF],
                    [CNH_NUMERO],
                    [CNH_NOME],
                    [CNH_VENCIMENTO]
	            FROM 
		            [TBCLIENTE]";

        private const string sqlSelecionarPorNomeOuCpfOuCnhNumero =
            @"SELECT ID 
                FROM 
                    TBCLIENTE
                WHERE
                    (NOME = @NOME OR CPF = @CPF OR CNH_NUMERO = @CNH_NUMERO) AND ID != @ID";

        public bool ClienteJaExiste(Cliente cliente)
        {
            SqlConnection conexaoComBanco = new SqlConnection(EnderecoBanco);

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
