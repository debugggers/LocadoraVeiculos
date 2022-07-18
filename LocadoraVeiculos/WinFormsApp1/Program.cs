using LocadoraVeiculos.Infra.Logging;
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
            ConfiguracaoLogsLocadora.ConfigurarEscritaLogs();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceLocator = new IoCAutoFac();

            Application.Run(new TelaMenuPrincipalForm(serviceLocator));
        }
    }
}
