using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CurrencyToText.DataAccess.Contract;
using CurrencyToText.Model;

namespace CurrencyToText.DataAccess.Service
{
    public class ConversionService : IConversionService
    {
        private readonly HttpClient _apiClient;

        public ConversionService()
        {
            _apiClient = new HttpClient {BaseAddress = new Uri("http://localhost:5000/")};
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ConvertedValueModel> ConvertToTextAsync(CurrencyToConvertModel currencyToConvertModel)
        {
            ConvertedValueModel convertedCurrencyValue = null;
            HttpResponseMessage response = await _apiClient.PostAsJsonAsync(
                "api/currency-to-words", currencyToConvertModel).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                convertedCurrencyValue = await response.Content.ReadAsAsync<ConvertedValueModel>();
            }
            return convertedCurrencyValue;
        }

        public async Task<ConvertedValueModel> ConvertToText(CurrencyToConvertModel currencyToConvertModel)
        {
            return await ConvertToTextAsync(currencyToConvertModel).ConfigureAwait(false);
        }
    }
}
