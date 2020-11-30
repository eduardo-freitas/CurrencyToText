namespace CurrencyToText.Model
{
    public class CurrencyToConvertModel
    {
        public CurrencyToConvertModel(decimal currencyValue)
        {
            CurrencyValue = currencyValue;
        }

        public decimal CurrencyValue { get; set; }
    }
}
