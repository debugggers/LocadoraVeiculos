using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using System.Data.SqlClient;
using System;

namespace LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculos : MapeadorBase<GrupoVeiculos>
    {
        public override GrupoVeiculos ConverterRegistro(SqlDataReader leitorGrupoVeiculos)
        {
            var id = Guid.Parse(leitorGrupoVeiculos["ID"].ToString());
            var nome = Convert.ToString(leitorGrupoVeiculos["NOME"]);

            var grupoveiculos = new GrupoVeiculos()
            {
                Id = id,
                Nome = nome,
            };

            return grupoveiculos;
        }
     
        public override void ConfigurarParametros(GrupoVeiculos novoGrupoVeiculos, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", novoGrupoVeiculos.Id);
            comando.Parameters.AddWithValue("NOME", novoGrupoVeiculos.Nome);
        }
    }

}