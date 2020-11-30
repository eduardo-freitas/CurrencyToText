using CurrencyToText.Domain.Model;

namespace CurrencyToText.Domain.Contract
{
    public interface IConversionToWordsManager
    {
        DomainResponse<ConvertedValueModel> ConvertToWords(CurrencyValueToConvert currencyValue);
    }
}