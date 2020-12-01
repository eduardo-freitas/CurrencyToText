using CurrencyToText.Domain.Model;

namespace CurrencyToText.Domain.Contract
{
    public interface IConversionToTextManager
    {
        DomainResponse<ConvertedValueModel> ConvertToText(CurrencyValueToConvert currencyValue);
    }
}