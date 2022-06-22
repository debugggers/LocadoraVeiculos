using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.BancoDados.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente cliente, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", cliente.Id);
            comando.Parameters.AddWithValue("NOME", cliente.Nome);
            comando.Parameters.AddWithValue("TELEFONE", cliente.Telefone);
            comando.Parameters.AddWithValue("EMAIL", cliente.Email);
            comando.Parameters.AddWithValue("ENDERECO", cliente.Endereco);
            comando.Parameters.AddWithValue("CPF", cliente.CPF);
            comando.Parameters.AddWithValue("CNH_NUMERO", cliente.Cnh.Numero);
            comando.Parameters.AddWithValue("CNH_NOME", cliente.Cnh.Nome);
            comando.Parameters.AddWithValue("CNH_VENCIMENTO", cliente.Cnh.Vencimento);
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
            cliente.Cnh = new CNH();
            cliente.Cnh.Numero = numeroCnh;
            cliente.Cnh.Nome = nomeCnh;
            cliente.Cnh.Vencimento = dataVencimento;

            return cliente;

        }
    }
}
