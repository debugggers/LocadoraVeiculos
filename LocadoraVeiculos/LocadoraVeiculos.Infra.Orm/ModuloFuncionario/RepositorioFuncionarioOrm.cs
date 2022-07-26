using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm : IRepositorioFuncionario
    {
        public void Editar(Funcionario registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Funcionario registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Funcionario novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            throw new NotImplementedException();
        }

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
