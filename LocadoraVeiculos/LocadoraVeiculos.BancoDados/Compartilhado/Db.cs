using LocadoraVeiculos.Dominio.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.Compartilhado
{
    public static class Db
    {
        #region Endereço do Banco de Dados
        private static string _enderecoBanco = EnderecoBancoConst.EnderecoBanco;
        #endregion

        public static void ExecutarSql(string sql)
        {
            SqlConnection conexaoComBanco = new SqlConnection(_enderecoBanco);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }

        public static void SetEnderecoBanco(string enderecoBanco)
        {
            _enderecoBanco = enderecoBanco;
        }
    }
}
