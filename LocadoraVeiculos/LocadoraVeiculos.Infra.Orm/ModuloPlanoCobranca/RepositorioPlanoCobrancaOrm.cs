using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaOrm : IRepositorioPlanoCobranca
    {
        private DbSet<PlanoCobranca> _planosCobranca;
        private readonly LocadoraVeiculosDbContext _dbContext;

        public RepositorioPlanoCobrancaOrm(LocadoraVeiculosDbContext dbContext)
        {
            _dbContext = dbContext;
            _planosCobranca = dbContext.Set<PlanoCobranca>();
        }

        public void Inserir(PlanoCobranca novoRegistro)
        {
            _planosCobranca.Add(novoRegistro);
        }

        public void Editar(PlanoCobranca registro)
        {
            _planosCobranca.Update(registro);
        }

        public void Excluir(PlanoCobranca registro)
        {
            _planosCobranca.Remove(registro);
        }

        public bool GrupoVeiculosDuplicado(Guid idPlanoCobranca, Guid idGrupoVeiculos)
        {
            var planoCobrancaComGrupoSelecionado = _planosCobranca.FirstOrDefault(x => x.GrupoVeiculos.Id == idGrupoVeiculos && x.Id != idPlanoCobranca);

            if (planoCobrancaComGrupoSelecionado != null)
                return true;

            return false;
        }

        public PlanoCobranca SelecionarPorId(Guid id)
        {
            return _planosCobranca.SingleOrDefault(x => x.Id == id);
        }

        public List<PlanoCobranca> SelecionarTodos()
        {
            return _planosCobranca.Include(x => x.GrupoVeiculos).ToList();
        }

        public List<PlanoCobranca> BuscarListPlanoIdGrupoVeiculos(Guid idGrupoVeiculos)
        {
            return _planosCobranca.Where(x => x.GrupoVeiculosId == idGrupoVeiculos).ToList();
        }

        public PlanoCobranca BuscarPlanoIdGrupoVeiculos(Guid idGrupoVeiculos)
        {
            return _planosCobranca.FirstOrDefault(x => x.GrupoVeiculosId == idGrupoVeiculos);
        }
    }
}
