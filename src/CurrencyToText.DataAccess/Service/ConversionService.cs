using System;
using System.Configuration;
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

        public ConversionService(HttpClient apiClient)
        {
            var uri = new Uri(ConfigurationManager.AppSettings["ApiServerUri"]);
            _apiClient = apiClient;
            _apiClient.BaseAddress = uri;
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<ConvertedValueModel> ConvertToTextAsync(CurrencyToConvertModel currencyToConvertModel)
        {
            var route = ConfigurationManager.AppSettings["ApiConversionRoute"];
            ConvertedValueModel convertedCurrencyValue = null;
            HttpResponseMessage response = await _apiClient.PostAsJsonAsync(
                route, currencyToConvertModel).ConfigureAwait(false);
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
