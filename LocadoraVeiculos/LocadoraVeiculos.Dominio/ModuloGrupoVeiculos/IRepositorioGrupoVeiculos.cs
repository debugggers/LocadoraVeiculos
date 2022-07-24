using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.ModuloGrupoVeiculos
{
    public interface IRepositorioGrupoVeiculos : IRepositorio<GrupoVeiculos>
    {
        GrupoVeiculos SelecionarGrupoVeiculosPorNome(string nome);
    }
}
