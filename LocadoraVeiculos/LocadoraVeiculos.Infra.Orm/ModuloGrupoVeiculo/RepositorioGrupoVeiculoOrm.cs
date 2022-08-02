using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo
{
    public class RepositorioGrupoVeiculoOrm : IRepositorioGrupoVeiculos
    {

        public DbSet<GrupoVeiculos> grupos { get; set; }
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioGrupoVeiculoOrm(LocadoraVeiculosDbContext dbContext)
        {
            grupos = dbContext.Set<GrupoVeiculos>();
            this.dbContext = dbContext;
        }

        public void Editar(GrupoVeiculos registro)
        {
            grupos.Update(registro);
        }

        public void Excluir(GrupoVeiculos registro)
        {
            try
            {
                grupos.Remove(registro);
            
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                dbContext.Entry(registro).State = EntityState.Unchanged;
                throw new NaoPodeExcluirEsteRegistroException(ex);
            }
        }

        public void Inserir(GrupoVeiculos novoRegistro)
        {
            grupos.Add(novoRegistro);
        }

        public GrupoVeiculos SelecionarGrupoVeiculosPorNome(string nome)
        {
            return grupos.FirstOrDefault(x => x.Nome == nome);
        }

        public GrupoVeiculos SelecionarPorId(Guid id)
        {
            return grupos.SingleOrDefault(x => x.Id == id);
        }

        public List<GrupoVeiculos> SelecionarTodos()
        {
            return grupos.ToList();
        }
    }
}
