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

        public void Editar(Veiculo registro)
        {
            veiculos.Update(registro);
        }

        public void Excluir(Veiculo registro)
        {
            veiculos.Remove(registro);
        }

        public void Inserir(Veiculo novoRegistro)
        {
            veiculos.Add(novoRegistro);
        }

        public Veiculo SelecionarPorId(Guid id)
        {
            return veiculos.SingleOrDefault(x => x.Id == id);
        }

        public List<Veiculo> SelecionarTodos()
        {
            return veiculos.Include(x => x.GrupoVeiculo).ToList();
        }

        public bool VeiculoJaExiste(Veiculo veiculo)
        {
            var veiculoSelecionado = veiculos.FirstOrDefault(x => x.Id != veiculo.Id && x.Placa == veiculo.Placa);

            if (veiculoSelecionado != null)
                return true;

            return false;
        }

        public List<Veiculo> BuscarPeloIdGrupoVeiculos(Guid idGrupoVeiculos)
        {
            return veiculos.Where(x => x.GrupoVeiculoId == idGrupoVeiculos).ToList();
        }
    }
}
