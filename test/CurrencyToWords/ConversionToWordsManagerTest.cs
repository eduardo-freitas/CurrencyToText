using System;
using CurrencyToText.Domain.Business;
using CurrencyToText.Domain.Contract;
using CurrencyToText.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace CurrencyToText.Domain.Tests
{
    [TestClass]
    public class ConversionToWordsManagerTest
    {
        private readonly ConversionToTextManager _manager;
        private readonly IConversionHandler _conversionHandler;

        public ConversionToWordsManagerTest()
        {
            _conversionHandler = Mock.Create<IConversionHandler>();
            _manager = new ConversionToTextManager(_conversionHandler);
        }

        [TestMethod]
        public void WhenPerformingValidConversion_ShouldReturnSuccess()
        {
            var currencyToBeConverted = new CurrencyValueToConvert(100m);
            var currencyConverted = "one hundred dollars";

            Mock.Arrange(() => _conversionHandler.ConvertFromCurrencyToText(currencyToBeConverted.CurrencyValue)).
                Returns(currencyConverted);

            var response = _manager.ConvertToText(currencyToBeConverted);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsNull(response.DomainError);
            Assert.AreEqual(response.Result.Value, currencyToBeConverted.CurrencyValue);
            Assert.AreEqual(response.Result.WordsValue, currencyConverted);
        }

        [TestMethod]
        public void WhenPerformingInvalidConversion_ShouldReturnError()
        {
            var currencyToBeConverted = new CurrencyValueToConvert(1_000_000_000m);

            var response = _manager.ConvertToText(currencyToBeConverted);

            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsNotNull(response.DomainError);
        }

        [TestMethod]
        public void WhenPerformingAConversion_AndAnExceptionHappenShouldReturnError()
        {
            var currencyToBeConverted = new CurrencyValueToConvert(100m);

            Mock.Arrange(() => _conversionHandler.ConvertFromCurrencyToText(currencyToBeConverted.CurrencyValue)).
                Throws<DivideByZeroException>();

            var response = _manager.ConvertToText(currencyToBeConverted);

            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsNotNull(response.DomainError);
        }
    }
}
