using LocadoraVeiculos.Dominio.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.Compartilhado
{
    public static class Db
    {
        #region Endereço do Banco de Dados
        private static string _enderecoBanco =
            @"Data Source=(LocalDB)\\MSSQLLOCALDB;Initial Catalog=locadoraVeiculosDb;Integrated Security=True";
        #endregion

        public static void ExecutarSql(string sql)
        {
            SqlConnection conexaoComBanco = new SqlConnection(_enderecoBanco);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
    }
}
