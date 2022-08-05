using LocadoraVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraVeiculos.Dominio.ModuloTaxa
{
    public interface IRepositorioTaxa : IRepositorio<Taxa>
    {
        Taxa SelecionarTaxaPorDescricao(string descricao);
        bool ExisteTaxaVinculadaComLocacoes(Guid id);
    }
}
