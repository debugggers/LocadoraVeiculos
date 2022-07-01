using LocadoraVeiculos.BancoDados.Compartilhado;
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
            comando.Parameters.AddWithValue("EMPRESA_NOME", empresa.Nome);
            comando.Parameters.AddWithValue("EMPRESA_TELEFONE", empresa.Telefone);
            comando.Parameters.AddWithValue("EMPRESA_EMAIL", empresa.Email);
            comando.Parameters.AddWithValue("EMPRESA_ENDERECO", empresa.Endereco);
            comando.Parameters.AddWithValue("EMPRESA_CNPJ", empresa.CNPJ);
        }

        public override Empresa ConverterRegistro(SqlDataReader leitorEmpresa)
        {
            var id = Convert.ToInt32(leitorEmpresa["ID"]);
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
