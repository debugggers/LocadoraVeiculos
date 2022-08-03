namespace LocadoraVeiculos.Dominio.Compartilhado
{
    public interface IGeradorPdf<T> where T : EntidadeBase<T>
    {

        public void GerarPdf(T comprovante);

    }
}
