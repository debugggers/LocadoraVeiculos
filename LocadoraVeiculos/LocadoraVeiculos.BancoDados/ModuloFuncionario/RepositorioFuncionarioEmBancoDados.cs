using ControleMedicamentos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraVeiculos.BancoDados.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados :
        RepositorioBase<Funcionario, ValidadorFuncionario, MapeadorFuncionario>
    {
        #region SQL Queries
        protected override string sqlInserir =>
            @"INSERT INTO TBFUNCIONARIO
            (
                    NOME,
                    LOGIN,
                    SENHA,
                    DATA_ADMISSAO,
                    SALARIO,
                    EHADMIN
            )
            VALUES
            (
                    @NOME,
                    @LOGIN,
                    @SENHA,
                    @DATA_ADMISSAO,
                    @SALARIO,
                    @EHADMIN
            );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
           @"UPDATE TBFUNCIONARIO
		        SET
			        NOME = @NOME,
                    LOGIN = @LOGIN,
                    SENHA = @SENHA,
                    DATA_ADMISSAO = @DATA_ADMISSAO,
                    SALARIO = @SALARIO,
                    EHADMIN = @EHADMIN
		        WHERE
			        ID = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM TBFUNCIONARIO
		        WHERE
			        ID = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            ID, 
		            NOME,
                    LOGIN,
                    SENHA,
                    DATA_ADMISSAO,
                    SALARIO,
                    EHADMIN
	            FROM 
		            TBFUNCIONARIO
		        WHERE
                    ID = @ID";

        protected override string sqlSelecionarTodos =>
             @"SELECT * FROM TBFUNCIONARIO";

        #endregion
    }
}
