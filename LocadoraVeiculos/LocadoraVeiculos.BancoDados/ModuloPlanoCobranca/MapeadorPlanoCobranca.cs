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
            var valorDiarioDiario = Convert.ToDecimal(leitorPlanoCobranca["VALORDIARIO_DIARIO"]);
            var valorPorKmDiario = Convert.ToDecimal(leitorPlanoCobranca["VALORPORKM_DIARIO"]);
            var valorDiarioLivre = Convert.ToDecimal(leitorPlanoCobranca["VALORDIARIO_LIVRE"]);
            var valorDiarioControlado = Convert.ToDecimal(leitorPlanoCobranca["VALORDIARIO_CONTROLADO"]);
            var valorPorKmControlado = Convert.ToDecimal(leitorPlanoCobranca["VALORPORKM_CONTROLADO"]);
            var controleKm = Convert.ToInt32(leitorPlanoCobranca["CONTROLEKM_CONTROLADO"]);

            var grupoVeiculos_Id = Convert.ToInt32(leitorPlanoCobranca["GRUPOVEICULOS_ID"]);
            var grupoVeiculos_Nome = Convert.ToString(leitorPlanoCobranca["GRUPOVEICULOS_NOME"]);

            var planoCobranca = new PlanoCobranca()
            {
                Id = id,
                ValorDiario_Diario = valorDiarioDiario,
                ValorPorKm_Diario = valorPorKmDiario,
                ValorDiario_Livre = valorDiarioLivre,
                ValorDiario_Controlado = valorDiarioControlado,
                ValorPorKm_Controlado = valorPorKmControlado,
                ControleKm = controleKm,

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
            comando.Parameters.AddWithValue("VALORDIARIO_DIARIO", novoPlanoCobranca.ValorDiario_Diario);
            comando.Parameters.AddWithValue("VALORPORKM_DIARIO", novoPlanoCobranca.ValorPorKm_Diario);
            comando.Parameters.AddWithValue("VALORDIARIO_LIVRE", novoPlanoCobranca.ValorDiario_Livre);
            comando.Parameters.AddWithValue("VALORDIARIO_CONTROLADO", novoPlanoCobranca.ValorDiario_Controlado);
            comando.Parameters.AddWithValue("VALORPORKM_CONTROLADO", novoPlanoCobranca.ValorPorKm_Controlado);
            comando.Parameters.AddWithValue("CONTROLEKM_CONTROLADO", novoPlanoCobranca.ControleKm);
            comando.Parameters.AddWithValue("GRUPOVEICULOS_ID", novoPlanoCobranca.IdGrupoVeiculos);
        }
    }
}
