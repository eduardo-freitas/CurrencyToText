using System;

namespace CurrencyToText.Domain.Business
{
    public class ConversionHandler : IConversionHandler
    {
        public string ConvertFromCurrencyToWords(decimal currencyValue)
        {
            var dollars = (int) currencyValue;
            var cents = (int) ((currencyValue % 1.0m) * 100.0m);
            var convertedValue = dollars == 1
                ? $"{Convert(dollars)}dollar"
                : $"{Convert(dollars)}dollars";
            if (cents > 0)
            {
                convertedValue = cents == 1
                    ? $"{convertedValue} and {Convert(cents)}cent"
                    : $"{convertedValue} and {Convert(cents)}cents";
            }

            return convertedValue;
        }
        private string Convert(int currencyValue)
        {
            string words = "";

            var millions = currencyValue / 1_000_000;
            if (millions >= 1)
            {
                words = $"{Convert(millions)}million ";
                currencyValue -= millions * 1_000_000;
                if (currencyValue == 0) return words;
            }
            var thousands = currencyValue / 1_000;
            if (thousands >= 1)
            {
                words = $"{words}{Convert(thousands)}thousand ";
                currencyValue -= thousands * 1_000;
                if (currencyValue == 0) return words;
            }
            var hundreds = currencyValue / 100;
            if (hundreds >= 1)
            {
                words = $"{words}{Convert(hundreds)}hundred ";
                currencyValue -= hundreds * 100;
                if (currencyValue == 0) return words;
            }
            var tens = currencyValue;
            words = words == "" ? $"{ToWords(tens)} " :
                $"{words}{ToWords(tens)} ";

            return words;
        }

        private string ToWords(int tens)
        {
            var tensWords = "";
            var firstDigit = tens / 10;
            var secondDigit = tens - firstDigit * 10;
            switch (firstDigit)
            {
                case 9:
                    tensWords = secondDigit == 0 ? "ninety" : "ninety-";
                    break;
                case 8:
                    tensWords = secondDigit == 0 ? "eighty" : "eighty-";
                    break;
                case 7:
                    tensWords = secondDigit == 0 ? "seventy" : "seventy-";
                    break;
                case 6:
                    tensWords = secondDigit == 0 ? "sixty" : "sixty-";
                    break;
                case 5:
                    tensWords = secondDigit == 0 ? "fifty" : "fifty-";
                    break;
                case 4:
                    tensWords = secondDigit == 0 ? "forty" : "forty-";
                    break;
                case 3:
                    tensWords = secondDigit == 0 ? "thirty" : "thirty-";
                    break;
                case 2:
                    tensWords = secondDigit == 0 ? "twenty" : "twenty-";
                    break;
            }
            if (firstDigit == 1)
            {
                switch (secondDigit)
                {
                    case 9:
                        tensWords = "nineteen";
                        break;
                    case 8:
                        tensWords = "eighteen";
                        break;
                    case 7:
                        tensWords = "seventeen";
                        break;
                    case 6:
                        tensWords = "sixteen";
                        break;
                    case 5:
                        tensWords = "fiftenn";
                        break;
                    case 4:
                        tensWords = "fourteen";
                        break;
                    case 3:
                        tensWords = "thirteen";
                        break;
                    case 2:
                        tensWords = "twelve";
                        break;
                    case 1:
                        tensWords = "eleven";
                        break;
                    case 0:
                        tensWords = "ten";
                        break;
                }
            }
            else
            {
                switch (secondDigit)
                {
                    case 9:
                        tensWords = $"{tensWords}nine";
                        break;
                    case 8:
                        tensWords = $"{tensWords}eight";
                        break;
                    case 7:
                        tensWords = $"{tensWords}seven";
                        break;
                    case 6:
                        tensWords = $"{tensWords}six";
                        break;
                    case 5:
                        tensWords = $"{tensWords}five";
                        break;
                    case 4:
                        tensWords = $"{tensWords}four";
                        break;
                    case 3:
                        tensWords = $"{tensWords}three";
                        break;
                    case 2:
                        tensWords = $"{tensWords}two";
                        break;
                    case 1:
                        tensWords = $"{tensWords}one";
                        break;
                    case 0:
                        if (firstDigit == 0) tensWords =  "zero";
                        break;
                }
            }
            return tensWords;
        }
    }
}
