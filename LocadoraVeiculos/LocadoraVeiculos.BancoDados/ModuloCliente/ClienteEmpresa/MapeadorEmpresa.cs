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
            comando.Parameters.AddWithValue("EMPRESA_CLIENTE_ID", empresa.Condutor.Id);
        }

        public override Empresa ConverterRegistro(SqlDataReader leitorEmpresa)
        {
            var id = Convert.ToInt32(leitorEmpresa["ID"]);
            var nome = Convert.ToString(leitorEmpresa["NOME"]);
            var telefone = Convert.ToString(leitorEmpresa["TELEFONE"]);
            var email = Convert.ToString(leitorEmpresa["EMAIL"]);
            var endereco = Convert.ToString(leitorEmpresa["ENDERECO"]);
            var cnpj = Convert.ToString(leitorEmpresa["CNPJ"]);

            var idCliente = Convert.ToInt32(leitorEmpresa["CLIENTE_ID"]);
            var nomeCliente = Convert.ToString(leitorEmpresa["CLIENTE_NOME"]);
            var telefoneCliente = Convert.ToString(leitorEmpresa["CLIENTE_TELEFONE"]);
            var emailCliente = Convert.ToString(leitorEmpresa["CLIENTE_EMAIL"]);
            var enderecoCliente = Convert.ToString(leitorEmpresa["CLIENTE_ENDERECO"]);
            var cpfCliente = Convert.ToString(leitorEmpresa["CLIENTE_CPF"]);
            var cnhNumeroCliente = Convert.ToInt32(leitorEmpresa["CLIENTE_CNH_NUMERO"]);
            var cnhNomeCliente = Convert.ToString(leitorEmpresa["CLIENTE_CNH_NOME"]);
            var cnhVencimentoCliente = Convert.ToDateTime(leitorEmpresa["CLIENTE_CNH_VENCIMENTO"]);

            Empresa empresa = new Empresa();
            empresa.Id = id;
            empresa.Nome = nome;
            empresa.Telefone = telefone;
            empresa.Email = email;
            empresa.Endereco = endereco;
            empresa.CNPJ = cnpj;
            empresa.Condutor = new Cliente
            {

                Id = idCliente,
                Nome = nomeCliente,
                Telefone = telefoneCliente,
                Email = emailCliente,
                Endereco = enderecoCliente,
                CPF = cpfCliente,
                CnhNumero = cnhNumeroCliente,
                CnhNome = cnhNomeCliente,
                CnhVencimento = cnhVencimentoCliente,

            };

            return empresa;
        }
    }
}
