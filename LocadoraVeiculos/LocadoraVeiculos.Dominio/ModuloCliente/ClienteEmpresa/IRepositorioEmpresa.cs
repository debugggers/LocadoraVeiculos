using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa
{
    public interface IRepositorioEmpresa : IRepositorio<Empresa>
    {
        bool EmpresaJaExiste(Empresa empresa);
    }
}
