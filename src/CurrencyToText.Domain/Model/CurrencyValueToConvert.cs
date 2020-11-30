namespace CurrencyToText.Domain.Model
{
    public class CurrencyValueToConvert
    {
        public CurrencyValueToConvert(decimal currencyValue)
        {
            CurrencyValue = currencyValue;
        }

        public decimal CurrencyValue { get; set; }
    }
}
