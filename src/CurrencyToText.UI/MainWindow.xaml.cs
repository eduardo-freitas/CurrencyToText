using System.Windows;
using CurrencyToText.UI.ViewModel;

namespace CurrencyToText.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
