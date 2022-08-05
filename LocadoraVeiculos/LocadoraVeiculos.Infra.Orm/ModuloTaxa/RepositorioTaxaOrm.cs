using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.ModuloTaxa
{
    public class RepositorioTaxaOrm : IRepositorioTaxa
    {
        private DbSet<Taxa> _taxas;
        private readonly LocadoraVeiculosDbContext _dbContext;

        public RepositorioTaxaOrm(LocadoraVeiculosDbContext dbContext)
        {
            _dbContext = dbContext;
            _taxas = dbContext.Set<Taxa>();
        }

        public void Inserir(Taxa novoRegistro)
        {
            _taxas.Add(novoRegistro);
        }

        public void Editar(Taxa registro)
        {
            _taxas.Update(registro);
        }

        public void Excluir(Taxa registro)
        {
            try
            {
                _taxas.Remove(registro);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _dbContext.Entry(registro).State = EntityState.Detached;
                throw new NaoPodeExcluirEsteRegistroException(ex);
            }            
        }

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return _taxas.FirstOrDefault(x => x.Descricao == descricao);
        }

        public Taxa SelecionarPorId(Guid id)
        {
            return _taxas.SingleOrDefault(x => x.Id == id);
        }

        public List<Taxa> SelecionarTodos()
        {
            return _taxas.ToList();
        }

        public bool ExisteTaxaVinculadaComLocacoes(Guid id)
        {
            return _taxas.Any(x => x.Locacoes.Count() > 0);
        }
    }
}
