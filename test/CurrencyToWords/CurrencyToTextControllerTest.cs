using System;
using System.Net;
using CurrencyToText.Domain.Contract;
using CurrencyToText.Domain.Model;
using CurrencyToText.Services.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace CurrencyToText.Domain.Tests
{
    [TestClass]
    public class CurrencyToTextControllerTest
    {
        private readonly CurrencyToTextController _controller;
        private readonly IConversionToWordsManager _manager;

        public CurrencyToTextControllerTest()
        {
            _manager = Mock.Create<IConversionToWordsManager>();
            _controller = new CurrencyToTextController(_manager);
        }

        [TestMethod]
        public void WhenRequestingAValidCurrency_AndNoErrorsHappen_ShouldReturnOk()
        {
            var currencyToBeConverted = new CurrencyValueToConvert(100m);
            var currencyConvertedModel = new DomainResponse<ConvertedValueModel>(
                new ConvertedValueModel(currencyToBeConverted.CurrencyValue, "one hundred dollars"), null);

            Mock.Arrange(() => _manager.ConvertToWords(currencyToBeConverted)).
                Returns(currencyConvertedModel);

            var response = _controller.ConvertFromCurrencyToWords(currencyToBeConverted);

            var result = response as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.OK);
        }

        [TestMethod]
        public void WhenRequestingAnInvalidCurrencyValue_ShouldReturnBadRequest()
        {
            var currencyToBeConverted = new CurrencyValueToConvert(1_000_000_000m);
            var currencyConvertedModel = new DomainResponse<ConvertedValueModel>(
                null, "Value too large");

            Mock.Arrange(() => _manager.ConvertToWords(currencyToBeConverted)).
                Returns(currencyConvertedModel);

            var response = _controller.ConvertFromCurrencyToWords(currencyToBeConverted);

            var result = response as BadRequestObjectResult;

            Assert.IsNotNull(response);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void WhenRequestingAConversion_AndAnExceptionHappen_ShouldReturnInternalServerError()
        {
            var currencyToBeConverted = new CurrencyValueToConvert(100m);

            Mock.Arrange(() => _manager.ConvertToWords(currencyToBeConverted)).
                Throws<Exception>();

            var response = _controller.ConvertFromCurrencyToWords(currencyToBeConverted);

            var result = response as StatusCodeResult;

            Assert.IsNotNull(response);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(response, typeof(StatusCodeResult));
            Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.InternalServerError);
        }
    }
}
