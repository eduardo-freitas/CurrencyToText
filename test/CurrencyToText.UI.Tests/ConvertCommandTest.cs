using System;
using CurrencyToText.UI.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyToText.UI.Tests
{
    [TestClass]
    public class ConvertCommandTest
    {
        [TestMethod]
        public void WhenTestingForValidInput_WithNumberWithoutComma_ShoudReturnTrue()
        {
            var input = "0";

            var success = ConvertCommandHelper.IsValidInputFormat(input);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void WhenTestingForValidInput_WithNumberWithComma_ShoudReturnTrue()
        {
            var input = "25,1";

            var success = ConvertCommandHelper.IsValidInputFormat(input);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void WhenTestingForValidInput_WithGreatestNumberWithComma_ShoudReturnTrue()
        {
            var input = "999999999,99";

            var success = ConvertCommandHelper.IsValidInputFormat(input);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void WhenTestingForInvalidInput_WithGreaterThanMaximum_ShoudReturnFalse()
        {
            var input = "9999999999,99";

            var success = ConvertCommandHelper.IsValidInputFormat(input);

            Assert.IsFalse(success);
        }

        [TestMethod]
        public void WhenTestingForInvalidInput_WithoutDollarsDigits_ShoudReturnFalse()
        {
            var input = ",99";

            var success = ConvertCommandHelper.IsValidInputFormat(input);

            Assert.IsFalse(success);
        }

        [TestMethod]
        public void WhenTestingForInvalidInput_WithoutCentsDigits_ShoudReturnFalse()
        {
            var input = "7,";

            var success = ConvertCommandHelper.IsValidInputFormat(input);

            Assert.IsFalse(success);
        }

        [TestMethod]
        public void WhenTestingForInvalidInput_WithMoreThanTwoCentsDigits_ShoudReturnFalse()
        {
            var input = "7,777";

            var success = ConvertCommandHelper.IsValidInputFormat(input);

            Assert.IsFalse(success);
        }

        [TestMethod]
        public void WhenMappingToUIModel_WithOnlyDollarsDigits_ShoudReturnTheModelWithDollarsValue()
        {
            var input = "1";

            var result = ConvertCommandHelper.MapToDataAccessModel(input);

            Assert.AreEqual(result.CurrencyValue, 1m);
        }

        [TestMethod]
        public void WhenMappingToUIModel_WithDollarsAndCents_ShoudReturnTheModelWithDollarsAndCents()
        {
            var input = "9,8";

            var result = ConvertCommandHelper.MapToDataAccessModel(input);

            Assert.AreEqual(result.CurrencyValue, 9.8m);
        }
    }
}
