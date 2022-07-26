using LocadoraVeiculos.Infra.Logging;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using LocadoraVeiculosForm.Compartilhado.ServiceLocator;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculosForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            MigradorBancoDeDados.AtualizarBancoDados();
            ConfiguracaoLogsLocadora.ConfigurarEscritaLogs();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceLocator = new IoCManual();

            Application.Run(new TelaMenuPrincipalForm(serviceLocator));
        }
    }
}
