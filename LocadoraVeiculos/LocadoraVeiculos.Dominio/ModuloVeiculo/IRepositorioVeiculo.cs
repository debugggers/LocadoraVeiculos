using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public interface IRepositorioVeiculo : IRepositorio<Veiculo>
    {
        bool VeiculoJaExiste(Veiculo veiculo);
        List<Veiculo> BuscarPeloIdGrupoVeiculos(Guid idGrupoVeiculos);
    }
}
