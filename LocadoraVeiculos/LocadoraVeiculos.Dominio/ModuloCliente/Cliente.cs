using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public int CnhNumero { get; set; }
        public string CnhNome { get; set; }
        public DateTime CnhVencimento { get; set; }
        public Empresa Empresa { get; set; }

        public Cliente()
        {



        }

        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                  Id == cliente.Id &&
                  Nome == cliente.Nome &&
                  Telefone == cliente.Telefone &&
                  Email == cliente.Email &&
                  Endereco == cliente.Endereco &&
                  CPF == cliente.CPF &&
                  CnhNumero == cliente.CnhNumero &&
                  CnhNome == cliente.CnhNome &&
                  CnhVencimento == cliente.CnhVencimento &&
                  Empresa == cliente.Empresa;
        }

        public override string ToString()
        {

            return $"Id: {Id}, Nome: {Nome}, Telefone: {Telefone}, Email: {Email}, Endereco: {Endereco}, CPF: {CPF}," + "\n" +
                $" Número da CNH: {CnhNumero}, Nome da CNH: {CnhNome}, Data de Vencimento da CNH: {CnhVencimento.ToShortDateString()}, Nome da empresa: {Empresa.Nome}";
        }

    }
}
