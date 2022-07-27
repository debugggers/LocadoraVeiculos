using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Data.SqlClient;
using System.Drawing;

namespace LocadoraVeiculos.BancoDados.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo veiculo, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", veiculo.Id);
            comando.Parameters.AddWithValue("VEICULO_MODELO", veiculo.Modelo);
            comando.Parameters.AddWithValue("VEICULO_PLACA", veiculo.Placa);
            comando.Parameters.AddWithValue("VEICULO_MARCA", veiculo.Marca);
            comando.Parameters.AddWithValue("VEICULO_COR", veiculo.Cor);
            comando.Parameters.AddWithValue("VEICULO_TIPO_COMBUSTIVEL", veiculo.TipoCombustivel);
            comando.Parameters.AddWithValue("VEICULO_CAPACIDADE_TANQUE", veiculo.CapacidadeTanque);
            comando.Parameters.AddWithValue("VEICULO_ANO", veiculo.Ano);
            comando.Parameters.AddWithValue("VEICULO_QUILOMETRAGEM", veiculo.QuilometragemPercorrida);
            
            comando.Parameters.AddWithValue("VEICULO_FOTO", veiculo.Foto);
            comando.Parameters.AddWithValue("VEICULO_GRUPO_VEICULO_ID", veiculo.GrupoVeiculo.Id);
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorVeiculo)
        {
            var id = Guid.Parse(leitorVeiculo["ID"].ToString());
            var modelo = Convert.ToString(leitorVeiculo["MODELO"]);
            var placa = Convert.ToString(leitorVeiculo["PLACA"]);
            var marca = Convert.ToString(leitorVeiculo["MARCA"]);
            var cor = Convert.ToString(leitorVeiculo["COR"]);
            var tipoCombustivel = (CombustivelEnum)Convert.ToInt32(leitorVeiculo["TIPO_COMBUSTIVEL"]);
            var capacidadeTanque = Convert.ToInt32(leitorVeiculo["CAPACIDADE_TANQUE"]);
            var ano = Convert.ToInt32(leitorVeiculo["ANO"]);
            var quilometragem = Convert.ToInt32(leitorVeiculo["QUILOMETRAGEM"]);
            byte[] foto = (byte[])leitorVeiculo["FOTO"];

            var idGrupo = Guid.Parse(leitorVeiculo["GRUPO_ID"].ToString());
            var nomeGrupo = Convert.ToString(leitorVeiculo["GRUPO_NOME"]);

            Veiculo veiculo = new Veiculo();
            veiculo.Id = id;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            veiculo.Marca = marca;
            veiculo.Cor = cor;
            veiculo.TipoCombustivel = tipoCombustivel;
            veiculo.CapacidadeTanque = capacidadeTanque;
            veiculo.Ano = ano;
            veiculo.QuilometragemPercorrida = quilometragem;
            veiculo.Foto = foto;
            veiculo.GrupoVeiculo = new GrupoVeiculos
            {
                Id = idGrupo,
                Nome = nomeGrupo
            };

            return veiculo;
        }
    }
}
