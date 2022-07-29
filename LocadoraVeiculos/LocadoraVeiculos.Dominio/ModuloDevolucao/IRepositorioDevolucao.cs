using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.ModuloDevolucao
{
    public interface IRepositorioDevolucao : IRepositorio<Devolucao>
    {
        bool DevulacaoJaExiste(Devolucao devolucao);
    }
}
