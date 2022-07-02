namespace LocadoraVeiculos.Dominio.Compartilhado
{
    public class EnderecoBancoConst
    {
        public const string EnderecoBanco = "Data Source = (LocalDB)\\MSSqlLocalDB;" +
               "Initial Catalog=locadoraVeiculosDb;" +
               "Integrated Security=True;" +
               "Pooling=False";

        public const string EnderecoBancoTeste = "Data Source=(LocalDB)\\MSSqlLocalDB;" +
               "Initial Catalog=locadoraVeiculosTesteDb;" +
               "Integrated Security=True;" +
               "Pooling=False";
    }
}
