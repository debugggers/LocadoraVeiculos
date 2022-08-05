using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.ModuloVeiculo
{
    public class RepositorioVeiculoOrm : IRepositorioVeiculo
    {
        public DbSet<Veiculo> veiculos { get; set; }
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioVeiculoOrm(LocadoraVeiculosDbContext dbContext)
        {
            veiculos = dbContext.Set<Veiculo>();
            this.dbContext = dbContext;
        }

        public void Inserir(Veiculo novoRegistro)
        {
            veiculos.Add(novoRegistro);
        }

        public void Editar(Veiculo registro)
        {
            veiculos.Update(registro);
        }

        public void Excluir(Veiculo registro)
        {
            try
            {
                veiculos.Remove(registro);

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                dbContext.ChangeTracker.Clear();
                throw new NaoPodeExcluirEsteRegistroException(ex);
            }
        }

        public Veiculo SelecionarPorId(Guid id)
        {
            return veiculos.SingleOrDefault(x => x.Id == id);
        }

        public List<Veiculo> SelecionarTodos()
        {
            return veiculos.Include(x => x.GrupoVeiculos).ToList();
        }

        public bool VeiculoJaExiste(Veiculo veiculo)
        {
            var veiculoSelecionado = veiculos.FirstOrDefault(x => x.Id != veiculo.Id && x.Placa == veiculo.Placa);

            if (veiculoSelecionado != null)
                return true;

            return false;
        }

        public List<Veiculo> BuscarVeiculosDisponiveisPeloIdGrupoVeiculos(Guid idGrupoVeiculos)
        {
            return veiculos.Where(x => x.GrupoVeiculosId == idGrupoVeiculos && x.EstaDisponivel).ToList();
        }
    }
}
