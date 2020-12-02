using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CurrencyToText.DataAccess.Service;
using CurrencyToText.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace CurrencyToText.UI.Tests
{
    [TestClass]
    public class ConversionServiceTest
    {
        private ConversionService _conversionService;
        private HttpClient _apiClient;

        public ConversionServiceTest()
        {
            _apiClient = Mock.Create<HttpClient>();
            _apiClient.BaseAddress = new Uri("http://localhost:5000/");
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            this._conversionService = new ConversionService(_apiClient);
        }

        //TODO: encapsulate HttpClient class into a class/interface so we can use the free version of JustMock, which works only with interfaces
        /*        [TestMethod]
                public void WhenPerformingARequest_AndReceivingASuccessResponse_ShouldReturnSuccess()
                {
                    CurrencyToConvertModel currencyToConvertModel = new CurrencyToConvertModel(1.0m);
                    ConvertedValueModel convertedValueModel = new ConvertedValueModel(1.0m, "one dollar");
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ObjectContent<ConvertedValueModel>(convertedValueModel, new JsonMediaTypeFormatter(),
                            "application/some-format")
                    };
                    var responseTask = Task.FromResult(response);

                    Mock.Arrange(() => _apiClient.PostAsJsonAsync("api/currency-to-words", currencyToConvertModel)).Returns(responseTask);

                    var result = _conversionService.ConvertToText(currencyToConvertModel);

                    Assert.IsNotNull(result);
                    Assert.IsNotNull(result.Result);
                    Assert.AreEqual(convertedValueModel.WordsValue, result.Result.WordsValue);
                }*/


    }
}
