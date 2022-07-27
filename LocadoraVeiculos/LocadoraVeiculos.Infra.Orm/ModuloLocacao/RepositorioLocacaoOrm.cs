using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.ModuloLocacao
{
    public class RepositorioLocacaoOrm : IRepositorioLocacao
    {
        private DbSet<Locacao> _locacoes;
        private readonly LocadoraVeiculosDbContext _dbContext;

        public RepositorioLocacaoOrm(LocadoraVeiculosDbContext dbContext)
        {
            _dbContext = dbContext;
            _locacoes = dbContext.Set<Locacao>();
        }

        public void Inserir(Locacao novoRegistro)
        {
            _locacoes.Add(novoRegistro);
        }

        public void Editar(Locacao registro)
        {
            _locacoes.Update(registro);
        }

        public void Excluir(Locacao registro)
        {
            _locacoes.Remove(registro);
        }

        public Locacao SelecionarPorId(Guid id)
        {
            return _locacoes.SingleOrDefault(x => x.Id == id);
        }

        public List<Locacao> SelecionarTodos()
        {
            return _locacoes.ToList();
        }
    }
}
