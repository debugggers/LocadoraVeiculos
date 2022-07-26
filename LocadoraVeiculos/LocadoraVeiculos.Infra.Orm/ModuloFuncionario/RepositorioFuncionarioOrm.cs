using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm : IRepositorioFuncionario
    {
        private DbSet<Funcionario> _funcionarios;
        private readonly LocadoraVeiculosDbContext _dbContext;

        public RepositorioFuncionarioOrm(LocadoraVeiculosDbContext dbContext)
        {
            _dbContext = dbContext;
            _funcionarios = dbContext.Set<Funcionario>();
        }

        public void Inserir(Funcionario novoRegistro)
        {
            _funcionarios.Add(novoRegistro);
        }

        public void Editar(Funcionario registro)
        {
            _funcionarios.Update(registro);
        }

        public void Excluir(Funcionario registro)
        {
            _funcionarios.Remove(registro);
        }

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            return _funcionarios.FirstOrDefault(x => x.Login == login);
        }

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return _funcionarios.FirstOrDefault(x => x.Nome == nome);
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            //cache
            //return disciplinas.Find(id);

            //executa a query no banco
            return _funcionarios.SingleOrDefault(x => x.Id == id);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return _funcionarios.ToList();
        }
    }
}
