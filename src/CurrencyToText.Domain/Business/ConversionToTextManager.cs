using System;
using CurrencyToText.Domain.Contract;
using CurrencyToText.Domain.Model;

namespace CurrencyToText.Domain.Business
{
    public class ConversionToTextManager : IConversionToTextManager
    {
        private readonly IConversionHandler _conversionHelper;
        private const decimal MaxCurrencyValue = 999_999_999.99m;
        public ConversionToTextManager(IConversionHandler conversionHelper)
        {
            this._conversionHelper = conversionHelper;
        }

        public DomainResponse<ConvertedValueModel> ConvertToText(CurrencyValueToConvert currencyValue)
        {
            if (currencyValue.CurrencyValue > MaxCurrencyValue)
            {
                return new DomainResponse<ConvertedValueModel>(
                    null,
                    $"Currency value must be smaller than {MaxCurrencyValue}"
                );
            }

            try
            {
                var convertedValue = _conversionHelper.ConvertFromCurrencyToText(currencyValue.CurrencyValue);
                return new DomainResponse<ConvertedValueModel>(
                    new ConvertedValueModel(currencyValue.CurrencyValue, convertedValue),
                    null
                );
            }
            catch (Exception e)
            {
                return new DomainResponse<ConvertedValueModel>(
                    null,
                    $"Error while converting to words: {e}"
                );
            }
        }
    }
}
