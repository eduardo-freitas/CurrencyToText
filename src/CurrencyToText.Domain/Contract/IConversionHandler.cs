namespace CurrencyToText.Domain.Contract
{
    public interface IConversionHandler
    {
        string ConvertFromCurrencyToText(decimal currencyValue);
    }
}