using LocadoraVeiculos.Dominio.Compartilhado;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa
{
    public class Empresa : EntidadeBase<Empresa>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CNPJ { get; set; }
        public List<Cliente> Clientes { get; set; }

        public Empresa()
        {
        }

        public Empresa(string nome, string email, string telefone, 
            string endereco, string cnpj)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            CNPJ = cnpj;
        }

        public override bool Equals(object obj)
        {
            return obj is Empresa empresa &&
                  Id == empresa.Id &&
                  Nome == empresa.Nome &&
                  Telefone == empresa.Telefone &&
                  Email == empresa.Email &&
                  Endereco == empresa.Endereco &&
                  CNPJ == empresa.CNPJ;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Telefone: {Telefone}, Email: {Email}, Endereco: {Endereco}, CNPJ: {CNPJ}";
        }
    }
}
