namespace CurrencyToText.Domain.Business
{
    public interface IConversionHandler
    {
        string ConvertFromCurrencyToWords(decimal currencyValue);
    }
}