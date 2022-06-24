using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
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
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorCliente)
        {

            var id = Convert.ToInt32(leitorCliente["ID"]);
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

            return cliente;

        }
    }
}
