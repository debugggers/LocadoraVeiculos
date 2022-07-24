﻿using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.ModuloTaxa
{
    public interface IRepositorioTaxa : IRepositorio<Taxa>
    {
        Taxa SelecionarTaxaPorDescricao(string descricao);
    }
}
