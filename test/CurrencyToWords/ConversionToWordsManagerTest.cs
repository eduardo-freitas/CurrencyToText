using System;
using CurrencyToText.Domain.Business;
using CurrencyToText.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace CurrencyToText.Domain.Tests
{
    [TestClass]
    public class ConversionToWordsManagerTest
    {
        private readonly ConversionToWordsManager _manager;
        private readonly IConversionHandler _conversionHandler;

        public ConversionToWordsManagerTest()
        {
            _conversionHandler = Mock.Create<IConversionHandler>();
            _manager = new ConversionToWordsManager(_conversionHandler);
        }

        [TestMethod]
        public void ConversionWithSuccess()
        {
            var currencyToBeConverted = new CurrencyValueToConvert(100m);
            var currencyConverted = "one hundred dollars";

            Mock.Arrange(() => _conversionHandler.ConvertFromCurrencyToWords(currencyToBeConverted.CurrencyValue)).
                Returns(currencyConverted);

            var response = _manager.ConvertToWords(currencyToBeConverted);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsNull(response.DomainError);
            Assert.AreEqual(response.Result.Value, currencyToBeConverted.CurrencyValue);
            Assert.AreEqual(response.Result.WordsValue, currencyConverted);
        }

        [TestMethod]
        public void ErrorWhenCurrencyGreaterThanUpperLimit()
        {
            var currencyToBeConverted = new CurrencyValueToConvert(1_000_000_000m);

            var response = _manager.ConvertToWords(currencyToBeConverted);

            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsNotNull(response.DomainError);
        }

        [TestMethod]
        public void ErrorWhenConversionThrowsAnExpection()
        {
            var currencyToBeConverted = new CurrencyValueToConvert(100m);

            Mock.Arrange(() => _conversionHandler.ConvertFromCurrencyToWords(currencyToBeConverted.CurrencyValue)).
                Throws<DivideByZeroException>();

            var response = _manager.ConvertToWords(currencyToBeConverted);

            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsNotNull(response.DomainError);
        }
    }
}
