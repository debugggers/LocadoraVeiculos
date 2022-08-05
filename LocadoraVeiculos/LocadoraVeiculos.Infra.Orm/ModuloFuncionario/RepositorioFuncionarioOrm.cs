using LocadoraVeiculos.Dominio.Compartilhado;
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
            registro.Ativo = false;

            _funcionarios.Update(registro);
        }

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            return _funcionarios.FirstOrDefault(x => x.Login == login && x.Ativo);
        }

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return _funcionarios.FirstOrDefault(x => x.Nome == nome && x.Ativo);
        }

        public Funcionario SelecionarFuncionarioPorLoginSenha(string login, string senha)
        {
            return _funcionarios.FirstOrDefault(x => x.Login == login && x.Senha == senha && x.Ativo);
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            return _funcionarios.SingleOrDefault(x => x.Id == id && x.Ativo);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return _funcionarios.Where(x => x.Ativo).ToList();
        }
    }
}
