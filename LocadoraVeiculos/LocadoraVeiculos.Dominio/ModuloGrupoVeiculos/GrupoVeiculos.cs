using LocadoraVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class GrupoVeiculos : EntidadeBase<GrupoVeiculos>
    {
        public GrupoVeiculos()
        {
        }

        public GrupoVeiculos(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public override bool Equals(object obj)
        {
            GrupoVeiculos grupoVeiculos = obj as GrupoVeiculos;

            if (grupoVeiculos == null)
                return false;

            return grupoVeiculos.Id.Equals(Id) &&
                   grupoVeiculos.Nome.Equals(Nome);
        }
    }
}
