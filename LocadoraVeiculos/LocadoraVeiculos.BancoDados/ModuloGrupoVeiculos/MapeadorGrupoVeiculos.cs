using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using System.Data.SqlClient;
using System;

namespace LocadoraVeiculos.BancoDados.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculos : MapeadorBase<GrupoVeiculos>
    {
        public override GrupoVeiculos ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var nome = Convert.ToString(leitorRegistro["NOME"]);

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