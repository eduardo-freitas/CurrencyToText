using CurrencyToText.Domain.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyToWords
{
    [TestClass]
    public class ConversionHandlerTest
    {
        private readonly ConversionHandler _conversionHandler = new ConversionHandler();

        [TestMethod]
        public void _0DollarsConversion()
        {
            var currencyValue = 0m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToWords(currencyValue);
            Assert.AreEqual(convertedValue, "zero dollars");
        }

        [TestMethod]
        public void _1DollarConversion()
        {
            var currencyValue = 1m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToWords(currencyValue);
            Assert.AreEqual(convertedValue, "one dollar");
        }

        [TestMethod]
        public void _25DollarsAnd10CentsConversion()
        {
            var currencyValue = 25.1m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToWords(currencyValue);
            Assert.AreEqual(convertedValue, "twenty-five dollars and ten cents");
        }

        [TestMethod]
        public void _1CentConversion()
        {
            var currencyValue = 0.01m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToWords(currencyValue);
            Assert.AreEqual(convertedValue, "zero dollars and one cent");
        }

        [TestMethod]
        public void _45ThousandsConversion()
        {
            var currencyValue = 45_100m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToWords(currencyValue);
            Assert.AreEqual(convertedValue, "forty-five thousand one hundred dollars");
        }

        [TestMethod]
        public void _999MillionsConversion()
        {
            var currencyValue = 999999999.99m;
            var convertedValue = _conversionHandler.ConvertFromCurrencyToWords(currencyValue);
            Assert.AreEqual(convertedValue, "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents");
        }
    }
}
