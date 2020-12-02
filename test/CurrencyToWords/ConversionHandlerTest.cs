using CurrencyToText.Domain.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyToText.Domain.Tests
{
    [TestClass]
    public class ConversionHandlerTest
    {
        private readonly ConversionHandler _conversionHandler = new ConversionHandler();

        [TestMethod]
        public void WhenConverting_ValidValue_ShouldConvert1()
        {
            var currencyValue = 0m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToText(currencyValue);
            Assert.AreEqual(convertedValue, "zero dollars");
        }

        [TestMethod]
        public void WhenConverting_ValidValue_ShouldConvert2()
        {
            var currencyValue = 1m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToText(currencyValue);
            Assert.AreEqual(convertedValue, "one dollar");
        }

        [TestMethod]
        public void WhenConverting_ValidValue_ShouldConvert3()
        {
            var currencyValue = 25.1m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToText(currencyValue);
            Assert.AreEqual(convertedValue, "twenty-five dollars and ten cents");
        }

        [TestMethod]
        public void WhenConverting_ValidValue_ShouldConvert4()
        {
            var currencyValue = 0.01m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToText(currencyValue);
            Assert.AreEqual(convertedValue, "zero dollars and one cent");
        }

        [TestMethod]
        public void WhenConverting_ValidValue_ShouldConvert5()
        {
            var currencyValue = 45_100m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToText(currencyValue);
            Assert.AreEqual(convertedValue, "forty-five thousand one hundred dollars");
        }

        [TestMethod]
        public void WhenConverting_ValidValue_ShouldConvert6()
        {
            var currencyValue = 999999999.99m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToText(currencyValue);
            Assert.AreEqual(convertedValue, "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents");
        }

        [TestMethod]
        public void WhenConverting_ValidValue_ShouldConvert7()
        {
            var currencyValue = 1_000m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToText(currencyValue);
            Assert.AreEqual(convertedValue, "one thousand dollars");
        }
    }
}
