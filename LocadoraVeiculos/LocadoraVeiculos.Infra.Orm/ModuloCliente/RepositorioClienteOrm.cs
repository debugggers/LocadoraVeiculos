using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm : IRepositorioCliente
    {
        public DbSet<Cliente> clientes { get; set; }
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioClienteOrm(LocadoraVeiculosDbContext dbContext)
        {
            clientes = dbContext.Set<Cliente>();
            this.dbContext = dbContext;
        }

        public bool ClienteJaExiste(Cliente cliente)
        {
            var clienteSelecionado = clientes.FirstOrDefault(x => x.Id != cliente.Id && (x.Nome == cliente.Nome || x.CPF == cliente.CPF || x.CnhNumero == cliente.CnhNumero));

            if (clienteSelecionado != null)
                return true;

            return false;
        }

        public void Editar(Cliente registro)
        {
            clientes.Update(registro);
        }

        public void Excluir(Cliente registro)
        {
            clientes.Remove(registro);
        }

        public void Inserir(Cliente novoRegistro)
        {
            clientes.Add(novoRegistro);
        }

        public Cliente SelecionarPorId(Guid id)
        {
            return clientes.SingleOrDefault(x => x.Id == id);
        }

        public List<Cliente> SelecionarTodos(bool incluirEmpresa = false)
        {
            if(incluirEmpresa)
                return clientes.Include(x => x.Empresa).ToList();

            return clientes.ToList();
        }

        public List<Cliente> SelecionarTodos()
        {
            return clientes.ToList();
        }
    }
}
