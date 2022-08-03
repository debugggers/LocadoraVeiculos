using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System.Collections.Generic;

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

        public virtual PlanoCobranca PlanoCobranca { get; set; }

        public virtual List<Veiculo> Veiculos { get; set; }

        public virtual List<Locacao> Locacoes { get; set; }

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
