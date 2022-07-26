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
            _taxas.Remove(registro);
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
    }
}
