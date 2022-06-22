using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.Compartilhado
{
    public static class Db
    {
        #region Endereço do Banco de Dados
        private static string enderecoBanco =
               "Data Source=(LocalDB)\\MSSqlLocalDB;" +
               "Initial Catalog=locadoraVeiculosDb;" +
               "Integrated Security=True;" +
               "Pooling=False";
        #endregion

        public static void ExecutarSql(string sql)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
    }
}
