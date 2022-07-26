using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Infra.Orm.ModuloVeiculo
{
    public class RepositorioVeiculoOrm : IRepositorioVeiculo
    {
        public void Editar(Veiculo registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Veiculo registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Veiculo novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Veiculo SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Veiculo> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        public bool VeiculoJaExiste(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }
    }
}
