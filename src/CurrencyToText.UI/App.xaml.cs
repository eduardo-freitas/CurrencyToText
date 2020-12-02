using System.Net.Http;
using System.Windows;
using CurrencyToText.DataAccess.Service;
using CurrencyToText.UI.ViewModel;

namespace CurrencyToText.UI
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow(new MainViewModel(new ConversionService(new HttpClient())));
            mainWindow.Show();
        }
    }
}
