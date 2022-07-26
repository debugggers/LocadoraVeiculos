using LocadoraVeiculos.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Infra.Orm.ModuloTaxa
{
    public class RepositorioTaxaOrm : IRepositorioTaxa
    {
        public void Editar(Taxa registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Taxa registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Taxa novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Taxa SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            throw new NotImplementedException();
        }

        public List<Taxa> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
