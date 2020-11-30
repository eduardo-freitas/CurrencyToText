using CurrencyToText.DataAccess.Contract;
using CurrencyToText.Model;
using CurrencyToText.UI.Command;

namespace CurrencyToText.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _conversionOutput;
        private string _currencyToConvert;
        private readonly IConversionService _conversionService;

        
        public MainViewModel(IConversionService conversionService)
        {
            _conversionService = conversionService;
            CurrencyToConvert = "";
            ConverstionOutput = "";
        }

        public ConvertCommand Convert { get; } = new ConvertCommand();

        public void ExecuteConversion(string value)
        {
            CurrencyToConvertModel currencyToConvertModel =
                ConvertCommandHelper.MapToDataAccessModel(value);
            var response = _conversionService.ConvertToText(currencyToConvertModel);
            ConverstionOutput = response.Result.WordsValue;
        }

        public string CurrencyToConvert
        {
            get => _currencyToConvert;
            set
            {
                _currencyToConvert = value;
                Convert.RaiseCanExecuteChanged();
            }
        }

        public string ConverstionOutput
        {
            get => _conversionOutput;
            set
            {
                _conversionOutput = value;
                OnPropertyChanged();
            }
        }
    }
}