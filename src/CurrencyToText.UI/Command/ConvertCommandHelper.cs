using System.Text.RegularExpressions;
using CurrencyToText.Model;

namespace CurrencyToText.UI.Command
{
    public static class ConvertCommandHelper
    {
        private static readonly Regex CurrencyValidation = new Regex("^[0-9]{1,9}([,][0-9]{1,2})?$");
        public static bool IsValidInputFormat(string input)
        {
            return CurrencyValidation.IsMatch(input);
        }

        public static CurrencyToConvertModel MapToDataAccessModel(string input)
        {
            decimal.TryParse(input, out var decimalValue);
            return new CurrencyToConvertModel(decimalValue);
        }
    }
}
