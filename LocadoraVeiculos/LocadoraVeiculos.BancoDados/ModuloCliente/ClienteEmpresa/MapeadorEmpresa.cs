﻿using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using System;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa
{
    public class MapeadorEmpresa : MapeadorBase<Empresa>
    {
        public override void ConfigurarParametros(Empresa empresa, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", empresa.Id);
            comando.Parameters.AddWithValue("NOME", empresa.Nome);
            comando.Parameters.AddWithValue("TELEFONE", empresa.Telefone);
            comando.Parameters.AddWithValue("EMAIL", empresa.Email);
            comando.Parameters.AddWithValue("ENDERECO", empresa.Endereco);
            comando.Parameters.AddWithValue("CNPJ", empresa.CNPJ);
        }

        public override Empresa ConverterRegistro(SqlDataReader leitorEmpresa)
        {
            var id = Guid.Parse(leitorEmpresa["ID"].ToString());
            var nome = Convert.ToString(leitorEmpresa["NOME"]);
            var telefone = Convert.ToString(leitorEmpresa["TELEFONE"]);
            var email = Convert.ToString(leitorEmpresa["EMAIL"]);
            var endereco = Convert.ToString(leitorEmpresa["ENDERECO"]);
            var cnpj = Convert.ToString(leitorEmpresa["CNPJ"]);

            Empresa empresa = new Empresa();
            empresa.Id = id;
            empresa.Nome = nome;
            empresa.Telefone = telefone;
            empresa.Email = email;
            empresa.Endereco = endereco;
            empresa.CNPJ = cnpj;

            return empresa;
        }
    }
}
