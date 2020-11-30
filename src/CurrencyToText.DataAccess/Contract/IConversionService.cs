using System.Threading.Tasks;
using CurrencyToText.Model;

namespace CurrencyToText.DataAccess.Contract
{
    public interface IConversionService
    {
        Task<ConvertedValueModel> ConvertToText(CurrencyToConvertModel currencyToConvertModel);
    }
}