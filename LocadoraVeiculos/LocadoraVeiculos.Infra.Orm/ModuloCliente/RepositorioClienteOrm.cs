using LocadoraVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm : IRepositorioCliente
    {
        public bool ClienteJaExiste(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Editar(Cliente registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Cliente registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Cliente novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Cliente SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
