using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using System;
using System.Data.SqlClient;

namespace LocadoraVeiculos.BancoDados.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente cliente, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", cliente.Id);
            comando.Parameters.AddWithValue("CLIENTE_NOME", cliente.Nome);
            comando.Parameters.AddWithValue("CLIENTE_TELEFONE", cliente.Telefone);
            comando.Parameters.AddWithValue("CLIENTE_EMAIL", cliente.Email);
            comando.Parameters.AddWithValue("CLIENTE_ENDERECO", cliente.Endereco);
            comando.Parameters.AddWithValue("CLIENTE_CPF", cliente.CPF);
            comando.Parameters.AddWithValue("CLIENTE_CNH_NUMERO", cliente.CnhNumero);
            comando.Parameters.AddWithValue("CLIENTE_CNH_NOME", cliente.CnhNome);
            comando.Parameters.AddWithValue("CLIENTE_CNH_VENCIMENTO", cliente.CnhVencimento);
            //comando.Parameters.AddWithValue("CLIENTE_EMPRESA_ID", cliente.Empresa.Id);
            comando.Parameters.AddWithValue("CLIENTE_EMPRESA_ID", cliente.Empresa == null ? DBNull.Value : cliente.Empresa.Id);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorCliente)
        {
            var id = Guid.Parse(leitorCliente["ID"].ToString());
            var nome = Convert.ToString(leitorCliente["NOME"]);
            var telefone = Convert.ToString(leitorCliente["TELEFONE"]);
            var email = Convert.ToString(leitorCliente["EMAIL"]);
            var endereco = Convert.ToString(leitorCliente["ENDERECO"]);
            var cpf = Convert.ToString(leitorCliente["CPF"]);
            var numeroCnh = Convert.ToInt32(leitorCliente["CNH_NUMERO"]);
            var nomeCnh = Convert.ToString(leitorCliente["CNH_NOME"]);
            var dataVencimento = Convert.ToDateTime(leitorCliente["CNH_VENCIMENTO"]);

            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente.Nome = nome;
            cliente.Telefone = telefone;
            cliente.Email = email;
            cliente.Endereco = endereco;
            cliente.CPF = cpf;
            cliente.CnhNumero = numeroCnh;
            cliente.CnhNome = nomeCnh;
            cliente.CnhVencimento = dataVencimento;

            if (leitorCliente["EMPRESA_ID"] != DBNull.Value)
            {
                var idEmpresa = Guid.Parse(leitorCliente["EMPRESA_ID"].ToString());
                var nomeEmpresa = Convert.ToString(leitorCliente["EMPRESA_NOME"]);
                var telefoneEmpresa = Convert.ToString(leitorCliente["EMPRESA_TELEFONE"]);
                var emailEmpresa = Convert.ToString(leitorCliente["EMPRESA_EMAIL"]);
                var enderecoEmpresa = Convert.ToString(leitorCliente["EMPRESA_ENDERECO"]);
                var cnpj = Convert.ToString(leitorCliente["EMPRESA_CNPJ"]);

                cliente.Empresa = new Empresa
                {
                    Id = idEmpresa,
                    Nome = nomeEmpresa,
                    Telefone = telefoneEmpresa,
                    Email = emailEmpresa,
                    Endereco = enderecoEmpresa,
                    CNPJ = cnpj,
                };
            }

            return cliente;
        }
    }
}
