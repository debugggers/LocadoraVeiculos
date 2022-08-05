namespace LocadoraVeiculosForm.Compartilhado.ServiceLocator
{
    public interface IServiceLocator
    {
        T Get<T>() where T : ControladorBase;

        T GetGeneric<T>();
    }
}


