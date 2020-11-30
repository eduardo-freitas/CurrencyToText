using CurrencyToText.UI.ViewModel;

namespace CurrencyToText.UI.Command
{
    public class ConvertCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            return viewModel != null && ConvertCommandHelper.IsValidInputFormat(viewModel.CurrencyToConvert);
        }

        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel != null) viewModel.ExecuteConversion(viewModel.CurrencyToConvert);
        }
    }
}
