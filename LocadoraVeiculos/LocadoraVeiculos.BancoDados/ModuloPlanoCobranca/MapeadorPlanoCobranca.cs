using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobranca : MapeadorBase<PlanoCobranca>
    {
        public override PlanoCobranca ConverterRegistro(SqlDataReader leitorPlanoCobranca)
        {
            var id = Convert.ToInt32(leitorPlanoCobranca["ID"]);
            var tipoPlano = (TipoPlanoEnum)(leitorPlanoCobranca["TIPOPLANO"]);
            var valor = Convert.ToDecimal(leitorPlanoCobranca["VALOR"]);
            
            var grupoVeiculos_Id = Convert.ToInt32(leitorPlanoCobranca["GRUPOVEICULOS_ID"]);
            var grupoVeiculos_Nome = Convert.ToString(leitorPlanoCobranca["GRUPOVEICULOS_NOME"]);

            var planoCobranca = new PlanoCobranca()
            {
                Id = id,
                TipoPlano = tipoPlano,
                Valor = valor,
                IdGrupoVeiculos = grupoVeiculos_Id,
                GrupoVeiculos = new GrupoVeiculos
                {
                    Id = grupoVeiculos_Id,
                    Nome = grupoVeiculos_Nome
                }                
            };

            return planoCobranca;
        }

        public override void ConfigurarParametros(PlanoCobranca novoPlanoCobranca, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", novoPlanoCobranca.Id);
            comando.Parameters.AddWithValue("TIPOPLANO", novoPlanoCobranca.TipoPlano);
            comando.Parameters.AddWithValue("VALOR", novoPlanoCobranca.Valor);
            comando.Parameters.AddWithValue("GRUPOVEICULOS_ID", novoPlanoCobranca.IdGrupoVeiculos);
        }
    }
}
