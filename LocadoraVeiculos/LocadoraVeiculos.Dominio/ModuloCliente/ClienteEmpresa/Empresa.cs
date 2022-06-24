using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa
{
    public class Empresa : EntidadeBase<Empresa>
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CNPJ { get; set; }
        public Cliente Condutor { get; set; }

        public Empresa()
        {



        }

        public override bool Equals(object obj)
        {
            return obj is Empresa empresa &&
                  Id == empresa.Id &&
                  Nome == empresa.Nome &&
                  Telefone == empresa.Telefone &&
                  Email == empresa.Email &&
                  Endereco == empresa.Endereco &&
                  CNPJ == empresa.CNPJ &&
                  Condutor.Id == empresa.Condutor.Id;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Telefone: {Telefone}, Email: {Email}, Endereco: {Endereco}, CNPJ: {CNPJ}," + "\n" +
                $" Número do Condutor: {Condutor.Id}";
        }

    }
}
