using LocadoraVeiculos.Dominio.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.Compartilhado
{
    public abstract class MapeadorBase<T> where T : EntidadeBase<T>
    {
        public abstract T ConverterRegistro(SqlDataReader leitorRegistro);

        public abstract void ConfigurarParametros(T registro, SqlCommand comando);
    }
}
