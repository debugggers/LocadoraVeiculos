﻿using LocadoraVeiculos.Dominio.ModuloDevolucao;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.ModuloDevolucao
{
    public class RepositorioDevolucaoOrm : IRepositorioDevolucao
    {

        public DbSet<Devolucao> devolucoes { get; set; }
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioDevolucaoOrm(LocadoraVeiculosDbContext dbContext)
        {
            devolucoes = dbContext.Set<Devolucao>();
            this.dbContext = dbContext;
        }

        public bool DevulacaoJaExiste(Devolucao devolucao)
        {
            var devolucaoSelecionada = devolucoes.FirstOrDefault(x => x.Id != devolucao.Id && x.Locacao.Id == devolucao.Locacao.Id);

            if (devolucaoSelecionada != null)
                return true;

            return false;
        }

        public void Editar(Devolucao registro)
        {
            devolucoes.Update(registro);
        }

        public void Excluir(Devolucao registro)
        {
            devolucoes.Remove(registro);
        }

        public void Inserir(Devolucao novoRegistro)
        {
            devolucoes.Add(novoRegistro);
        }

        public Devolucao SelecionarPorId(Guid id)
        {
            return devolucoes.SingleOrDefault(x => x.Id == id);
        }

        public List<Devolucao> SelecionarTodos()
        {
            return devolucoes.Include(x => x.Locacao).ToList();
        }
    }
}
