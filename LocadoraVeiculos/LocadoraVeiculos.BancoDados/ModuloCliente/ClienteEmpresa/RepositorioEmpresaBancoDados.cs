using ControleMedicamentos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;

namespace LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa
{
    public class RepositorioEmpresaBancoDados :
        RepositorioBase<Empresa, ValidadorEmpresa, MapeadorEmpresa>
    {
        protected override string sqlInserir =>

            @"INSERT INTO [TBEMPRESA]
                (
                    [NOME],       
                    [TELEFONE], 
                    [EMAIL],                    
                    [ENDERECO],
                    [CNPJ],
                    [CLIENTE_ID]
                )
            VALUES
                (
                    @EMPRESA_NOME,
                    @EMPRESA_TELEFONE,
                    @EMPRESA_EMAIL,
                    @EMPRESA_ENDERECO,
                    @EMPRESA_CNPJ,
                    @EMPRESA_CLIENTE_ID
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>

            @"UPDATE [TBEMPRESA]	
		        SET
                    [NOME] = @EMPRESA_NOME,
                    [TELEFONE] = @EMPRESA_TELEFONE,
                    [EMAIL] = @EMPRESA_EMAIL,
                    [ENDERECO] = @EMPRESA_ENDERECO,
                    [CNPJ] = @EMPRESA_CNPJ,
                    [CLIENTE_ID] = @EMPRESA_CLIENTE_ID
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>

            @"DELETE FROM [TBEMPRESA]
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>

             @"SELECT        
	                EMPRESA.ID,
	                EMPRESA.NOME, 
	                EMPRESA.TELEFONE, 
	                EMPRESA.EMAIL, 
                    EMPRESA.ENDERECO,
 	                EMPRESA.CNPJ,
	
	                CLIENTE.ID CLIENTE_ID,
	                CLIENTE.NOME CLIENTE_NOME, 
	                CLIENTE.TELEFONE CLIENTE_TELEFONE, 
	                CLIENTE.EMAIL CLIENTE_EMAIL, 
                    CLIENTE.ENDERECO CLIENTE_ENDERECO,
                    CLIENTE.CPF CLIENTE_CPF,
                    CLIENTE.CNH_NUMERO CLIENTE_CNH_NUMERO,
                    CLIENTE.CNH_NOME CLIENTE_CNH_NOME,
                    CLIENTE.CNH_VENCIMENTO CLIENTE_CNH_VENCIMENTO
                FROM  
	                TBEMPRESA EMPRESA INNER JOIN TBCLIENTE CLIENTE
                ON 
	                EMPRESA.CLIENTE_ID = CLIENTE.ID
                WHERE 
	                EMPRESA.[ID] = @ID";

        protected override string sqlSelecionarTodos =>

            @"SELECT        
	                EMPRESA.ID,
	                EMPRESA.NOME, 
	                EMPRESA.TELEFONE, 
	                EMPRESA.EMAIL, 
                    EMPRESA.ENDERECO,
 	                EMPRESA.CNPJ,
	
	                CLIENTE.ID CLIENTE_ID,
	                CLIENTE.NOME CLIENTE_NOME, 
	                CLIENTE.TELEFONE CLIENTE_TELEFONE, 
	                CLIENTE.EMAIL CLIENTE_EMAIL, 
                    CLIENTE.ENDERECO CLIENTE_ENDERECO,
                    CLIENTE.CPF CLIENTE_CPF,
                    CLIENTE.CNH_NUMERO CLIENTE_CNH_NUMERO,
                    CLIENTE.CNH_NOME CLIENTE_CNH_NOME,
                    CLIENTE.CNH_VENCIMENTO CLIENTE_CNH_VENCIMENTO
                FROM  
	                TBEMPRESA EMPRESA INNER JOIN TBCLIENTE CLIENTE
                ON 
	                EMPRESA.CLIENTE_ID = CLIENTE.ID";
    }
}
