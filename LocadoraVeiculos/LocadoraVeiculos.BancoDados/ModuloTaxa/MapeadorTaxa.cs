﻿using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using System;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloTaxa
{
    public class MapeadorTaxa : MapeadorBase<Taxa>
    {
        public override Taxa ConverterRegistro(SqlDataReader leitorTaxa)
        {
            var id = Guid.Parse(leitorTaxa["ID"].ToString());
            var descricao = Convert.ToString(leitorTaxa["DESCRICAO"]);
            var valor = Convert.ToDecimal(leitorTaxa["VALOR"]);
            var tipoCalculo = (TipoCalculoEnum) leitorTaxa["TIPOCALCULO"];

            var taxa = new Taxa()
            {
                Id = id,
                Descricao = descricao,
                Valor = valor,
                TipoCalculo = tipoCalculo
            };

            return taxa;
        }

        public override void ConfigurarParametros(Taxa novaTaxa, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", novaTaxa.Id);
            comando.Parameters.AddWithValue("DESCRICAO", novaTaxa.Descricao);
            comando.Parameters.AddWithValue("VALOR", novaTaxa.Valor);
            comando.Parameters.AddWithValue("TIPOCALCULO", novaTaxa.TipoCalculo);
        }
    }
}
