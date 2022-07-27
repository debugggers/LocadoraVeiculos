using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.ModuloCliente.ModuloEmpresa
{
    public class RepositorioEmpresaOrm : IRepositorioEmpresa
    {

        public DbSet<Empresa> empresas { get; set; }
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioEmpresaOrm(LocadoraVeiculosDbContext dbContext)
        {
            empresas = dbContext.Set<Empresa>();
            this.dbContext = dbContext;
        }

        public void Editar(Empresa registro)
        {
            empresas.Update(registro);
        }

        public bool EmpresaJaExiste(Empresa empresa)
        {
            var empresaSelecionada = empresas.FirstOrDefault(x => x.Id != empresa.Id && (x.Nome == empresa.Nome || x.CNPJ == empresa.CNPJ));

            if (empresaSelecionada != null)
                return true;

            return false;
        }

        public void Excluir(Empresa registro)
        {
            empresas.Remove(registro);
        }

        public void Inserir(Empresa novoRegistro)
        {
            empresas.Add(novoRegistro);
        }

        public Empresa SelecionarPorId(Guid id)
        {
            return empresas.SingleOrDefault(x => x.Id == id);
        }

        public List<Empresa> SelecionarTodos()
        {
            return empresas.ToList();
        }
    }
}
